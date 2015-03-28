using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace UsecaseTesting
{
    public interface Base_Log
    {
        // meta means, that everything that describes the message can be send. It could be a json or something later
        void WriteRaw(string meta, string message);
    }   
}
