using LiteDB;

namespace ProjectAram.Models.DB
{
    public class DbSummoner
    {
        public int Id { get; set; }

        public int SummonerId { get; set; }

        public string Note { get; set; }

        public int GamesPlayedWithHim { get; set; }
    }
}