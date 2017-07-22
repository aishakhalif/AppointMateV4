using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Interface
{
    public partial class WebForm20 : System.Web.UI.Page
    {




        SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["field1"] != null)
            {
                if (!IsPostBack) // Checks whether the page is being rendered for the first time or is being loaded in response to a postback
                {
                    // Clears items from the dropdown list
                    DropDownList2.Items.Clear();
                    DropDownList1.Items.Insert(0, "Please Select a Role");
                }


            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //checks that valid selections are made
            if (DropDownList1.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Invalid role selected')</script>");
            }

            if (DropDownList2.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Invalid Email Address Selected')</script>");
            }

            if (DropDownList3.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Invalid account status')</script>");
            }


            string convener = DropDownList1.SelectedItem.Value; //Declare convener as string with the selected email address in the first droopdownlist
            string organizer = DropDownList1.SelectedItem.Value;  //Declare organizer as string with the selected email address in the second droopdownlist
            string fromDropDownList3 = DropDownList3.SelectedItem.Value;
            bool status = false;

            if (fromDropDownList3.Equals("Inactive"))
            {
                status = false;
            }

            else
            {
                status = true;
            }

            if (convener.Equals("Convener"))
            {
                using (SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"))
                {

                    con.Open();
                    SqlCommand commandUpdateConvener = new SqlCommand("UPDATE Accounts SET Account_Status='" + status + "' WHERE Email_Address='" + DropDownList2.SelectedItem.Value + "'", con); //Update command to change the account status of the account on the Accounts table.

                    if (status == true)
                    {
                        string display = "Account successfully set to active!";
                        ClientScript.RegisterStartupScript(this.GetType(), " Account set to inactive", "alert('" + display + "');", true);
                    }

                    else if (status == false)
                    {
                        string display = "Account successfully set to inactive";
                        ClientScript.RegisterStartupScript(this.GetType(), " Account set to inactive", "alert('" + display + "');", true);
                    }

                    commandUpdateConvener.ExecuteNonQuery();
                    con.Close();
                }
            }

            else if (organizer.Equals("Organizer"))
            {
                using (SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"))
                {
                    con.Open();
                    SqlCommand commandUpdateOrganizer = new SqlCommand("UPDATE Accounts SET Account_Status = '" + status + "' WHERE Email_Address = '" + DropDownList2.SelectedItem.Value + "'", con); //Delete command to remove the selected organizer from the database

                    if (status == true)
                    {
                        string display = "Account successfully set to active";
                        ClientScript.RegisterStartupScript(this.GetType(), " Account set to inactive", "alert('" + display + "');", true);
                    }

                    else if (status == false)
                    {
                        string display = "Account successfully set to inactive";
                        ClientScript.RegisterStartupScript(this.GetType(), " Account set to inactive", "alert('" + display + "');", true);
                    }


                    commandUpdateOrganizer.ExecuteNonQuery();
                    con.Close();
                }
            }

            try
            {
                //This code sends the email notifying about the removal of the Account
                if (DropDownList1.SelectedItem.Text == "Convener")
                {
                    SmtpClient client = new SmtpClient("outlook.office365.com", 587);
                    client.EnableSsl = true;
                    SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    am.Open();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");
                    MailMessage mail = new MailMessage();
                    mail.To.Add(convener);
                    mail.Subject = " Account Set As Inactive ";
                    mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");
                    mail.Body = "Dear " + convener + "," + "\n  " + "Your convener account's status has been set to" + DropDownList3.SelectedItem.Value + ". \n Best Regards, \n Team Appoint Mate";
                    client.Send(mail);
                    am.Close();
                }

                else if (DropDownList1.SelectedItem.Text == "Organizer")
                {
                    SmtpClient client = new SmtpClient("outlook.office365.com", 587);
                    client.EnableSsl = true;
                    SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    am.Open();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");
                    MailMessage mail = new MailMessage();
                    mail.To.Add(organizer);
                    mail.Subject = " Account Removed From System ";
                    mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");
                    mail.Body = "Dear " + organizer + "," + "\n  " + "Your organizer account's status has been set to" + DropDownList3.SelectedItem.Value + ". \n Best Regards, \n Team Appoint Mate";
                    client.Send(mail);
                    am.Close();
                }




            }


            catch (Exception)
            {

            }

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                DropDownList2.Items.Clear(); //clears items from second dropdownlist
                DropDownList2.Items.Insert(0, "Please Select an Email Address");


                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");

                bool status = true;


                if (DropDownList1.SelectedItem.Text == "Convener")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Email_Address, Account_Status from Accounts where Role='Convener'", con); //Select command to get Email Addresses of the Organizer from the Accounts table where the Convener is the one selected in the dropdownlist 1
                    int i = 1;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1))
                            {
                               
                                    DropDownList2.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                    i++;
                                    status = reader.GetBoolean(1);
                            }
                            else
                            {
                                DropDownList2.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                i++;
                            }

                        }
                    }
                    con.Close();
                }

                else if (DropDownList1.SelectedItem.Text == "Organizer")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Email_Address, Account_Status from Accounts where Role='Organizer'", con); //Select command to get Email Addresses of the Organizer from the Accounts table where the Convener is the one selected in the dropdownlist 1
                    int i = 1;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1))
                            {
                                    DropDownList2.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                    i++;
                                    status = reader.GetBoolean(1);
                               
                            }
                            else
                            {
                                DropDownList2.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                i++;
                            }

                        }
                    }
                    con.Close();
                }


            }

            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                Response.Write("<script>alert('There is no organizer  linked with this Convener')</script>"); //If the Organizer Email is not available then this message will be displayed.


            }

            catch (SqlException)

            {
                Response.Redirect("CA_Error.aspx");

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                con.Open();
                SqlCommand sda = new SqlCommand("SELECT Last_Login, Account_Status FROM Accounts WHERE Email_Address ='" + DropDownList2.Text + "'", con);

                DateTime Last_Login = new DateTime();
                bool status = true;
                using (var reader = sda.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                        {
                            Last_Login = reader.GetDateTime(0);
                            status = reader.GetBoolean(1);
                            Label1.Text = Last_Login.ToString("dd/MM/yy");
                            if(status == false)
                            {
                                Label2.Text = "Inactive";
                            }
                            else if (status == true)
                            {
                                Label2.Text = "Active";
                            }
                        }
                        else
                        {
                            Label1.Text = "Account has no Login Data";
                            Label2.Text = "Active";
                        }
                    }
                }

            }

            catch (SqlException)
            {
                Response.Redirect("CA_Error.aspx");
            }

        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Session["field1"] = null;
            Response.Redirect("Login.aspx");

        }
    }
}
