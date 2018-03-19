using LiteDB;
using ProjectAram.Models.DB;

namespace ProjectAram.Services
{
    public static class DataBaseService
    {
        private static string _dbName = "Data.db";
        private static string _playersInteractionTable = "players_history";

        private static LiteDatabase OpenDb()
        {
            var db = new LiteDatabase(_dbName);
            db.Engine.EnsureIndex(_playersInteractionTable, "SummonerId", true);
            return db;
        }

        public static void IncreaseSummonerGwh(int summonerId, int increase = 1)
        {
            using (var db = OpenDb())
            {
                var collection = db.GetCollection<DbSummoner>(_playersInteractionTable);

                var summoner = collection.FindOne(f => f.SummonerId == summonerId);

                if (summoner == null)
                {
                    collection.Insert(new DbSummoner
                    {
                        SummonerId = summonerId,
                        GamesPlayedWithHim = increase
                    });
                }
                else
                {
                    summoner.GamesPlayedWithHim = summoner.GamesPlayedWithHim + increase;
                    collection.Update(summoner);
                }
            }
        }

        public static void SetSummonerNote(int summonerId, string note)
        {
            using (var db = OpenDb())
            {
                var collection = db.GetCollection<DbSummoner>(_playersInteractionTable);

                var summoner = collection.FindOne(f => f.SummonerId == summonerId);

                if (summoner == null)
                {
                    collection.Insert(new DbSummoner
                    {
                        SummonerId = summonerId,
                        Note = note
                    });
                }
                else
                {
                    summoner.Note = note;
                    collection.Update(summoner);
                }
            }
        }

        public static DbSummoner GetSummoner(int summonerId)
        {
            using (var db = OpenDb())
            {
                var collection = db.GetCollection<DbSummoner>(_playersInteractionTable);
                return collection.FindOne(f => f.SummonerId == summonerId);
            }
        }
    }
}