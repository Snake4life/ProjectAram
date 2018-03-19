using System.Collections.Generic;
using LeagueConnector.Enum;
using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class ReadyCheck
    {
        [JsonProperty("declinerIds")]
        public List<int> DeclinerIds { get; set; }

        [JsonProperty("dodgeWarning")]
        public string DodgeWarning { get; set; }

        [JsonProperty("playerResponse")]
        public EReadyCheckPlayerResponse PlayerResponse { get; set; }

        [JsonProperty("state")]
        public EReadyCheckState State { get; set; }

        [JsonProperty("suppressUx")]
        public bool SuppressUx { get; set; }

        [JsonProperty("timer")]
        public double Timer { get; set; }
    }

}