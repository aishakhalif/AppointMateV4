using System;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Net.Mail;




namespace Interface
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        String Prefix;// declaring prefix as string
        String Message;//declaring message as string
        String Location;//declaring locaiton as string 
        String SEmail = "";//declaring SEmail as string
        String Senderfname = "";//declaring Senderfname as string 
        String Senderlname = "";//declaring Senderlname as string 
        Int32 MinSlot = 0;//delaring MinSlot as integer, initial value 0
        Int32 Mduration = 0;//declaring Mduration as integer, initial value 0

        protected void Page_Load(object sender, EventArgs e)//page load
        {
            try
            {

                if (Session["field1"] != null)//checking if session variable is not empty 
                {
                    SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//sql connection string
                    am.Open();//opening sql connection
                    SqlCommand cmd_series = new SqlCommand("Select  Series_Title, Series_Message, Series_Location, Meeting_Duration from Series Where Series_ID = '" + (int)Session["SID"] + "'", am);//declaring my sql command as cmd
                    SqlDataReader read_data = cmd_series.ExecuteReader();//declaring sql data reader for cmd
                    while (read_data.Read())//opening data reeader
                    {
                        Prefix = read_data.GetString(0);//gettiing series title from database and storing it into a string
                        Message = read_data.GetString(1);//getting series message from database and storing it into a string
                        Location = read_data.GetString(2);//getting locatoin of series from database and storing it into a string
                        Mduration = read_data.GetInt32(3);//getting duration of each meeting from database and storing it into an integer
                        Label1.Text = read_data.GetString(0);// displaying series title to label
                        Label4.Text = read_data.GetString(1);//displaying series message to label
                        Label2.Text = read_data.GetString(2);//displaying series location to label 
                    }
                    read_data.Close();// closing data reader
                    am.Close();//closing sql connection 
                    SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//sql connectoin string
                    con.Open();//opening sql connectoin 
                    SqlCommand AIDCOUNT = new SqlCommand("Select  count(Attendee_ID) from Attendee Where Series_ID = '" + (int)Session["SID"] + "'", con);//declaring sql command as AIDCOUNT
                    SqlDataReader read_data1 = AIDCOUNT.ExecuteReader();// declare my data reader
                    while (read_data1.Read())// open data reader
                    {
                        MinSlot = read_data1.GetInt32(0);// storing count of rows as integer
                    }

                    Int32 duraiton = Convert.ToInt32(Mduration);// converting duration as integer
                    int tduraion = MinSlot * duraiton;// multiplying number of attendees with duration
                    String fduration = Convert.ToString(tduraion);// converting the product to string 
                    Label3.Text = fduration;// displaying fduration in label 3
                    read_data1.Close();// close data reader
                    String accounttype = "";//declaring accounttype as string

                    SqlCommand atype = new SqlCommand("Select  Role from Accounts Where Email_Address = '" + Session["field1"] + "'", con);//declaring accounttype as my sql command
                    SqlDataReader tdata = atype.ExecuteReader();// declaring tdata as my data reader
                    while (tdata.Read())// opening data reader
                    {
                        accounttype = tdata.GetString(0);// stroing account type in string 

                    }
                    tdata.Close();//closing data reader

                    if (accounttype == "Organizer")// checking if account type is organizer

                    {
                        String conmail = "";// declaring conmail as string
                        String orgname = "";//declaring orgname as string
                        String orglname = "";//declaring orglname as string
                        SqlCommand oat = new SqlCommand("Select  Email_Address, First_Name, Last_name from Accounts Where Organizer_Email = '" + Session["field1"] + "'", con);// declaring my sql query as oat
                        SqlDataReader oats = oat.ExecuteReader();// declaring data reader as oats
                        while (oats.Read())// opening data reader
                        {
                            conmail = oats.GetString(0);// getting convener email and stroing into string 
                            orgname = oats.GetString(1);// getting convener first name and stroing into string
                            orglname = oats.GetString(2);// getting convener Last name and stroing into string
                        }
                        SEmail = conmail;// storing string values into common stirng
                        Senderfname = orgname;// storing string values into common stirng
                        Senderlname = orglname;// storing string values into common stirng
                    }


                    else {
                        String Convenerfname = "";// declaring Convenerfname as string
                        String Convenerlname = "";//declaring Convenerlname as string
                        SqlCommand conname = new SqlCommand("Select First_Name, Last_name from Accounts Where Email_Address = '" + Session["field1"] + "'", con);// declaring my sql query as conname
                        SqlDataReader connameexec = conname.ExecuteReader();// declaring my sql reader as connameexec
                        while (connameexec.Read())//opnening data reader
                        {
                            Convenerfname = connameexec.GetString(0);// storing conveners first name in string
                            Convenerlname = connameexec.GetString(1);//storing conveners last name in string

                        }

                        SEmail = Session["field1"].ToString();//stroing username used for login as SEmail
                        Senderfname = Convenerfname;//stroing convener first name as Senderfname
                        Senderlname = Convenerlname;//storing convener last name as a Senderlname
                        connameexec.Close();// closing data reader

                    }


                    con.Close();// closing sql connection
                }
                else
                {
                    Response.Redirect("login.aspx");// if login session is empty redirecting to login page
                }

            }
            catch (SqlException)

            {
                Response.Redirect("Error.aspx");

            }
        }



        protected void Button1_Click(object sender, EventArgs e)//confirm button
        {
            try
            {
                SmtpClient client = new SmtpClient("outlook.office365.com", 587);// declaring my smtp client as client
                client.EnableSsl = true;//enableing SSL 
                SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//declaring my sql connection string as am
                am.Open();//sql connection open
                client.DeliveryMethod = SmtpDeliveryMethod.Network;// declaring delivery method 
                client.UseDefaultCredentials = false;// declaring use of defaul credentials as false
                client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");//my cradentials for sender email
                String email = "";//declaring email as string
                int AID = 0;// declaring AID as integer, initial value 0
                String title1 = "";// declaring title 1 as string
                String fname = "";//declaring fname as string
                String lname = "";//declaring lname as string 
                SqlCommand cmd_Email = new SqlCommand("Select Email_Address, Attendee_ID, Title, First_Name, Last_Name from Attendee Where Series_ID = '" + (int)Session["SID"] + "'", am);// declaring sql query as cmd_email
                SqlDataReader read_Email = cmd_Email.ExecuteReader();//declaring read_email as data reader
                while (read_Email.Read())//opening data reader
                {

                    email = read_Email.GetString(0);// storing Attende Email as string
                    AID = read_Email.GetInt32(1);// storing Attende ID as Integer
                    title1 = read_Email.GetString(2);// storing Attende Title as string
                    fname = read_Email.GetString(3);// storing Attende First Name as string
                    lname = read_Email.GetString(4);// storing Attende Last Name as string
                    MailMessage mail = new MailMessage();//declaring mail as mail message
                    mail.To.Add(email);// adding email addresses stored in string to email recepients 
                    mail.Subject = Prefix + " Location: " + Location;// adding Series title and location stored in strings as email Subject
                    mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");// stating Senders Email
                    mail.Body = "Dear " + title1 + ". " + fname + " " + lname + "," + "\n \n "+Senderfname + " " + Senderlname + " has invited you for a meeting for the folowing reason: \n \n" + Message + "\n \n " + "Please click on the following link to confirm or cancel this meeting request. " + "\n \n" + "http://appointmateversion4.azurewebsites.net/Booking_Site_TimeSlots?code=" + AID + "_" + (int)Session["SID"] + "\n \n Best Regards, \n Team AppointMate";// message body with One time link, Title, first name and last name of each attendee, Series message and name of Convener
                    client.Send(mail);// sending emails
                }

                am.Close();//closing sql connection
                SmtpClient Cclient = new SmtpClient("outlook.office365.com", 587);// declaring Cclient as my smtp client
                Cclient.EnableSsl = true;// Enabling SSL
                Cclient.DeliveryMethod = SmtpDeliveryMethod.Network;// declaring deliverymethod
                Cclient.UseDefaultCredentials = false;// declaring default cradentials as false
                Cclient.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");//providing cradentials for Cclient
                SqlConnection ab = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//sql connection string ab
                ab.Open();// sql connectoin open
                SqlCommand cmd_ava = new SqlCommand("Select  Availability_Date_Time from Availability Where Series_ID = '" + (int)Session["SID"] + "'", ab);// declaring sql query as cmd_ava
                SqlDataReader read_dt = cmd_ava.ExecuteReader();//devlaring read_dt as data Reader
                DateTime dt;// declaring dt as date time
                while (read_dt.Read())// open reader
                {
                    dt = read_dt.GetDateTime(0);// storing avalbility date and time from Availability table to string
                    DateTime start = Convert.ToDateTime(dt);// converting dt to date time
                    TimeSpan increment = new TimeSpan(0, Mduration, 0);// Converting duration of meeting to 
                    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);// declaring tzi as timezone which is found by systems timezone ID
                    DateTime startDateTime = TimeZoneInfo.ConvertTimeToUtc(dt, tzi);// converting timezone from utc to localtime
                    DateTime End = startDateTime.Add(increment);// adding duration of meeting to start time to get the end time of the meeting
                    MailMessage Cmsg = new MailMessage();//declaring Cmsg as mail message
                    Cmsg.From = new MailAddress("project_ict333@murdochdubai.ac.ae");// declaring the senders email
                    Cmsg.To.Add(new MailAddress(SEmail));// adding recipients email
                    Cmsg.Subject = Title + "Confirmation";// adding series title to email subject
                    Cmsg.Body = "Dear Client, \n \n Your meeting request has been sent successfully."; //email body
                    StringBuilder str = new StringBuilder();// declaring str as string builder
                    str.AppendLine("BEGIN:VCALENDAR");
                    str.AppendLine("PRODID:-//ABC Company//Outlook MIMEDIR//EN");
                    str.AppendLine("VERSION:2.0");
                    str.AppendLine("METHOD:REQUEST");//sending method
                    str.AppendLine("BEGIN:VEVENT");
                    str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startDateTime));//start time of calendar request 
                    str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));//timezone
                    str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", End));//end time of calendar request
                    str.AppendLine(string.Format("LOCATION: {0}", "Location"));
                    str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
                    str.AppendLine(string.Format("DESCRIPTION:{0}", Cmsg.Body));
                    str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", Cmsg.Body));
                    str.AppendLine(string.Format("SUMMARY:{0}", Cmsg.Subject));
                    str.AppendLine("STATUS:CONFIRMED");
                    str.AppendLine("BEGIN:VALARM");
                    str.AppendLine("TRIGGER:-PT15M");
                    str.AppendLine("ACTION:Accept");
                    str.AppendLine("DESCRIPTION:Reminder");
                    str.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:BUSY");
                    str.AppendLine("END:VALARM");
                    str.AppendLine("END:VEVENT");
                    str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", Cmsg.From.Address));
                    str.AppendLine("END:VCALENDAR");
                    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("text/calendar");
                    ct.Parameters.Add("method", "REQUEST");
                    ct.Parameters.Add("name", "meeting.ics");
                    AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), ct);
                    Cmsg.AlternateViews.Add(avCal);
                    Cclient.ServicePoint.MaxIdleTime = 2;
                    Cclient.Send(Cmsg);//sending calendar request
                }

                Session["SID"] = "";//clearing session variable to end the series
                ab.Close();// closing sql connection
                Response.Redirect("Index.aspx");//redirecting to home page
            }

            catch (SqlException)//sql exception

            {
                Response.Redirect("Error.aspx");//redirecting to error page if esception occours
            }

        }

        protected void logout_Click1(object sender, EventArgs e)//logout button
        {
            Session["field1"] = null;//clearing session feild one to prevent access without login
            Response.Redirect("Login.aspx");//redirecting to login page

        }
    }

}

