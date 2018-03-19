using LeagueConnector.Models.Json;

namespace LeagueConnector.Events
{
    public class ReadyCheckEvent : WebsocketEventBase
    {
        public ReadyCheckEvent(WebsocketEventBase args, ReadyCheck readyCheck) : base(args)
        {
            ReadyCheck = readyCheck;
        }

        public ReadyCheck ReadyCheck { get;}
    }
}