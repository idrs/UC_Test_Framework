using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UsecaseTesting
{
    public class XmlLog : Activity_Log, Activity_Assertion_Log, Core_Log
    {
        public XmlLog(string basePath)
        {
            BasePath = basePath;
        }

        public string BasePath { get; set; }

        public string GetLogFilePath()
        {
            return Path.Combine(BasePath, "UsecaseTest_Log.xml");
        }

        private Activity_Log_FluentInterface write;
        public Activity_Log_FluentInterface Write
        {
            get
            {
                if (write == null)
                    write = new Activity_Log_FluentInterface(this);
                return write;
            }
        }

        public void WriteRaw(string meta, string message)
        {

        }

        private Activity_Assertion_Log_FluentInterface assertion_log_write;
        Activity_Assertion_Log_FluentInterface Activity_Assertion_Log.Write
        {
            get
            {
                if (assertion_log_write == null)
                    assertion_log_write = new Activity_Assertion_Log_FluentInterface(this);

                return assertion_log_write;
            }
        }

        public void WriteBeginlog()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"));
        }

        private Core_Log_FluentInterface core_log_write;
        Core_Log_FluentInterface Core_Log.Write
        {
            get
            {
                if (core_log_write == null)
                    core_log_write = new Core_Log_FluentInterface(this);

                return core_log_write;
            }
        }
    }
}
