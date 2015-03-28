using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public interface Activity_Assertion_Log : Base_Log
    {
        Activity_Assertion_Log_FluentInterface Write { get; }
    }

    public class Activity_Assertion_Log_FluentInterface
    {
        protected readonly Activity_Assertion_Log _logInterface;
        public Activity_Assertion_Log_FluentInterface(Activity_Assertion_Log logInterface)
        {
            _logInterface = logInterface;
        }

        public void Pass(string message)
        {
            _logInterface.WriteRaw("Pass", message);
        }

        public void Fail(string message)
        {
            _logInterface.WriteRaw("Fail", message);
        }

        public void Inconclusive(string message)
        {
            _logInterface.WriteRaw("Inconclusive", message);
        }
    }
}
