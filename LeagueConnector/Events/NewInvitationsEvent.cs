using System.Collections.Generic;
using LeagueConnector.Models.Json;

namespace LeagueConnector.Events
{
    public class NewInvitationsEvent : WebsocketEventBase
    {
        public NewInvitationsEvent(WebsocketEventBase args, List<ReceivedInvitation> invitations) : base (args)
        {
            Invitations = invitations;
        }

        public List<ReceivedInvitation> Invitations { get; }
    }
}