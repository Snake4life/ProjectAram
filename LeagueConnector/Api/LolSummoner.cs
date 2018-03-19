using System.Threading.Tasks;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;

namespace LeagueConnector.Api
{
    public class LolSummoner : BaseApi
    {
        public LolSummoner(Connection connection) : base(connection)
        {
        }

        public async Task<Summoner> GetCurrentSummoner()
        {
            return await _connection.Get<Summoner>(Endpoints.V1_LOLSUMMONER_CURRENT);
        }

    }
}