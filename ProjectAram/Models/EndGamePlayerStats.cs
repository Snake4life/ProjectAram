using Caliburn.Micro;

namespace ProjectAram.Models
{
    public class EndGamePlayerStats : GamePlayerStats
    {
        public int ChampionId { get; set; }
        public int Losses { get; set; }
        public int Leaves { get; set; }
        public int Wins { get; set; }
        public int Level { get; set; }
        public int Team { get; set; }
        public int Assists { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int TotalDamageToChampions { get; set; }
    }
}