using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public interface Activity_Log : Base_Log
    {
        Activity_Log_FluentInterface Write { get; }
    }

    public class Activity_Log_FluentInterface
    {
        protected readonly Activity_Log _logInterface;
        public Activity_Log_FluentInterface(Activity_Log logInterface)
        {
            _logInterface = logInterface;
        }


        public void Info(string message)
        {
            _logInterface.WriteRaw("Info", message);
        }

        public void Warning(string message)
        {
            _logInterface.WriteRaw("Warning", message);
        }

        public void Error(string message)
        {
            _logInterface.WriteRaw("Error", message);
        }
    }
}
