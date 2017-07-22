using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interface
{
    public partial class OTLTO1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string aid = (string)Session["AID"];//declaring session AID as aid
            string sid = (string)Session["SID"];//declaring session SID as sid

            //set any chosen fields that were selected to not chosen
            SqlConnection con = new SqlConnection(@"Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");// mysql connection 
            con.Open(); //open connection
            SqlCommand updateChosen_cmd = new SqlCommand("UPDATE Availability SET Chosen = 0 WHERE Series_ID = '" + sid + "'", con);
            updateChosen_cmd.ExecuteNonQuery(); //execute update
            con.Close(); //close connection
            
        }
    }
}