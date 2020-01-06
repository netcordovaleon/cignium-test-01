using SearchFight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Test
{
    public class DataSourceTest
    {
        public static  IList<GeneralResponse> listWinner;

        public DataSourceTest()
        {
            
        }

        public static IList<GeneralResponse> ListWinnerGoogle()
        {
            listWinner = new List<GeneralResponse>();

            listWinner.Add(new GeneralResponse()
            {
                Name = "java",
                Engine = "Google",
                Total = 100
            });

            listWinner.Add(new GeneralResponse()
            {
                Name = "net",
                Engine = "Google",
                Total = 150
            });

            listWinner.Add(new GeneralResponse()
            {
                Name = "net",
                Engine = "Bing",
                Total = 8
            });


            listWinner.Add(new GeneralResponse()
            {
                Name = "java",
                Engine = "Bing",
                Total = 8
            });

            return listWinner;
        }

        public static IList<GeneralResponse> ListWinnerBing()
        {
            listWinner = new List<GeneralResponse>();

            listWinner.Add(new GeneralResponse()
            {
                Name = "java",
                Engine = "Google",
                Total = 100
            });

            listWinner.Add(new GeneralResponse()
            {
                Name = "net",
                Engine = "Google",
                Total = 150
            });

            listWinner.Add(new GeneralResponse()
            {
                Name = "net",
                Engine = "Bing",
                Total = 400
            });


            listWinner.Add(new GeneralResponse()
            {
                Name = "java",
                Engine = "Bing",
                Total = 800
            });

            return listWinner;
        }
    }
}
