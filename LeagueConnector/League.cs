using System;
using System.Collections.Generic;
using System.Diagnostics;
using LeagueConnector.Enum;
using LeagueConnector.Events;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;
using Newtonsoft.Json;

namespace LeagueConnector
{
    public class League
    {
        public event Action<NewInvitationsEvent> OnNewInvitationsEvent;
        public event Action<ReadyCheckEvent> OnReadyCheckEvent;
        public event Action<WebsocketEventBase> OnWebsocketEvent;
        public event Action<ChampSelectSessionEvent> OnChampSelectSessionChangedEvent;
        public event Action<RmsStateChangedEvent> OnRmsStateChangedEvent;
        public event Action<EogStatsEvent> OnEndGameEogEvent;

        public readonly Connection Сonnection;
        private Process _process;

        public readonly Methods Api;

        public League()
        {
            Сonnection = new Connection();
            Сonnection.OnWebsocketEvent += OnWebsocketMessage;

            Api = new Methods(Сonnection);
        }

        public void Connect(Process lcuProcess)
        {
            _process = lcuProcess;
            var data = _process.FindLcuParams();
            Сonnection.Connect(data.Item1, data.Item2);
        }

        private void OnWebsocketMessage(WebsocketEventBase args)
        {
            OnWebsocketEvent?.Invoke(args);

            switch (args.Path)
            {
                case Endpoints.V2_LOLLOBBY_RECEIVED_INVITATIONS:
                    List<ReceivedInvitation> invitations = string.IsNullOrEmpty(args.RawData) ? null : JsonConvert.DeserializeObject<List<ReceivedInvitation>>(args.RawData);
                    if (invitations.Count <= 0) return;
                    OnNewInvitationsEvent?.Invoke(new NewInvitationsEvent(args, invitations));
                    break;
                case Endpoints.V1_LOLMATCHMAKING_READYCHECK:
                    var readyCheck = string.IsNullOrEmpty(args.RawData) ? null : JsonConvert.DeserializeObject<ReadyCheck>(args.RawData);
                    OnReadyCheckEvent?.Invoke(new ReadyCheckEvent(args, readyCheck));
                    break;
                case Endpoints.V1_RIOTMESSAGINGSERVICE_STATE:
                    var state = System.Enum.Parse(typeof(ERmsState), args.RawData);
                    OnRmsStateChangedEvent?.Invoke(new RmsStateChangedEvent(args, state));
                    break;
                case Endpoints.V1_CHAMP_SELECT_SESSION:
                    var champSession = string.IsNullOrEmpty(args.RawData) ? null : JsonConvert.DeserializeObject<ChampSelectSession>(args.RawData);
                    OnChampSelectSessionChangedEvent?.Invoke(new ChampSelectSessionEvent(args, champSession));
                    break;
                case Endpoints.V1_LOLENDOFGAME_EOGSTATSBLOCK:
                    var eogStats = string.IsNullOrEmpty(args.RawData) ? null : JsonConvert.DeserializeObject<EogStatsBlock>(args.RawData);
                    OnEndGameEogEvent?.Invoke(new EogStatsEvent(args, eogStats));
                    break;
            }
        }

    }
}
