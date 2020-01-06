using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Model;
using SearchFight.Operational;

namespace SearchFight.Business
{
    public class BingSearch : ISearch
    {

        readonly private ISearchProcess<BingResponse> searchProcess;
        public BingSearch()
        {
            this.searchProcess = new BingSearchProcess();
        }

        public GeneralResponse GetSearchResult(string query)
        {
            return new GeneralResponse()
            {
                Engine = searchProcess.Engine,
                Name = query,
                Total = GetTotalSearchResult(query)
            };
        }

        public long GetTotalSearchResult(string query)
        {
            return this.searchProcess.GetTotalSearchResult(query);
        }
    }
}
