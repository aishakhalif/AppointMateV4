using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Interface
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool status = true;

                if (!IsPostBack) // Checks whether the page is being rendered for the first time or is being loaded in response to a postback
                {
                    DropDownList1.Items.Clear(); // Clears items from the dropdown list
                    DropDownList2.Items.Clear();

                    DropDownList1.Items.Insert(0, "Please select a convener...");
                    DropDownList2.Items.Insert(0, "Please select an organizer...");

                    SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Email_Address, Account_Status from Accounts where Role='Convener'", con); // Select command to get Email Addresses of Conveners
                    int i = 1;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1))
                            {
                                if (reader.GetBoolean(1) == true)
                                {
                                    DropDownList1.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                    i++;
                                    status = reader.GetBoolean(1);
                                }
                            }
                            else
                            {
                                DropDownList1.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                i++;
                            }

                        }
                    }

                    cmd = new SqlCommand("Select Email_Address, Account_Status from Accounts where Role='Organizer'", con); // Select command to get Email Addresses of Organizers
                    i = 1;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1))
                            {
                                if (reader.GetBoolean(1) == true)
                                {
                                    DropDownList2.Items.Insert(i, reader.GetString(0)); // Inserts Email Addresses into the dropdownlist
                                    i++;
                                    status = reader.GetBoolean(1);
                                }
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

            catch (SqlException)

            {
                Response.Redirect("CA_Error.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Invalid selections. Please select am appropiate convener and organizer.')</script>");
            }

            else
            {

                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                con.Open();
                string convener = DropDownList1.SelectedItem.Value; //Declare convener as string with the selected email address in the first droopdownlist
                string organizer = DropDownList2.SelectedItem.Value; //Declare organizer as string with the selected email address in the second droopdownlist
                SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Organizer_Email='" + organizer + "' WHERE Email_Address='" + convener + "'", con); //Update command to populate the Organizer Email column with the selected Organzier
                string display = "Accounts Linked Successfully";
                ClientScript.RegisterStartupScript(this.GetType(), "Accounts Linked Successfully", "alert('" + display + "');", true);
                cmd.ExecuteNonQuery();
                con.Close();

                /*
                try
                {
                    //This code sends the email notifying about the removal of the Organzier
                    SmtpClient client = new SmtpClient("outlook.office365.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");
                    MailMessage mail = new MailMessage();
                    mail.To.Add(organizer);
                    mail.Subject = " Organizer Removed ";
                    mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");
                    mail.Body = "Dear " + organizer + "," + "\n  " + "You have been linked as organizer for " + convener + ". \n Best Regards, \n Team Appoint Mate";
                    client.Send(mail);



                }


                catch (Exception)
                {

                }*/
            }
        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Session["field1"] = null;
            Response.Redirect("Login.aspx");

        }
    }


}