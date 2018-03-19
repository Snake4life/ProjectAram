using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Threading;
using Caliburn.Micro;
using LeagueConnector;
using LeagueConnector.Enum;
using LeagueConnector.Events;
using LeagueData;
using ProjectAram.Enums;
using ProjectAram.Events;
using ProjectAram.Helpers;
using ProjectAram.Properties;

namespace ProjectAram.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<ExtendedScreen>.Collection.OneActive, IShell, IHandle<ActivateScreenEvent>,
        IHandleWithTask<ReadyCheckEvent>, IHandleWithTask<NewInvitationsEvent>, IHandleWithTask<ConnectionChangedEvent>, IHandle<WinLoseEvent>
    {
        #region Fields

        private readonly IEventAggregator _eventAgg;
        private readonly IWindowManager _windowManager;
        private readonly Settings _settings;

        private readonly League _league;
        private readonly Parsers _parsers;

        private readonly MainViewModel _mainViewModel;
        private readonly EndGameViewModel _endGameViewModel;
        private readonly PreGameViewModel _preGameViewModel;

        private Process _lastLcuProcess;
        private int _lastIconId;

        //For test version I restrict use programm to specific id's
        private readonly List<int> _testersIds = new List<int>
        {
            1400152, 179576
        };

        #endregion

        #region Properties

        public IObservableCollection<ExtendedScreen> Screens { get; }

        public byte[] Icon { get; set; }

        public bool ConnectionStatus { get; set; }

        public bool LcuStatus { get; set; }

        public int LoseCounter { get; set; }

        public int WinCounter { get; set; }

        #endregion

        #region Constructor

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAgg, IWindowManager windowManager)
        {
            DisplayName = "Project ARAM " + GetAppVersion();
            _settings = Settings.Default;

            _league = new League();
            _parsers = new Parsers();

            _eventAgg = eventAgg;
            _eventAgg.Subscribe(this);
            _windowManager = windowManager;

            _mainViewModel = new MainViewModel(_eventAgg, _windowManager, _settings, _parsers, _league);
            _endGameViewModel = new EndGameViewModel(_eventAgg, _windowManager, _settings, _league);
            _preGameViewModel = new PreGameViewModel(_eventAgg, _windowManager, _settings, _parsers, _league);
#if DEBUG
            _league.OnWebsocketEvent += OnOnWebsocketEvent;
#endif
            _league.Сonnection.OnConnectionChangedEvent += e => { _eventAgg.PublishOnCurrentThread(e); };
            _league.OnReadyCheckEvent += e => { _eventAgg.PublishOnCurrentThread(e); };
            _league.OnNewInvitationsEvent += e => { _eventAgg.PublishOnCurrentThread(e); };
            _league.OnChampSelectSessionChangedEvent += e => { _eventAgg.PublishOnCurrentThread(e); };
            _league.OnEndGameEogEvent += e => { _eventAgg.PublishOnCurrentThread(e); };

            base.ActivateItem(_mainViewModel);
            ActivateHeartBeat();

            Screens = new BindableCollection<ExtendedScreen> { _mainViewModel, _preGameViewModel, _endGameViewModel };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Debug all LCU events
        /// </summary>
        private void OnOnWebsocketEvent(WebsocketEventBase args)
        {
            Debug.WriteLine(args.Path);
        }

        /// <summary>
        /// Activator for HeartBeat updater
        /// </summary>
        private void ActivateHeartBeat()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += HeartBeat;
            timer.Start();
        }

        /// <summary>
        /// HeartBeat updater
        /// </summary>
        private void HeartBeat(object sender, EventArgs es)
        {
            Task.WhenAll(Task.Run(() => UpdateLcuProcess()), Task.Run(() => UpdateProfile()));
        }

        /// <summary>
        /// Return current application version
        /// </summary>
        private string GetAppVersion()
        {
            return "v." + Assembly.GetExecutingAssembly().GetName().Version;
        }

        /// <summary>
        /// LCU process finder
        /// </summary>
        private void UpdateLcuProcess()
        {
            // Try find process
            var process = LeagueConnector.Helpers.FindLcuProcess();

            if (process != null)
            {
                LcuStatus = true;

                // If new find result is not same for current
                if (!ConnectionStatus && process.StartTime != _lastLcuProcess?.StartTime)
                {
                    _lastLcuProcess = process;

                    // Connect to LCU
                    _league.Connect(_lastLcuProcess);
                }
            }
            else
            {
                LcuStatus = false;
            }
        }

        /// <summary>
        /// Auto Login request
        /// </summary>
        private async void TryLogin()
        {
            // Decrypt password form settings and try login
            await _league.Api.Login.Session(_settings.AutoLoginName,
                Utils.Decrypt(_settings.AutoLoginPassword, "projectaram"));
        }

        /// <summary>
        /// Profile updater
        /// </summary>
        private async void UpdateProfile()
        {
            // Check if connected
            if (!ConnectionStatus) return;

            var profile = await _league.Api.Summoner.GetCurrentSummoner();

            // Check if summoner login
            if (profile != null)
            {
                // Check if user is Tester
                // TODO Change this to token app reg
                if (!_testersIds.Contains((int) profile.SummonerId))
                {
                    Environment.Exit(0);
                }

                // Update icon if it's change or first set
                if (_lastIconId != profile.ProfileIconId)
                {
                    Icon = await _league.Api.GameData.GetSummonerIcon(profile.ProfileIconId);
                    _lastIconId = profile.ProfileIconId;
                }
            }
        }

        /// <summary>
        /// Screen handler
        /// </summary>
        public void Handle(ActivateScreenEvent args)
        {
            switch (args.ETypeView)
            {
                case ETypeView.MainView:
                    if (_mainViewModel.IsEnabled) ActivateItem(_mainViewModel);
                    break;
                case ETypeView.EndGame:
                    if (_endGameViewModel.IsEnabled) ActivateItem(_endGameViewModel);
                    break;
                case ETypeView.PreGame:
                    if (_preGameViewModel.IsEnabled) ActivateItem(_preGameViewModel);
                    break;
            }
        }

        /// <summary>
        /// Auto-accept handler
        /// </summary>
        public async Task Handle(ReadyCheckEvent args)
        {
            // Check Auto-accept not active
            if (!_settings.AutoAcceptGame) return;

            // Only is in progress state and player not already response
            if (args.Type != ESocketEventType.Delete &&
                args.ReadyCheck.PlayerResponse == EReadyCheckPlayerResponse.None &&
                args.ReadyCheck.State == EReadyCheckState.InProgress)
            {
                // Auto-minimize laucher if needed
                if (_settings.AutoMinimizeLauncher) await _league.Api.Client.UxMinimize();

                // Accept game
                await _league.Api.Matchmaking.ResponseReadyCheck(args.ReadyCheck, EBasicAccept.Accept);
            }
        }

        /// <summary>
        /// Auto-accept invite handler
        /// </summary>
        public async Task Handle(NewInvitationsEvent args)
        {
            // Check settings and invite type
            if (!_settings.AutoAcceptInvation || args.Type == ESocketEventType.Delete) return;

            // Get the first invite
            var invite = args.Invitations.First();

            if (invite.CanAccept)
            {
                //Accept invite
                await _league.Api.Lobby.ResponseInvite(invite, EBasicAccept.Accept);
            }
        }

        /// <summary>
        /// Connection status handler
        /// </summary>
        public async Task Handle(ConnectionChangedEvent args)
        {
            ConnectionStatus = args.Status;

            // Check auto login and session not already exists
            if (ConnectionStatus && _settings.AutoLogin && await _league.Api.Login.GetSession() == null)
            {
                await Task.Delay(1000);
                TryLogin();
            }
        }

        /// <summary>
        /// End game result handler
        /// </summary>
        public void Handle(WinLoseEvent args)
        {
            if (args.Status == EWinLose.Win)
            {
                WinCounter++;
            }
            else
            {
                LoseCounter++;
            }
        }

        #endregion
    }
}