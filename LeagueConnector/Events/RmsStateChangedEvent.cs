using LeagueConnector.Enum;

namespace LeagueConnector.Events
{
    public class RmsStateChangedEvent : WebsocketEventBase
    {
        public RmsStateChangedEvent(WebsocketEventBase args, ERmsState state) : base (args)
        {
            State = state;
        }

        public ERmsState State { get; set; }
    }
}