using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using LeagueConnector;
using LeagueConnector.Enum;
using LeagueConnector.Events;
using LeagueConnector.Models.Json;
using LeagueData;
using LeagueData.Lolking;
using ProjectAram.Enums;
using ProjectAram.Events;
using ProjectAram.Helpers;
using ProjectAram.Models;
using ProjectAram.Properties;
using ProjectAram.Services;

namespace ProjectAram.ViewModels
{
    public class PreGameViewModel : ExtendedScreen,  IHandle<ChampSelectSessionEvent>
    {
        #region Fields

        private readonly Parsers _parsers;
        private readonly League _league;

        private string _runeToken;
        private string _skinToken;

        #endregion

        #region Properties

        public List<PreGamePlayerStats> Players { get; set; }

        #endregion

        #region Constructor

        public PreGameViewModel(IEventAggregator eventAgg, IWindowManager windowManager,
            Settings settings, Parsers parsers, League league) : base(eventAgg, windowManager, settings)
        {
            TabName = "Game Start";
            _parsers = parsers;
            _league = league;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Champs select handler
        /// </summary>
        public void Handle(ChampSelectSessionEvent args)
        {
            switch (args.Type)
            {
                case ESocketEventType.Update:

                    // If Tab and model not enabled before - activate it
                    if (!IsTabEnabled) IsTabEnabled = true;
                    if (!IsEnabled) IsEnabled = true;

                    var session = args.Session;
                    var player = session.MyTeam.First(w => w.CellId == session.LocalPlayerCellId);

                    // Set data if not already exists
                    if (Players == null) SetStats(args.Session.TheirTeam.Concat(args.Session.MyTeam), player.SummonerId);

                    // If need change runes and champ selected
                    if (_settings.AutoChageRunes && args.Session.Timer.Phase == EChampSelectPhaze.Finalization)
                    {
                        var chatName = session.ChatDetails.ChatRoomName;
                        var champId = player.ChampionId;
                        var skinId = player.SelectedSkinId;
                        var runeToken = chatName + champId;
                        var skinToken = chatName + skinId;

                        Task.Run(() => ChangeRunes(champId, runeToken));
                        Task.Run(() => SetBackgroundImage(champId, skinId, skinToken));
                    }
                    break;
                case ESocketEventType.Delete: // If session delete - reset model
                    Reset();
                    break;
                case ESocketEventType.Create: // If new session - activate model
                    Activate();
                    break;
            }
        }

        /// <summary>
        /// Leave current champ select session
        /// </summary>
        /// <returns></returns>
        public async Task LeaveGame()
        {
            // Leave game
            if (await _league.Api.Login.QuitGame())
            {
                // Close lobby (default UI not close automatically)
                await _league.Api.Lobby.DeleteLobby();
            }
        }

        /// <summary>
        /// Set main data
        /// </summary>
        private void SetStats(IEnumerable<TeamPlayer> players, int myId)
        {
            Players = players.Select(s =>
            {
                var dbSummoner = DataBaseService.GetSummoner(s.SummonerId);

                var player = new PreGamePlayerStats
                {
                    SummonerId = s.SummonerId,
                    SummonerName = s.DisplayName,
                    Team = s.Team,
                };

                if (s.SummonerId != myId && s.PlayerType != EPlayerType.Bot && dbSummoner != null)
                {
                    player.GamesPlayedWithHim = dbSummoner.GamesPlayedWithHim;
                    player.Note = dbSummoner.Note;
                }

                return player;
            }).ToList();
        }

        /// <summary>
        /// Set background image
        /// </summary>
        private async Task SetBackgroundImage(int champId, int skinId, string skinToken)
        {
            if (_skinToken != skinToken)
            {
                _skinToken = skinToken;
                base.SetBackgroundImage(await _league.Api.GameData.GetChampionSplash(champId, skinId));
            }
        }

        /// <summary>
        /// Change runes
        /// </summary>
        private async Task ChangeRunes(int champId, string runeToken)
        {
            // Check if rune for current champ not already set
            if (_runeToken == runeToken) return;
            _runeToken = runeToken;

            // Parse and get
            var runeDataResp = await _parsers.LolKing.GetRunesV2(champId, "euw", LolKing.RUNES_SORT_TOTAL);
            var runeData = runeDataResp.First().Runes;

            // Get summoner rune pages
            var allRunePages = await _league.Api.Perks.GetRunePages();

            // Find rune page created before by us
            var appRunePage = allRunePages.FirstOrDefault(f => f.Name == "ProjectAram");

            // If it's finded - delete
            if (appRunePage != null)
            {
                await _league.Api.Perks.DeleteRunePage(appRunePage);
            }

            // Create new rune page
            var createStatus = await _league.Api.Perks.CreateRunePage("ProjectAram", runeData.PerkPrimaryStyle,
                runeData.PerkSubStyle, new List<int>
                {
                    runeData.Perk0,
                    runeData.Perk1,
                    runeData.Perk2,
                    runeData.Perk3,
                    runeData.Perk4,
                    runeData.Perk5
                });

            // If page created - ok, return
            if (createStatus) return;

            // If not - delete first rune page
            await _league.Api.Perks.DeleteRunePage(allRunePages.First());

            // And try create again
            await _league.Api.Perks.CreateRunePage("ProjectAram", runeData.PerkPrimaryStyle, runeData.PerkSubStyle,
                new List<int>
                {
                    runeData.Perk0,
                    runeData.Perk1,
                    runeData.Perk2,
                    runeData.Perk3,
                    runeData.Perk4,
                    runeData.Perk5
                });
        }

        /// <summary>
        /// Activate model
        /// </summary>
        private void Activate()
        {
            IsEnabled = true;
            IsTabEnabled = true;

            Utils.SetForegroundWindow(1000); // Mini delay ^^

            // Show view for this model
            _eventAgg.PublishOnUIThread(new ActivateScreenEvent { ETypeView = ETypeView.PreGame });
        }

        /// <summary>
        /// Reset model
        /// </summary>
        private void Reset()
        {
            IsTabEnabled = false;
            IsEnabled = false;
            Players = null;

            _eventAgg.PublishOnUIThread(new ActivateScreenEvent { ETypeView = ETypeView.MainView });
        }

        #endregion
    }
}