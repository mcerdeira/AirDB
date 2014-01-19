using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AirDB
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AirDBSvc : IAirDBSvc
    {
        private Dictionary<string, object> MainOBJ = new Dictionary<string, object>();

        public Dictionary<string, object> getColletion()
        {
            return MainOBJ;
        }

        public object getValue(string key)
        {
            return MainOBJ[key];
        }

        public string getKey(object value)
        {
            return MainOBJ.FirstOrDefault(x => x.Value == value).Key;
        }

        public void setKeyValue(string key, object value)
        {
            MainOBJ.Add(key, value);
        }

        public void removeKey(string key)
        {
            MainOBJ.Remove(key);            
        }

        public void clear()
        {
            MainOBJ.Clear();
        }

        public void dump()
        { 
            //TODO
        }
    }
}
