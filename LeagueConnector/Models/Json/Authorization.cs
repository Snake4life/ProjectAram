using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class Authorization
    {
        [JsonProperty("currentAccountId")]
        public int CurrentAccountId { get; set; }

        [JsonProperty("currentPlatformId")]
        public string CurrentPlatformId { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}