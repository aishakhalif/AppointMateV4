using System;
using System.Data.SqlClient;

namespace Interface
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["field1"] != null) //checks if username stored after login is null
            {

                String fname = ""; //creates string and declare it as fname - First Name
                String lname = ""; //creates string and declare it as lname - Last Name
                String email = ""; //creates string and declare it as email - Email Address
                String role = ""; //creates string and declare it as role
                DateTime lastLogin = new DateTime(); //creates string and declare it as Last Login Date


                SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                am.Open();
                SqlCommand cmd_series = new SqlCommand("Select  First_Name, Last_Name, Email_Address, Role, Last_Login  from Accounts Where Email_Address = '" + Session["field1"] + "'", am); // Select command to get first name, last name, email address and role where the email address is of the one who is logged into the session.
                SqlDataReader read_data = cmd_series.ExecuteReader();
                while (read_data.Read())
                {
                    fname = read_data.GetString(0); //Read fname from the string
                    lname = read_data.GetString(1);
                    email = read_data.GetString(2);
                    role = read_data.GetString(3);
                    lastLogin = read_data.GetDateTime(4);
                    role_label.Text = read_data.GetString(3); //Put the read data in the label.
                    firstName_label.Text = read_data.GetString(0);
                    lastName_label.Text = read_data.GetString(1);
                    email_label.Text = read_data.GetString(2);
                    lastLogin_label.Text = lastLogin.ToString("dd/MM/yy");
                }
                read_data.Close();
                am.Close();



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