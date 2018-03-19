using LeagueConnector.Api;

namespace LeagueConnector
{
    public class Methods
    {
        public readonly LolLobby Lobby;
        public readonly LolLogin Login;
        public readonly LolSummoner Summoner;
        public readonly LolPerks Perks;
        public readonly LolGameData GameData;
        public readonly RsoAuth RsoAuth;
        public readonly RiotClient Client;
        public readonly LolMatchmaking Matchmaking;

        public Methods(Connection connection)
        {
            Lobby = new LolLobby(connection);
            Login = new LolLogin(connection);
            Summoner = new LolSummoner(connection);
            Perks = new LolPerks(connection);
            GameData = new LolGameData(connection);
            RsoAuth = new RsoAuth(connection);
            Client = new RiotClient(connection);
            Matchmaking = new LolMatchmaking(connection);
        }
    }
}