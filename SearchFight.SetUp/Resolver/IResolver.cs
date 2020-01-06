using SearchFight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SetUp
{
    public interface IResolver
    {
        bool ValidateArguments(string[] arg);
        GeneralResponse GetWinnerByEngine(string[] arg, string engine);
        GeneralResponse GetWinner(string[] arg);
        string FinalResponse(string[] arg);
    }
}
