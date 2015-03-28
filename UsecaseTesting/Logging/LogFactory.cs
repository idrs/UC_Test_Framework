using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public interface LogFactory
    {
        Activity_Assertion_Log GetAssertionLog();
        Activity_Log GetActivityLog();
        Core_Log GetCoreLog();
    }
}
