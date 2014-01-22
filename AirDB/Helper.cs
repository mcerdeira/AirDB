using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AirDB
{
    public static class Helper
    {
        public static DataTable getDataTableById(List<DataTable> dlist, string id)
        {
            return dlist.Where(x => x.TableName == id).SingleOrDefault();
        }

        public static bool tableExists(List<TableMeta> dlist, string id)
        {
            return dlist.Where(x => x.Name == id).Count() == 1;
        }

        public static List<String> getTableNameList(List<TableMeta> dlist)
        {
            List<String> tnlist = new List<String>();
            foreach (TableMeta meta in dlist)
            {
                tnlist.Add(meta.Name);
            }
            return tnlist;
        }
    }
}