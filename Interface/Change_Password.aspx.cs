using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Interface
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                con.Open();
                SqlCommand sda = new SqlCommand("SELECT Password FROM Accounts WHERE Password = '" + TextBox1.Text + "'", con); //Select command to get password from Accounts where the entered password matches the one entered in the Text box
                string dt = ""; //declare dt as spring
                SqlDataReader otls = sda.ExecuteReader();
                while (otls.Read())//this loop is to check the status of one time link
                {
                    dt = otls.GetString(0);
                }
                otls.Close();
                if (dt == TextBox1.Text) // IF Command to check if the string dt = Text box entered value
                {
                    if (TextBox2.Text == TextBox3.Text) //IF command to check if the new password and the confirm new password text boxes entered values match
                    {

                        SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Password = '" + TextBox3.Text + "' WHERE Email_Address = '" + Session["field1"] + "'", con); //Update command to change the password of the email address who is logged into the session with the value entered in the third text box.
                        cmd.ExecuteNonQuery();

                        con.Close();
                        Label1.Text = "Successfully Updated"; //Message of Successful updation
                    }
                    else
                    {
                        Label1.Text = "Passwords do not match."; //message if new passwords don't match
                    }
                }
                else
                {
                    Label1.Text = "Current password incorrect"; //if the current password does not match with the one in the database.
                }
            }
            catch (SqlException)

            {
                Response.Redirect("Error.aspx");

            }
        }
        protected void logout_Click1(object sender, EventArgs e)
        {

            Session["field1"] = null;//clears the username from session field to prevent access without login
            Response.Redirect("Login.aspx");//redirects to login page
        }


    }

}

