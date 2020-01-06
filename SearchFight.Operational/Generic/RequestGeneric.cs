using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Core;

namespace SearchFight.Operational
{
    public class RequestGeneric
    {
        public virtual HttpWebRequest GetRequest(string url)
        {
            return (HttpWebRequest)WebRequest.Create(url);
        }

        public async Task<T> GetSearchResult<T>(string url) where T : class
        {
            using (Stream responseStream = await GetResponseStream(url))
                return SearchFightObjectSerialize.GetObject<T>(responseStream);
        }
        private async Task<WebResponse> GetResponse(string url)
        {
           return await GetRequest(url).GetResponseAsync();
        }

        private async Task<Stream> GetResponseStream(string url) { 
            return (await GetResponse(url)).GetResponseStream();
        }

    }
}
