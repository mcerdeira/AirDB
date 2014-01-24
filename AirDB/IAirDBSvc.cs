using System;
using System.Collections;
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
        string Create(string tablename, string[] columns, int timetolive);

        [OperationContract]
        bool InsertRow(string tablename, object[] row);

        [OperationContract]
        bool Delete(string tablename, string where);

        [OperationContract]
        string Drop(string tablename);

        [OperationContract]
        DataTable Query(string query, string tablename);

        [OperationContract]
        List<String> TableNames();

        [OperationContract]
        bool TableExists(string tablename);
    }
}
