using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Model;
namespace SearchFight.Business
{
    public interface ISearch
    {
        long GetTotalSearchResult(string query);
        GeneralResponse GetSearchResult(string query);
    }
}
