using SearchFight.Model;
using System.Linq;
using System.Threading.Tasks;
using SearchFight.Core;
using System.Net;

namespace SearchFight.Operational
{
    public class BingSearchProcess : RequestGeneric, ISearchProcess<BingResponse>
    {
        private HttpWebRequest PrepareBingRequest(HttpWebRequest request)
        {
            request.Headers["Ocp-Apim-Subscription-Key"] = SearchFightConstants.Bing.TOKEN;
            return request;
        }

        public string Engine
        {
            get => SearchFightConstants.Bing.ENGINE;
        }

        public override HttpWebRequest GetRequest(string url)
        {
            return PrepareBingRequest(base.GetRequest(url));
        }

        public async Task<BingResponse> GetSearchResult(string url)
        {
            return await GetSearchResult<BingResponse>(url);
        }

        public long GetTotalSearchResult(string query)
        {
            var result = GetSearchResult(GetUrl(query)).Result;
            return result.webPages.totalEstimatedMatches;
        }

        public string GetUrl(string query)
        {
            return SearchFightConstants.Bing.APIURL + query;
        }
    }
}
