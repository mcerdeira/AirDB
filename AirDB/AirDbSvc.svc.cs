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
    // This behavior works as a singleton class
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AirDBSvc : IAirDBSvc
    {        
        private List<DataTable> TablesOBJ = new List<DataTable>();
        private List<TableMeta> TablesMedata = new List<TableMeta>(); // Light object to carry existing table metadata

        public string Create(string tablename, string[] columns, int timetolive)
        {
            string result;
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
                foreach(string c in columns)
                {
                    table.Columns.Add(c);
                }
                TablesOBJ.Add(table);

                result = "Table [{0}] created.";
            }
            else
            {
                result = "Table [{0}] already exists.";
            }
            return String.Format(result, tablename);
        }

        public bool InsertRow(string tablename, object[] row)
        {
            if (Helper.tableExists(TablesMedata, tablename)) 
            {
                Helper.getDataTableById(TablesOBJ, tablename).Rows.Add(row);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string tablename, string where)
        {
            if (!Helper.tableExists(TablesMedata, tablename))
            {
                foreach (DataRow row in Helper.getDataTableById(TablesOBJ, tablename).Select(where))
                {
                    Helper.getDataTableById(TablesOBJ, tablename).Rows.Remove(row);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Drop(string tablename)
        {
            string result;
            if (Helper.tableExists(TablesMedata, tablename))
            {
                TablesOBJ.Remove(Helper.getDataTableById(TablesOBJ, tablename));
                TablesMedata.Remove(TablesMedata.Where(x => x.Name == tablename).FirstOrDefault());
                result = "Table {0} droped.";
            }
            else
            {
                result = "Table {0} does not exist.";
            }
            return String.Format(result, tablename);
        }

        public DataTable Query(string query, string tablename)
        {
            DataView dv = new DataView(Helper.getDataTableById(TablesOBJ, tablename));
            dv.RowFilter = query;
            return dv.ToTable(tablename);
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
