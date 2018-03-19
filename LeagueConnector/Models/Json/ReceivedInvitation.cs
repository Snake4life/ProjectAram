using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class ReceivedInvitation
    {
        [JsonProperty("canAcceptInvitation")]
        public bool CanAccept { get; set; }

        [JsonProperty("fromSummonerId")]
        public int FromSummonerId { get; set; }

        [JsonProperty("fromSummonerName")]
        public string FromSummonerName { get; set; }

        [JsonProperty("invitationId")]
        public string InvitationId { get; set; }

        [JsonProperty("gameConfig")]
        public ReceivedInvitationGameConfig GameConfig { get; set; }

        [JsonProperty("restrictions")]
        public List<object> Restrictions { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    public class ReceivedInvitationGameConfig
    {
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("gameMutator")]
        public string GameMutator { get; set; }

        [JsonProperty("inviteGameType")]
        public string InviteGameType { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }
    }
}