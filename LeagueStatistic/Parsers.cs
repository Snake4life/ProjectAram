using LeagueData.Lolking;

namespace LeagueData
{
    public class Parsers
    {
        private readonly Client _client;
        public readonly LolKing LolKing;

        public Parsers()
        {
            _client = new Client();
            LolKing = new LolKing(_client);
        }
    }
}