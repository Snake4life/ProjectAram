using System.Threading.Tasks;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;
using Newtonsoft.Json;

namespace LeagueConnector.Api
{
    public class LolLogin : BaseApi
    {
        public LolLogin(Connection connection) : base(connection)
        {
        }

        public async Task<bool> QuitGame()
        {
            return await _connection.Post(Endpoints.V1_LOLLOGIN_SESSION_INVOKE + "?destination=gameService&method=quitGame&args=[]", "");
        }

        public async Task<Session> GetSession()
        {
            return await _connection.Get<Session>(Endpoints.V1_LOLLOGIN_SESSION);
        }

        public async Task<bool> Session(string username, string password)
        {
            return await Session(new PostSession {Password = password, Username = username});
        }

        public async Task<bool> Session(PostSession data)
        {
            return await _connection.Post(Endpoints.V1_LOLLOGIN_SESSION, JsonConvert.SerializeObject(data));
        }

    }
}