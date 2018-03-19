using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class PostSession
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}