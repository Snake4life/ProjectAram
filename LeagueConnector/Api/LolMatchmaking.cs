using System.Threading.Tasks;
using LeagueConnector.Enum;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;

namespace LeagueConnector.Api
{
    public class LolMatchmaking : BaseApi
    {
        public LolMatchmaking(Connection connection) : base(connection)
        {
        }

        public async Task<bool> ResponseReadyCheck(ReadyCheck readyCheck, EBasicAccept status)
        {
            return await _connection.Post(Endpoints.V1_LOLMATCHMAKING_READYCHECK + $"/{status.ToString().ToLower()}", "");
        }

    }
}