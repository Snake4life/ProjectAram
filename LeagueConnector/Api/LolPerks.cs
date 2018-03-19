using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;
using Newtonsoft.Json;

namespace LeagueConnector.Api
{
    public class LolPerks : BaseApi
    {
        public LolPerks(Connection connection) : base(connection)
        {
        }

        public async Task<RunePage> GetCurrentRunePage()
        {
            return await _connection.Get<RunePage>(Endpoints.V1_LOLPERKS_CURRENTPAGE);
        }

        public async Task<RunePage> GetRunePage(int id)
        {
            return await _connection.Get<RunePage>(Endpoints.V1_LOLPERKS_PAGE + "/" + id);
        }

        public async Task<List<RunePage>> GetRunePages(bool withoutDefault = true)
        {
            var resp = await _connection.Get<List<RunePage>>(Endpoints.V1_LOLPERKS_PAGES);

            return withoutDefault ? resp.Where(w => w.IsDeletable).ToList() : resp;
        }

        public async Task<bool> CreateRunePage(RunePage runePage)
        {
            return await _connection.Post(Endpoints.V1_LOLPERKS_PAGES, JsonConvert.SerializeObject(runePage));
        }

        public async Task<bool> DeleteRunePage(RunePage page)
        {
            if (!page.IsDeletable) return false;
            return await _connection.Delete(Endpoints.V1_LOLPERKS_PAGES + "/" + page.Id);
        }

        public async Task<bool> CreateRunePage(string name, int primaryStyle, int subStyle, List<int> runes, bool current = true)
        {
            return await CreateRunePage(new RunePage
            {
                Current = current,
                Name = name,
                FormatVersion = 4,
                IsValid = true,
                IsEditable = true,
                PrimaryStyleId = primaryStyle,
                SubStyleId = subStyle,
                SelectedPerkIds = runes
            });
        }

    }
}