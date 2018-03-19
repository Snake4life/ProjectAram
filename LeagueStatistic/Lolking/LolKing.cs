using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LeagueData.Lolking.Models;
using Newtonsoft.Json;

namespace LeagueData.Lolking
{
    public class LolKing
    {
        private readonly Client _client;

        private const string LOLSTATS_BASE = "http://lolstats.services.zam.com/v1";
        private const string LOLDATA_BASE = "http://loldata.services.zam.com/v1";
        private const string BASE_URL = "http://www.lolking.net";

        public const string RUNES_SORT_WINRATE = "win_rate";
        public const string RUNES_SORT_TOTAL = "total_games";

        public LolKing(Client client)
        {
            _client = client;
        }

        public async Task<List<RuneBuild>> GetRunesV2(int champId, string region, string sort)
        {
            return await Get<List<RuneBuild>>(LOLSTATS_BASE + $"/runesv2?champion_id={champId}&page=1&pageSize=1&region={region}&slice=weekly&sort={sort}");
        }

        public async Task<List<Champion>> GetFreeRotation()
        {
            return await Get<List<Champion>>(LOLDATA_BASE + "/champion?in_rotation=true&sort=name");
        }

        private async Task<T> Get<T>(string url)
        {

            var resp = await _client.Send(HttpMethod.Get, url, new Dictionary<string, string>
            {
                {"Referer", BASE_URL},
                {
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36"
                },
                {"Accept", "application/json"},
                {"Host", new Uri(url).Host},
                {"Origin", BASE_URL}
            });

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                return default(T);
            }

        }

    }
}