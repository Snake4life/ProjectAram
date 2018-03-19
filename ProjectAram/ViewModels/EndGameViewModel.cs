using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using LeagueConnector;
using LeagueConnector.Enum;
using LeagueConnector.Events;
using LeagueConnector.Models.Json;
using ProjectAram.Enums;
using ProjectAram.Events;
using ProjectAram.Helpers;
using ProjectAram.Models;
using ProjectAram.Properties;
using ProjectAram.Services;

namespace ProjectAram.ViewModels
{
    public class EndGameViewModel : ExtendedScreen, IHandle<EogStatsEvent>
    {
        private readonly League _league;

        private int _lastGameId;

        public List<EndGamePlayerStats> Players { get; set; }

        public EndGamePlayerStats SelectedPlayer { get; set; }

        public override bool IsTabEnabled
        {
            get
            {
                return Players != null && Players.Count > 0;
            }
        }

        private void SetStats(EogStatsBlock eog)
        {
            var players = eog.Teams.SelectMany(s => s.Players).ToList();

            Players = players.Select(s =>
            {
                var model = new EndGamePlayerStats
                {
                    Assists = s.Stats.Assists,
                    ChampionId = s.ChampionId,
                    Team = s.TeamId,
                    TotalDamageToChampions = s.Stats.TotalDamageDealtToChampions,
                    Leaves = s.Leaves,
                    Wins = s.Wins,
                    Losses = s.Losses,
                    Level = s.Level,
                    SummonerName = s.SummonerName,
                    SummonerId = s.SummonerId,
                    Deaths = s.Stats.NumDeaths,
                    Kills = s.Stats.ChampionsKilled
                };

                if (eog.SummonerId != s.SummonerId && !s.BotPlayer)
                {
                    var findHistory = DataBaseService.GetSummoner(s.SummonerId);
                    model.GamesPlayedWithHim = findHistory == null ? 0 : findHistory.GamesPlayedWithHim;

                    DataBaseService.IncreaseSummonerGwh(s.SummonerId);   
                }

                return model;
            }).OrderByDescending(o => o.TotalDamageToChampions).ToList();

            SelectedPlayer = Players.First(f => f.SummonerName == eog.SummonerName);
        }

        public EndGameViewModel(IEventAggregator eventAgg, IWindowManager windowManager, Settings settings,
            League league) : base(eventAgg, windowManager, settings)
        {
            _league = league;
            DisplayName = "End Game Stats";
            TabName = "Last Game";
        }

        private void LoadNotes()
        {
            if (Players == null || Players.Count <= 0) return;

            Players.ForEach(f => f.Note = DataBaseService.GetSummoner(f.SummonerId)?.Note);
        }

        public void NoteEdit(EndGamePlayerStats player)
        {
            DataBaseService.SetSummonerNote(player.SummonerId, player.Note.WithMaxLength(50));
        }

        private async void SetBackgroundImage(int champId, int skinId)
        {
            BackgroundImage = await _league.Api.GameData.GetChampionSplash(champId, skinId);
        }

        private void LoadIcons()
        {
            if(Players == null || Players.Count <= 0) return;

            Players.ForEach(async f => { f.ChampionIcon = await _league.Api.GameData.GetChampionIcon(f.ChampionId); });
        }

        public void Handle(EogStatsEvent args)
        {
            if (args.Type == ESocketEventType.Delete || args.Stats == null || args.Stats.GameId == _lastGameId) return;
            IsEnabled = true;

            _lastGameId = args.Stats.GameId;

            SetStats(args.Stats);

            Task.Run(() => LoadIcons());
            Task.Run(() => LoadNotes());
            Task.Run(() => SetBackgroundImage(args.Stats.ChampionId, args.Stats.SkinId));

            _eventAgg.PublishOnUIThread(new ActivateScreenEvent { ETypeView = ETypeView.EndGame});

            if (_settings.AutoPlayAgain) Task.Run(() => _league.Api.Lobby.PlayAgainV2());


            var winTeamId = args.Stats.Teams.First(w => w.IsWinningTeam).TeamId;
            var myTeam = args.Stats.Teams.SelectMany(s => s.Players).First(w => w.SummonerId == args.Stats.SummonerId)
                .TeamId;

            _eventAgg.PublishOnBackgroundThread(winTeamId == myTeam
                ? new WinLoseEvent {Status = EWinLose.Win}
                : new WinLoseEvent {Status = EWinLose.Lose});


            Utils.SetForegroundWindow(2000);
        }
    }
}