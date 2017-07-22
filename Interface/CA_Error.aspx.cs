using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interface
{
    public partial class CA_Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Session["field1"] = null;//clears the username from session field to prevent access without login
            Response.Redirect("Login.aspx");//redirects to login page
        }

    }
}