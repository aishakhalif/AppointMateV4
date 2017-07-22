using System;

namespace Interface
{
    public partial class About_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["field1"] != null) //this code is to check of the users current state is logged in or not
            {
                Session["field1"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Session["field1"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}