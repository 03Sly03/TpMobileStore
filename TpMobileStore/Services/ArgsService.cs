using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMobileStore.Services
{
    public class ArgsService
    {
        Dictionary<string, object> parameters;

        public event Action ArgsUpdated;
        public ArgsService()
        {
            parameters = new Dictionary<string, object>();
        }

        public void Save(string key, object value)
        {
            if (parameters.ContainsKey(key))
            {
                parameters.Remove(key);
            }
            parameters.Add(key, value);
            if (ArgsUpdated != null)
                ArgsUpdated();
        }

        public object Get(string key)
        {
            object result;
            if (parameters.TryGetValue(key, out result))
            {
                return result;
            }
            return null;
        }
    }
}
