using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public class XmlFactory : LogFactory
    {
        public XmlFactory(string basePath)
        {
            BasePath = basePath;
        }

        public string BasePath { get; private set; }

        private XmlLog _xmlLog;
        public XmlLog XmlLogInstance
        {
            get
            {
                if (_xmlLog == null)
                    _xmlLog = new XmlLog(string.Empty);

                return _xmlLog;
            }
        }

        public Activity_Assertion_Log GetAssertionLog()
        {
            return XmlLogInstance;
        }

        public Activity_Log GetActivityLog()
        {
            return XmlLogInstance;
        }

        public Core_Log GetCoreLog()
        {
            return XmlLogInstance;
        }
    }
}
