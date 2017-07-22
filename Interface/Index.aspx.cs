using System;

namespace Interface
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["field1"] != null)
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