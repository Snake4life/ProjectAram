using LeagueConnector.Models.Json;

namespace LeagueConnector.Events
{
    public class EogStatsEvent : WebsocketEventBase
    {
        public EogStatsEvent(WebsocketEventBase args, EogStatsBlock stats) : base(args)
        {
            Stats = stats;
        }

        public EogStatsBlock Stats { get; }
    }
}