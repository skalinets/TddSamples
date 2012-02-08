using System;
using System.Collections.Generic;

namespace WebApplication2.Logic
{
    public class NegativesAreNotAllowed : Exception
    {
        public NegativesAreNotAllowed(IEnumerable<int> negatives)
            : base(string.Format("Negatives are not allowed {0}.", string.Join(",", negatives)))
        {

        }
    }
}