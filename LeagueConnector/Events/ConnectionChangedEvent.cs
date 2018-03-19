using System;

namespace LeagueConnector.Events
{
    public class ConnectionChangedEvent : EventArgs
    {
        public bool Status { get; set; }
    }
}