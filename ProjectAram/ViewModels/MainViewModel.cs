using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsFirewallHelper;
using WindowsFirewallHelper.FirewallAPIv2.Rules;
using Caliburn.Micro;
using LeagueConnector;
using LeagueConnector.Events;
using LeagueData;
using LeagueData.Default.Enums;
using ProjectAram.Helpers;
using ProjectAram.Properties;

namespace ProjectAram.ViewModels
{
    public class MainViewModel : ExtendedScreen, IHandleWithTask<ConnectionChangedEvent>
    {
        #region Fields

        private readonly Parsers _parsers;
        private readonly League _league;

        #endregion

        #region Properties

        public List<byte[]> FreeRotation { get; set; }

        public bool IsAutoAcceptGame
        {
            get => _settings.AutoAcceptGame;
            set
            {
                _settings.AutoAcceptGame = value;
                _settings.Save();
            }
        }

        public bool IsAutoAcceptInvations
        {
            get => _settings.AutoAcceptInvation;
            set
            {
                _settings.AutoAcceptInvation = value;
                _settings.Save();
            }
        }

        public bool IsAutoChangeRunePages
        {
            get => _settings.AutoChageRunes;
            set
            {
                _settings.AutoChageRunes = value;
                _settings.Save();
            }
        }

        public bool IsAutoMinimizeLauncher
        {
            get => _settings.AutoMinimizeLauncher;
            set
            {
                _settings.AutoMinimizeLauncher = value;
                _settings.Save();
            }
        }

        public bool IsAutoPlayAgain
        {
            get => _settings.AutoPlayAgain;
            set
            {
                _settings.AutoPlayAgain = value;
                _settings.Save();
            }
        }

        public bool IsOfflineMode
        {
            get => _settings.OfflineMode;
            set
            {
                SetOfflineMode(value);
                _settings.OfflineMode = value;
                _settings.Save();
            }
        }

        public bool IsAutoLogin
        {
            get => _settings.AutoLogin;
            set
            {
                if (value)
                {
                    SetAutoLoginData();
                }
                _settings.AutoLogin = value;
                _settings.Save();
            }
        }

        #endregion

        #region Constructor

        public MainViewModel(IEventAggregator eventAgg, IWindowManager windowManager, Settings settings,
            Parsers parsers, League league) : base(eventAgg, windowManager, settings)
        {
            DisplayName = "Project ARAM";
            TabName = "Main";

            _parsers = parsers;
            _league = league;

            IsTabEnabled = true;
            IsEnabled = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set data for auto-login
        /// </summary>
        public async void SetAutoLoginData()
        {
            // Get data from user
            var result = await DialogController.ShowLoginPasswordDialog("Auto-Login", null, "OK");

            if (result == null || string.IsNullOrEmpty(result.Username) || string.IsNullOrEmpty(result.Password))
            {
                IsAutoLogin = false;
            }
            else
            {
                //Save username
                _settings.AutoLoginName = result.Username;

                //TODO make salt randomly for user
                //Encrypt and save password
                var encPass = Utils.Encrypt(result.Password, "projectaram");
                _settings.AutoLoginPassword = encPass;

                _settings.Save();
            }
        }

        /// <summary>
        /// Load and set current free champion rotation icons
        /// </summary>
        private async void SetFreeRotation()
        {
            // Load data
            var rotation = await _parsers.LolKing.GetFreeRotation();

            // Get id's
            var iconsIds = rotation.Select(s => s.ChampionId).ToArray();

            FreeRotation = await _league.Api.GameData.GetChampionsIcons(iconsIds);
        }

        /// <summary>
        /// Toogle windows firewall port
        /// </summary>
        /// <param name="value"></param>
        private void SetOfflineMode(bool value)
        {
            // Rules names
            var inRuleName = @"LCU-Block-5223-in";
            var outRuleName = @"LCU-Block-5223-out";

            // Find old rules
            var inRule = FirewallManager.Instance.Rules.SingleOrDefault(r => r.Name == inRuleName);
            var outRule = FirewallManager.Instance.Rules.SingleOrDefault(r => r.Name == outRuleName);

            // Choose block or allow port
            var ruleValue = value ? FirewallAction.Block : FirewallAction.Allow;

            if (inRule == null) // if rule not exist - create it
            {
                var ruleIn = new StandardRule(inRuleName, ruleValue, FirewallDirection.Inbound,
                    FirewallProfiles.Domain | FirewallProfiles.Private | FirewallProfiles.Public)
                {
                    Protocol = FirewallProtocol.TCP,
                    LocalPorts = new ushort[] { 5223 } // Lol chat port
                };
                FirewallManager.Instance.Rules.Add(ruleIn);
            }
            else
            {
                inRule.Action = ruleValue;
            }

            // Same for out rule
            if (outRule == null)
            {
                var ruleOut = new StandardRule(outRuleName, ruleValue, FirewallDirection.Outbound,
                    FirewallProfiles.Domain | FirewallProfiles.Private | FirewallProfiles.Public)
                {
                    Protocol = FirewallProtocol.TCP,
                    RemotePorts = new ushort[] { 5223 }
                };
                FirewallManager.Instance.Rules.Add(ruleOut);
            }
            else
            {
                outRule.Action = ruleValue;
            }
        }

        /// <summary>
        /// Connection status handler
        /// </summary>
        public async Task Handle(ConnectionChangedEvent args)
        {
            if (args.Status)
            {
                if (BackgroundImage == null) SetBackgroundImage(await _league.Api.GameData.GetChampionSplash((int)Utils.RandomEnumValue<Champions>()));
                if (FreeRotation == null) SetFreeRotation();
            }
        }

        #endregion
    }
}