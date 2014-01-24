using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestingWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AirDBService.IAirDBSvc svc = new AirDBService.AirDBSvcClient();
            Label2.Text = svc.Drop("TestTable");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AirDBService.IAirDBSvc svc = new AirDBService.AirDBSvcClient();
            string[] columns = { "field1", "field2", "field3" };
            Label1.Text = svc.Create("TestTable", columns, 1);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            AirDBService.IAirDBSvc svc = new AirDBService.AirDBSvcClient();
            object[] values = { "1", "hello", "world" };
            svc.InsertRow("TestTable", values);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            AirDBService.IAirDBSvc svc = new AirDBService.AirDBSvcClient();
            svc.Delete("TestTable", "field1 = 1");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            AirDBService.IAirDBSvc svc = new AirDBService.AirDBSvcClient();
            DataTable dt = svc.Query("field1 = '1'", "TestTable");

            Label5.Text = dt.Rows.Count.ToString() + " rows found";
        }
    }
}