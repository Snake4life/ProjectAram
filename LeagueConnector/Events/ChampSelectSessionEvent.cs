using LeagueConnector.Models.Json;

namespace LeagueConnector.Events
{
    public class ChampSelectSessionEvent : WebsocketEventBase
    {
        public ChampSelectSessionEvent(WebsocketEventBase args, ChampSelectSession session) : base (args)
        {
            Session = session;
        }

        public ChampSelectSession Session { get; }
    }
}