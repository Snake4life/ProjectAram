using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueConnector.Static;

namespace LeagueConnector.Api
{
    public class LolGameData : BaseApi
    {
        public LolGameData(Connection connection) : base(connection)
        {
        }

        public async Task<byte[]> GetSummonerIcon(int id)
        {
            return await _connection.GetByteArray(Endpoints.V1_LOLGAMEDATA_ASSETS_PROFILEICONS + "/" + id + ".jpg");
        }

        public async Task<byte[]> GetChampionIcon(int champId)
        {
            return await _connection.GetByteArray(Endpoints.V1_LOLGAMEDATA_ASSETS_CHAMPIONICONS + "/" + champId + ".png");
        }

        public async Task<List<byte[]>> GetChampionsIcons(int[] champIds)
        {
            var icons = new List<byte[]>();
            foreach (var champId in champIds)
            {
                icons.Add(await _connection.GetByteArray(Endpoints.V1_LOLGAMEDATA_ASSETS_CHAMPIONICONS + "/" + champId + ".png"));
            }
            return icons;
        }

        public async Task<byte[]> GetChampionSplash(int champId, int skinId)
        {
            return await _connection.GetByteArray(Endpoints.V1_LOLGAMEDATA_ASSETS_CHAMPIONSPLASHES + "/" + champId + "/" + skinId + ".jpg");
        }

        public async Task<byte[]> GetChampionSplash(int champId)
        {
            return await _connection.GetByteArray(Endpoints.V1_LOLGAMEDATA_ASSETS_CHAMPIONSPLASHES + "/" + champId + "/" + champId + "000.jpg");
        }

    }
}