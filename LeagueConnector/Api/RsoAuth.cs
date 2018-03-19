using System.Threading.Tasks;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;

namespace LeagueConnector.Api
{
    public class RsoAuth : BaseApi
    {
        public RsoAuth(Connection connection) : base(connection)
        {
        }

        public async Task<Authorization> GetAuth()
        {
            return await _connection.Get<Authorization>(Endpoints.V1_RSOAUTH_AUTHORIZATION);
        }
    }
}