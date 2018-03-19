using Newtonsoft.Json;

namespace LeagueData.Lolking.Models
{
    public class RuneBuild
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("runes")]
        public Runes Runes { get; set; }
        [JsonProperty("total_games")]
        public int TotalGames { get; set; }
        [JsonProperty("total_wins")]
        public int TotalWins { get; set; }
        [JsonProperty("win_rate")]
        public decimal WinRate { get; set; }
    }

    public class Runes
    {
        [JsonProperty("perk0")]
        public int Perk0 { get; set; }
        [JsonProperty("perk1")]
        public int Perk1 { get; set; }
        [JsonProperty("perk2")]
        public int Perk2 { get; set; }
        [JsonProperty("perk3")]
        public int Perk3 { get; set; }
        [JsonProperty("perk4")]
        public int Perk4 { get; set; }
        [JsonProperty("perk5")]
        public int Perk5 { get; set; }
        [JsonProperty("perkPrimaryStyle")]
        public int PerkPrimaryStyle { get; set; }
        [JsonProperty("perkSubStyle")]
        public int PerkSubStyle { get; set; }
    }
}