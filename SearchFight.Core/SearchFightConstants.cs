using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Core
{
    public static class SearchFightConstants
    {
        public static class Google {

            public static string APIURL
            {
                get => $"https://www.googleapis.com/customsearch/v1?key={TOKEN}&cx=017576662512468239146:omuauf_lfve&q=";
            }

            const string TOKEN = "AIzaSyAf7zCM2RgxF_y0s1HGQA8TPKb9o7AiXb0";

            public const string ENGINE = "Google";
        }
        


        public static class Bing
        {
            public const string APIURL = "https://api.cognitive.microsoft.com/bing/v7.0/search?q=";
            public const string TOKEN = "74e21242af1b472f87c42fdf2265deff";
            public const string ENGINE = "Bing";
        }

    }
}
