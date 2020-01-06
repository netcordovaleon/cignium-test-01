using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SetUp
{
    public class ProgramMiddleware
    {

        public static void SearchRun(string[] arg) {
            IResolver resolver = new Resolver();
            var isValid = resolver.ValidateArguments(arg);
            if (isValid) {
                var response = resolver.FinalResponse(arg);
                Console.WriteLine(response);
                Console.ReadKey();
            }
        }
    }
}
