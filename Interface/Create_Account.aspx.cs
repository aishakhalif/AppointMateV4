using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Interface
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        //Connection to the Database
        SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["field1"] != null)//checks if username stored after login is null
            {
                Session["field1"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");//if username session feild is null the system redirects to login page
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Check if the email entered is already in the system
            SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
            con.Open();
            Session["field1"] = txtEmail_Address.Text;
            Int32 email = 0;
            SqlCommand email_command = new SqlCommand("Select count(Email_Address) from Accounts where Email_Address='" + txtEmail_Address.Text + "'", con); // return how many times that email appears in the accounts table
            SqlDataReader reader = email_command.ExecuteReader();
            while (reader.Read())
            {
                email = reader.GetInt32(0);
            }

            reader.Close();

            

            


            if (DropDownList1.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Please select a role.')</script>");
            }
            else

            {
                // if the count is not 0, email cannot be used.
                if (email != 0)
                {

                    Response.Write("<script>alert('An account with that email already exists. Please enter another email.')</script>");
                }

            else
                {
                    try
                    {
                        //con.Open(); // Opens the connection

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Accounts (Email_Address, Password, First_Name, Last_Name, Role) values('" + txtEmail_Address.Text + "','" + txtPassword.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + DropDownList1.Text + "')"; //Takes the values entered in the text boxes and inserts them into Accounts table
                        string display = "Account Created Successfully"; // Declaring display as string
                        ClientScript.RegisterStartupScript(this.GetType(), "Account Created Successfully", "alert('" + display + "');", true); // The popup code for Account Creation using the string
                        cmd.ExecuteNonQuery();
                        SmtpClient client = new SmtpClient("outlook.office365.com", 587);
                        client.EnableSsl = true;
                        //Declare SQL Connenction
                        SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                        am.Open();
                        //This part of code emails the user who's account is created with their credentials
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");
                        MailMessage mail = new MailMessage();
                        mail.To.Add(txtEmail_Address.Text);
                        mail.Subject = " Account Created ";
                        mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");
                        mail.Body = "Dear " + txtFirstName.Text + " " + txtLastName.Text + "," + "\n  " + " Your account on AppointMate V4 as a " + DropDownList1.Text + "has been created. Please find your account details below:\n USERNAME: " + txtEmail_Address.Text + "\n Password:" + txtPassword.Text + "\n Best Regards, \n Team AppointMate";
                        client.Send(mail);
                        am.Close();

                        txtEmail_Address.Text = "";
                        txtPassword.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        DropDownList1.SelectedIndex = 0;

                        con.Close();
                    }


                    catch (SqlException)
                    {
                        Response.Redirect("CA_Error.aspx");
                    }
                }

                
            }
        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Session["field1"] = null;
            Response.Redirect("Login.aspx");

        }

        protected void txtEmail_Address_TextChanged(object sender, EventArgs e)
        {
           

        }
    }
}

