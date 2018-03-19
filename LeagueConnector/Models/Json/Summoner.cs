using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class Summoner
    {
        [JsonProperty("displayName")]
        public string Name { get; set; }

        [JsonProperty("accountId")]
        public int Id { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("lastSeasonHighestRank")]
        public string LastSeasonHighestRank { get; set; }

        [JsonProperty("percentCompleteForNextLevel")]
        public int PercentCompleteForNextLevel { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("puuid")]
        public string PuUid { get; set; }

        [JsonProperty("rerollPoints")]
        public SummonerRerollPoints RerollPoints { get; set; }

        [JsonProperty("summonerId")]
        public int? SummonerId { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("xpSinceLastLevel")]
        public int XpSinceLastLevel { get; set; }

        [JsonProperty("xpUntilNextLevel")]
        public int XpUntilNextLevel { get; set; }
    }

    public class SummonerRerollPoints
    {
        [JsonProperty("currentPoints")]
        public int CurrentPoints { get; set; }

        [JsonProperty("maxRolls")]
        public int MaxRolls { get; set; }

        [JsonProperty("numberOfRolls")]
        public int NumberOfRolls { get; set; }

        [JsonProperty("pointsCostToRoll")]
        public int PointsCostToRoll { get; set; }

        [JsonProperty("pointsToReroll")]
        public int PointsToReroll { get; set; }
    }
}