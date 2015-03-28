using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsecaseTesting
{
    public class Setting
    {
        public void SetFlow(UsecaseTest useCaseTest)
        {
            Flow = useCaseTest.Flow;
        }
    
        public Usecase_Activity_BeginFlow_FluentInterface Flow { get; private set; }

        private Dictionary<string, object> resources;
        private Dictionary<string, object> Resources 
        { 
            get
            {
                if(resources == null)
                    resources = new Dictionary<string, object>();
                return resources;
            }  
        }

        public void SetResource(string id, object o)
        { 
            id = id.Trim();

            if (Resources.ContainsKey(id))
            {
                throw new ArgumentException("Resource with Key " + id + " already exists");
            }

            Resources.Add(id, o);
        }

        public T GetResource<T>(string id)
        {
            id = id.Trim();
            if (Resources.ContainsKey(id) == false)
                throw new ArgumentException("Resource with Key " + id + " doesn't exist");

            T o = (T)Resources[id];

            return o;
        }

        public virtual void Initialize() { }

        public virtual void Cleanup() { }
    }
}
