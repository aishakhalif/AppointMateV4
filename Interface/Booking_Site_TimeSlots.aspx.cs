using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Interface
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        DateTime dt;//declaring time slots 
        DateTime seriesDate;
        static DateTime selectedMeeting;


        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                if (!this.IsPostBack)
                {



                    avail.Items.Clear();
                    SqlConnection con = new SqlConnection(@"Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");// mysql connection 
                    string code = !string.IsNullOrEmpty(Request.QueryString["code"]) ? Request.QueryString["code"] : Guid.Empty.ToString();// splitting Series_ID and Attendee_ID from the One time link
                    code += "_";
                    string[] codes = code.Split('_');
                    Session["AID"] = codes[0];
                    Session["SID"] = codes[1];
                    con.Open();
                    string ad = codes[0];
                    string cd = codes[1];
                    String Status = "";
                    String invalid = "Invalid";


                    //check if series has already started/ended
                    SqlCommand series_cmd = new SqlCommand("Select Availability_Date_Time from Availability Where Series_ID = '" + cd + "'", con);
                    SqlDataReader series_reader = series_cmd.ExecuteReader(); //data reader

                    if (series_reader.Read())
                    {

                        seriesDate = series_reader.GetDateTime(0);

                    }

                    series_reader.Close();

                    //if the meeting date is on the same day as, or before, the current; a meeting cannot be cancelled/confirmed
                    if (seriesDate <= DateTime.Now)
                    {
                        Response.Redirect("OTLEXP.aspx");
                    }


                    else
                    {
                        //set the chosen field as 0, or false, if field is null at login
                        bool chosen = false;
                        DateTime AvailabilityDateTime = new DateTime();

                        SqlCommand chosenCheck = new SqlCommand("Select Chosen,  Availability_Date_Time from Availability where series_ID = '" + cd + "'", con);
                        SqlDataReader chosen_reader = chosenCheck.ExecuteReader();

                        while (chosen_reader.Read()) //this loop is to check the status of one time link
                        {
                            if (!chosen_reader.IsDBNull(0))
                            {
                                chosen = chosen_reader.GetBoolean(0);
                                //chosen_reader.Close();
                            }


                            else
                            {
                                AvailabilityDateTime = chosen_reader.GetDateTime(1);


                                //already open data reader error when the previous connection is used, so I put in a new connection and it worked
                                SqlConnection con2 = new SqlConnection(@"Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");// mysql connection 
                                con2.Open(); //open connection
                                SqlCommand updateChosen_cmd = new SqlCommand("UPDATE Availability SET Chosen = 0 WHERE Availability_Date_Time = '" + AvailabilityDateTime + "'AND Series_ID = '" + cd + "'", con2);
                                updateChosen_cmd.ExecuteNonQuery(); //execute update
                                con2.Close(); //close connection
                            }


                        }
                        chosen_reader.Close();

                        //check if one time link has already been used
                        SqlCommand otl = new SqlCommand("Select One_Time_Link_Status from Attendee where Attendee_ID = '" + ad + "'", con);
                        SqlDataReader otls = otl.ExecuteReader();
                        while (otls.Read())//this loop is to check the status of one time link
                        {
                            Status = otls.GetString(0);
                        }
                        otls.Close();

                        if (Status.Equals(invalid))// This statments redirects to one time link expired page if the status of One Time Link is invalid
                        {
                            Response.Redirect("OTLEXP.aspx");
                        }
                        else// if the status of One Time Link is Valid the page will load with timeslots 

                        {
                            SqlCommand cmd = new SqlCommand("Select Availability_Date_Time from Availability where Series_ID ='" + cd + "' AND chosen = 0", con);
                            int i = 1;
                            SqlDataReader reader = cmd.ExecuteReader();//this reader reads the timeslots 

                            avail.Items.Insert(0, "Select time..."); //default drop down selection

                            while (reader.Read())
                            {
                                dt = reader.GetDateTime(0);
                                avail.Items.Insert(i, dt.ToString());// storing the retrived timeslots
                                i++;
                            }
                            reader.Close();
                            con.Close();
                        }

                    }

                }

            }
            catch (SqlException)

            {
                Response.Redirect("AT_Error.aspx");
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e) //this is the code for Next Button
        {

            //make sure a time is selected in the list and not the default "Select Time..." 
            if (RadioButtonList1.SelectedIndex == 0 && avail.SelectedValue.StartsWith("Select"))
            {
                Response.Write("<script>alert('Please select the meeting time you wish to confirm.')</script>");
            }

            //check that a phone number is entered if phone meeting is selected
            else if (RadioButtonList1.SelectedIndex == 1 && number.Text == "")
            {

                Response.Write("<script>alert('Please enter a Telephone number.')</script>");
            }

            else
            {

                //try
                //{
                    SqlConnection con = new SqlConnection(@"Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    con.Open();
                    string av = avail.SelectedItem.Value;// converting the selected value from dropdown list to string 
                    dt = Convert.ToDateTime(av);


                    if (RadioButtonList1.SelectedValue.StartsWith("Default"))
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Meeting (Series_ID, Attendee_ID, Meeting_Date_Time, Mode, Status) Values ('" + Session["SID"] + "', '" + Session["AID"] + "', '" + dt.ToString(" yyyy-MM-dd hh:mm:ss tt") + "', ' Physical ' ,' Confirmed ') ", con); //Insert command to put the meeting details in the meeting table where the values are the SID and AID (Strings created)
                        cmd2.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO Meeting (Series_ID, Attendee_ID, Meeting_Date_Time, Mode, Status) Values ('" + Session["SID"] + "', '" + Session["AID"] + "', '" + dt.ToString(" yyyy-MM-dd hh:mm:ss tt") + "', ' Telephonic Meeting ' ,' Confirmed ') ", con);
                        cmd1.ExecuteNonQuery();
                        cmd1 = new SqlCommand("UPDATE Attendee SET Phone_Number='" + number.Text + "'  WHERE Attendee_ID = '" + Session["AID"] + "' ", con); //If telephonic meeting is selected then the phone number will be inserted in the database.
                        cmd1.ExecuteNonQuery();

                    }
                    SqlCommand cmd = new SqlCommand("DELETE from Availability WHERE Availability_Date_Time = '" + dt.ToString("yyyy-MM-dd hh:mm:ss tt") + "' ", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE Attendee SET One_Time_Link_Status='Invalid' WHERE Attendee_ID = '" + Session["AID"] + "' ", con); //Update attendee table with the OTL status
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SmtpClient client = new SmtpClient("outlook.office365.com", 587); // This process sends email
                    client.EnableSsl = true;
                    SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    am.Open();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");
                    String Attendee = "";
                    String fname = "";
                    String lname = "";
                    String ttl = "";
                    SqlCommand cmd_Email = new SqlCommand("Select Email_Address,  Title, First_Name, Last_Name from Attendee Where Attendee_ID = '" + Session["AID"] + "'", am);
                    SqlDataReader read_Email = cmd_Email.ExecuteReader();

                    while (read_Email.Read())
                    {

                        Attendee = read_Email.GetString(0);
                        ttl = read_Email.GetString(1);
                        fname = read_Email.GetString(2);
                        lname = read_Email.GetString(3);
                        MailMessage mail = new MailMessage();
                        mail.To.Add(Attendee);
                        mail.Subject = " Meeting has been confirmed ";
                        mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");
                        mail.Body = "Dear " + ttl + ". " + fname + " " + lname + "," + "\n \n" + "Your meeting has been confirmed on " + dt + "\n \n" + "Best Regards," + "\n" + "Team AppointMate.";
                        client.Send(mail);
                    }
                    read_Email.Close();

                    Response.Redirect("AT_Confirm.aspx");
                    am.Close();

                //}

                //catch (SqlException)

                //{
                    //Response.Redirect("AT_Error.aspx");
                //}
            }


        }


        protected void avail_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");// mysql connection 
            string code = !string.IsNullOrEmpty(Request.QueryString["code"]) ? Request.QueryString["code"] : Guid.Empty.ToString();// splitting Series_ID and Attendee_ID from the One time link
            code += "_";
            string[] codes = code.Split('_');
            Session["AID"] = codes[0];
            Session["SID"] = codes[1];
            con.Open();
            string ad = codes[0];
            string cd = codes[1];


            SqlConnection chosen = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
            chosen.Open();



            if (selectedMeeting == DateTime.MinValue)
            {

                selectedMeeting = Convert.ToDateTime(avail.SelectedValue.ToString());

                SqlCommand choice_cmd = new SqlCommand("UPDATE Availability SET Chosen = 1 WHERE Series_ID = '" + cd + "' AND Availability_Date_Time = '" + selectedMeeting.ToString("yyyy-MM-dd hh:mm:ss tt") + "' ", chosen);
                choice_cmd.ExecuteNonQuery();

            }

            else
            {
                DateTime previousChoice = selectedMeeting;
                DateTime newChoice = Convert.ToDateTime(avail.SelectedValue.ToString());

                //once a new meeting is selected, set the previous meeting chosen as 0, or false.
                SqlCommand previousChoice_cmd = new SqlCommand("UPDATE Availability SET Chosen = 0 WHERE Series_ID = '" + cd + "' AND Availability_Date_Time = '" + previousChoice.ToString("yyyy-MM-dd hh:mm:ss tt") + "' ", chosen);
                previousChoice_cmd.ExecuteNonQuery();

                //once a meeting is selected, set the chosen as 1, or true.
                SqlCommand newChoice_cmd = new SqlCommand("UPDATE Availability SET Chosen = 1 WHERE Series_ID = '" + cd + "' AND Availability_Date_Time = '" + newChoice.ToString("yyyy-MM-dd hh:mm:ss tt") + "' ", chosen);
                newChoice_cmd.ExecuteNonQuery();
            }

            chosen.Close();
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Booking_Site_Cancel.aspx");
        }
    }

}

