using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Operational
{
    public interface ISearchProcess<T>
    {
        string Engine { get; }
        string GetUrl(string query);
        long GetTotalSearchResult(string query);
        Task<T> GetSearchResult(string url);
    }   
}
