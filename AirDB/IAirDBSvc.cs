using System;
using System.Collections.Generic;
using System.Data;
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
        bool Create(string tablename, int timetolive);

        [OperationContract]
        bool AddRow(string tablename, DataRow row);

        [OperationContract]
        void Remove(string tablename);

        [OperationContract]
        DataTable Query(string query, string tablename);

        [OperationContract]
        List<String> TableNames();

        [OperationContract]
        bool TableExists(string tablename);
    }
}
