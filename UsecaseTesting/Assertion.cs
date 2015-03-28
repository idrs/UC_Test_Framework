using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public class Assertion
    {
        public string Message { get; set; }
        public AssertionState AssertState { get; set; }
    }

    public enum AssertionState
    {
        Pass,
        Fail,
        Inconclusive
    }

}
