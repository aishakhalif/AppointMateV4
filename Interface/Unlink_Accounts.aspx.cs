using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Interface
{
    public partial class WebForm8 : System.Web.UI.Page
    {




        SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["field1"] != null)
            {
                if (!IsPostBack) // Checks whether the page is being rendered for the first time or is being loaded in response to a postback
                {

                    DropDownList1.Items.Clear(); // Clears items from the dropdown list
                    DropDownList2.Items.Clear();

                    DropDownList1.Items.Insert(0, "Please select a convener...");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Email_Address from Accounts where Role='Convener'", con); //Select command to get Email Addresses of the Conveners from the Accounts table
                    int i = 1;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) //Read from the reader
                        {
                            DropDownList1.Items.Insert(i, reader.GetString(0)); //Insert and populate the dropdownlist
                            i++;
                        }
                    }
                    con.Close();
                }


            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Invalid selection. Please select a convener.')</script>");
            }


            else
            {
                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                con.Open();
                string convener = DropDownList1.SelectedItem.Value; //Declare convener as string with the selected email address in the first droopdownlist
                string organizer = DropDownList2.SelectedItem.Value;  //Declare organizer as string with the selected email address in the second droopdownlist
                SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Organizer_Email=NULL WHERE Email_Address='" + convener + "'", con); //Update command to set the Organizer Email column as Null where the Convener is the one selected in the first dropdownlist
                string display = "Organizer Removed Successfully";
                ClientScript.RegisterStartupScript(this.GetType(), " Organizer Removed", "alert('" + display + "');", true);
                cmd.ExecuteNonQuery();

                con.Close();

                /*try
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
                    mail.Body = "Dear " + organizer + "," + "\n  " + "You have been removed from being an Organizer of " + convener + ". \n Best Regards, \n Team Appoint Mate";
                    client.Send(mail);



                }


                catch (Exception)
                {

                }*/
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList2.Items.Clear(); //clears ites from second dropdownlist
                string convener = DropDownList1.SelectedValue;

                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                
                if (DropDownList1.SelectedIndex == 0)
                {
                    Response.Write("<script>alert('Invalid Convener Selected')</script>");
                }

                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Organizer_Email from Accounts where Email_Address='" + convener + "'", con); //Select command to get Email Addresses of the Organizer from the Accounts table where the Convener is the one selected in the dropdownlist 1
                    int i = 0;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DropDownList2.Items.Insert(i, reader.GetString(0)); // Insert and populate the dropdownlist
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

        protected void logout_Click1(object sender, EventArgs e)
        {
            Session["field1"] = null;
            Response.Redirect("Login.aspx");

        }
    }
}
