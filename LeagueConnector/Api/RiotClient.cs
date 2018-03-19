using System.Threading.Tasks;
using LeagueConnector.Static;

namespace LeagueConnector.Api
{
    public class RiotClient : BaseApi
    {
        public RiotClient(Connection connection) : base(connection)
        {
        }

        public async Task<bool> UxMinimize()
        {
            return await _connection.Post(Endpoints.RIOTCLIENT_UXMINIMIZE, "");
        }
    }
}