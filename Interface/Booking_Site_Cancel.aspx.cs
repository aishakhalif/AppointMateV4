using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Interface
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                String Status = "";//declaring status as string
                String invalid = "Invalid";// declaring invalid as string, set value is Invalid
                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//declaring sql connction string as con
                con.Open();//opening sql connection
                SqlCommand otl = new SqlCommand("Select One_Time_Link_Status from Attendee where Attendee_ID = '" + Session["AID"] + "'", con);// declaring sql query to check one time link status as otl
                SqlDataReader otls = otl.ExecuteReader();//declaring otls as data reader
                while (otls.Read())// opening reader
                {
                    Status = otls.GetString(0);// storing one time link status in string

                }
                con.Close();//closing sql connection
                otls.Close();//closing data reader 
                if (Status.Equals(invalid))//condition to check if one time link status is invalid
                {
                    Response.Redirect("OTLEXP.aspx");// reidrecting to one time link expired page
                }
                else// executing the page further if one time link status is not invalid

                { }

         
        }

        protected void Button1_Click(object sender, EventArgs e)//cancel button
        {



            try
            {

                if (String.IsNullOrEmpty(reason.Text))//checking if reason text box is empty

                { Label1.Text = "You must provide a reason to proceed"; }// displaying error message

                else
                {
                    SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//declaring sql connection string as con
                    con.Open();//opening conection
                    string aid = (string)Session["AID"];//declaring session AID as aid
                    string sid = (string)Session["SID"];//declaring session SID as sid


                    //set any fields they might have before they cancelled to not chosen
                    SqlCommand updateChosen_cmd = new SqlCommand("UPDATE Availability SET Chosen = 0 WHERE Series_ID = '" + sid + "'", con);
                    updateChosen_cmd.ExecuteNonQuery(); //execute update
                    

                    //update as cancelled
                    SqlCommand cmd = new SqlCommand("INSERT INTO Meeting (Series_ID, Attendee_ID, Status, Cancellation_Reason) Values ('" + sid + "', '" + aid + "', ' Cancelled ' , ' " + reason.Text + " ') ", con);//declaring sql query as cmd
                    cmd.ExecuteNonQuery();//executing query
                    cmd = new SqlCommand("UPDATE Attendee SET One_Time_Link_Status='Invalid' WHERE Attendee_ID = '" + Session["AID"] + "' ", con);//sql query
                    cmd.ExecuteNonQuery();//executing query
                    con.Close();//closing connection
                    SmtpClient client = new SmtpClient("outlook.office365.com", 587); //declaring client as smtp cleint
                    client.EnableSsl = true;//enabling SSL
                    SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");// declaring sql connection string as am
                    am.Open();//opening connection
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;//declaring delivery method
                    client.UseDefaultCredentials = false;// disabling default credentials
                    client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");// sender credentials
                    String Attendee = "";//declaring Attendee as string
                    String fname = "";//declaring fname as string
                    String lname = "";//declaring lname as string
                    String ttl = "";//declaring ttl as string
                    SqlCommand cmd_Email = new SqlCommand("Select Email_Address,  Title, First_Name, Last_Name from Attendee Where Attendee_ID = '" + Session["AID"] + "'", am);//declaring sql query as cmd email
                    SqlDataReader read_Email = cmd_Email.ExecuteReader();//declaring read_Email as  data reader

                    while (read_Email.Read())// data reader open
                    {
                        Attendee = read_Email.GetString(0);// storing attende Email address from attendee table as string
                        ttl = read_Email.GetString(1);// storing attende Title from attendee table as string
                        fname = read_Email.GetString(2);// storing attende First name from attendee table as string
                        lname = read_Email.GetString(3);// storing attende Last namefrom attendee table as string
                        MailMessage mail = new MailMessage();// declaring mail as mail message
                        mail.To.Add(Attendee);// adding attendee string to email email recipient
                        mail.Subject = " Your meeting has been Cancelled Successfully ";// email subject
                        mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");//email sender
                        mail.Body = "Dear " + ttl + " " + fname + " " + lname + "," + "\n  " + " Your request to cancel the meeting has been confirmed successfully because of reason: \n" + reason.Text + ". \n Best Regards, \n Team Appoint Mate";//email body
                        client.Send(mail);//sending emial
                    }
                    read_Email.Close();
                    SqlCommand conveneraddress = new SqlCommand("Select Email_Address from Series Where Series_ID = '" + Session["SID"] + "'", am);
                    String convener_email = "";
                    SqlDataReader c_mail = conveneraddress.ExecuteReader() ;
                    while (c_mail.Read())

                    {
                        convener_email = c_mail.GetString(0);

                    }
                    c_mail.Close();

                    MailMessage convener = new MailMessage() ;
                    convener.To.Add(convener_email);
                    convener.Subject = "Meeting request cancelled"; // email subject
                    convener.From = new MailAddress("project_ict333@murdochdubai.ac.ae");//email sender
                    convener.Body = "Dear Convener,"+"\n " + ttl + " " + fname + " " + lname +  " has declined your meeting invitation because of the following reason: \n" + reason.Text + ". \n Best Regards, \n Team Appoint Mate";//email body
                    client.Send(convener);//sending emial


                    Response.Redirect("AT_Confirm.aspx");//redirecting to confirmation page
                    am.Close();//closing connection

                }

            }

            catch (SqlException)// sql exception

            {
                Response.Redirect("AT_Error.aspx");// redirecting to error page if exception occurs
            }
        }
    }
}
