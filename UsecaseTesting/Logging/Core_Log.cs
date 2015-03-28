using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public interface Core_Log : Base_Log
    {
        void WriteBeginlog();
        Core_Log_FluentInterface Write { get; }
    }

    public class Core_Log_FluentInterface
    {
        protected readonly Core_Log _logInterface;
        public Core_Log_FluentInterface(Core_Log logInterface)
        {
            _logInterface = logInterface;
        }

        public void Error(string message)
        {
            _logInterface.WriteRaw("Core.Error", message);
        }

        public void Info(string message)
        {
            _logInterface.WriteRaw("Core.Info", message);
        }
    }
}
