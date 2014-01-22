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
    // This behavior works as a singleton class
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AirDBSvc : IAirDBSvc
    {        
        private List<DataTable> TablesOBJ = new List<DataTable>();
        private List<TableMeta> TablesMedata = new List<TableMeta>(); // Light object to carry existing table metadata

        public bool Create(string tablename, int timetolive)
        {
            if (!Helper.tableExists(TablesMedata, tablename)) //TODO: Add name spaces
            {
                // Table metadata
                TableMeta tm = new TableMeta();
                tm.Name = tablename;
                tm.TimeToLive = timetolive;
                TablesMedata.Add(tm);
                // Table itself =)
                DataTable table = new DataTable();
                table.TableName = tablename;
                TablesOBJ.Add(table);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddRow(string tablename, DataRow row)
        {
            if (!Helper.tableExists(TablesMedata, tablename)) 
            {
                Helper.getDataTableById(TablesOBJ, tablename).ImportRow(row);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(string tablename)
        {
            if (Helper.tableExists(TablesMedata, tablename))
            {
                TablesOBJ.Remove(Helper.getDataTableById(TablesOBJ, tablename));
                TablesMedata.Remove(TablesMedata.Where(x => x.Name == tablename).FirstOrDefault());
            }
        }

        public DataTable Query(string query, string tablename)
        {
            DataRow[] dw = Helper.getDataTableById(TablesOBJ, tablename).Select(query);
            DataTable dt = new DataTable();
            dt.LoadDataRow(dw, true);
            return dt;
        }

        public List<String> TableNames()
        {
            return Helper.getTableNameList(TablesMedata);
        }

        public bool TableExists(string tablename)
        {
            return Helper.tableExists(TablesMedata, tablename);
        }
    }
}
