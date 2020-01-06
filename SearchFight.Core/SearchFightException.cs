using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Core
{
    [Serializable]
    public class SearchFightException : Exception
    {
        public SearchFightException()
        {
        }

        public SearchFightException(string message) : base(message)
        {
        }

        public SearchFightException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
