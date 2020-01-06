using SearchFight.Business;
using SearchFight.Core;
using SearchFight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SetUp
{
    public class Resolver : IResolver
    {
        private IList<GeneralResponse> SearchResolver(string[] arg)
        {
            IList<GeneralResponse> result = new List<GeneralResponse>();
            List<ISearch> resolverSearchEngine = new List<ISearch>();
            resolverSearchEngine.Add(new BingSearch());
            resolverSearchEngine.Add(new GoogleSearch());

            foreach (var languages in arg)
            {
                foreach (var engine in resolverSearchEngine)
                {
                    result.Add(engine.GetSearchResult(languages));
                }
            }
            return result;
        }

        private GeneralResponse GetWinnerByEngine(IList<GeneralResponse> response, string Engine)
        {
            return response.Where(x => x.Engine == Engine).OrderByDescending(x => x.Total).FirstOrDefault();
        }

        private GeneralResponse GetWinner(IList<GeneralResponse> response)
        {
            var groupResponseByLanguages = response.GroupBy(item => item.Name);
            return groupResponseByLanguages.Select(x => new GeneralResponse() { Name = x.Key, Total = x.Sum(y => y.Total) }).OrderByDescending(z => z.Total).First();
        }

        public bool ValidateArguments(string[] arg)
        {
            if (arg.Length <= 1) {
                throw new ArgumentException("Should enter more than one languages");
            }

            foreach (var languages in arg)
            {
                if (string.IsNullOrEmpty(languages)) {
                    throw new SearchFightException("Languages couldn't be empty");
                }
            }
            return true;
        }

        public GeneralResponse GetWinnerByEngine(string[] arg, string engine)
        {
            var result = SearchResolver(arg);
            return GetWinnerByEngine(result, engine);
        }

        public GeneralResponse GetWinner(string[] arg)
        {
            var result = SearchResolver(arg);
            return GetWinner(result);
        }

        public string FinalResponse(string[] arg)
        {
            StringBuilder response = new StringBuilder();
            var result = SearchResolver(arg);
            var groupLanguages = result.GroupBy(item => item.Name);
            var responsePerEngine = groupLanguages.Select(group => new Tuple<string, long, long>(group.Key,
                                        group.FirstOrDefault(x => x.Engine == SearchFightConstants.Google.ENGINE).Total,
                                        group.FirstOrDefault(x => x.Engine == SearchFightConstants.Bing.ENGINE).Total))
                                .ToList();
            responsePerEngine.ForEach(t =>
                response.Append($"{t.Item1} Google Search: {t.Item2} Bing Search: {t.Item3} \n")
            );

            response.Append($"Google Winner: { GetWinnerByEngine(result, SearchFightConstants.Google.ENGINE).Name } \n");
            response.Append($"Bing Winner: { GetWinnerByEngine(result, SearchFightConstants.Bing.ENGINE).Name } \n");
            response.Append($"TOTAL Winner: { GetWinner(result).Name } \n");

            return response.ToString();
        }
    }
}
