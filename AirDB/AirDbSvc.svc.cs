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
        private Dictionary<string, string> MainOBJ = new Dictionary<string, string>();

        public Dictionary<string, string> getColletion()
        {
            return MainOBJ;
        }

        public string getValue(string key)
        {
            return MainOBJ[key];
        }

        public string getKey(string value)
        {
            return MainOBJ.FirstOrDefault(x => x.Value == value).Key;
        }

        public void setKeyValue(string key, string value)
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
    }
}
