using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class Session
    {
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        [JsonProperty("connected")]
        public bool Connected { get; set; }
        [JsonProperty("error")]
        public object Error { get; set; }
        [JsonProperty("gasToken")]
        public SessionGasToken GasToken { get; set; }
        [JsonProperty("idToken")]
        public string IdToken { get; set; }
        [JsonProperty("isNewPlayer")]
        public bool IsNewPlayer { get; set; }
        [JsonProperty("puuid")]
        public string Puuid { get; set; }
        [JsonProperty("queueStatus")]
        public object QueueStatus { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("summonerId")]
        public int? SummonerId { get; set; }
        [JsonProperty("userAuthToken")]
        public string UserAuthToken { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class SessionGasToken
    {
        [JsonProperty("date_time")]
        public string DateTime { get; set; }
        [JsonProperty("gas_account_id")]
        public string GasAccountId { get; set; }
        [JsonProperty("pvpnet_account_id")]
        public string PvpnetAccountId { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
        [JsonProperty("vouching_key_id")]
        public string VouchingKeyId { get; set; }
    }
}