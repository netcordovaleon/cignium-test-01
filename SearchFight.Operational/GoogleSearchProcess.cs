using SearchFight.Model;
using System.Linq;
using System.Threading.Tasks;
using SearchFight.Core;
namespace SearchFight.Operational
{
    public class GoogleSearchProcess : RequestGeneric, ISearchProcess<GoogleResponse>
    {
        public string Engine {
            get => SearchFightConstants.Google.ENGINE;
        }

        public async Task<GoogleResponse> GetSearchResult(string url)
        {
            return await GetSearchResult<GoogleResponse>(url);
        }

        public long GetTotalSearchResult(string query)
        {
            var result = GetSearchResult(GetUrl(query)).Result;
            return result.queries.request.FirstOrDefault().totalResults;
        }

        public string GetUrl(string query)
        {
            return SearchFightConstants.Google.APIURL + query;
        }
    }
}
