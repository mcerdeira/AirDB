using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AirDB
{    
    [ServiceContract]    
    public interface IAirDBSvc
    {
        [OperationContract]
        Dictionary<string, object> getColletion();

        [OperationContract]
        object getValue(string key);

        [OperationContract]
        string getKey(object value);

        [OperationContract]
        void setKeyValue(string key, object value);

        [OperationContract]
        void removeKey(string key);

        [OperationContract]
        void clear();
    }
}
