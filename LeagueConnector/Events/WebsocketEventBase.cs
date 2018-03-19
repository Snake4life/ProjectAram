using System;
using LeagueConnector.Enum;

namespace LeagueConnector.Events
{
    public class WebsocketEventBase : EventArgs
    {
        public WebsocketEventBase(WebsocketEventBase args)
        {
            Path = args.Path;
            Type = args.Type;
            RawData = args.RawData;
        }

        public WebsocketEventBase() { }

        public string Path { get; set; }
        public ESocketEventType Type { get; set; }
        public dynamic RawData { get; set; }
    }
}