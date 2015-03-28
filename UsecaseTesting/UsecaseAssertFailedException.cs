using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public class UsecaseAssertFailedException : Exception
    {
        public UsecaseAssertFailedException(string message, string activity)
            : base(message)
        {
            Activity = activity;
        }

        public string Activity { get; private set; }
    }
}
