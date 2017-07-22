using System;
using System.Data.SqlClient;
using System.Collections;

namespace Interface
{
    public partial class Calendar : System.Web.UI.Page
    {

        static ArrayList seriesIDs = new ArrayList();

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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ConfirmedMeetings.Items.Clear(); //Clear the drop down list everytime a new date is selected

            seriesIDs.Clear(); //Clear the array everytime a new date is selected



            //clear all the fields

            MeetingTitleTxtbox.Text = "";
            AttendeeName.Text = "";
            annotationsbox.Text = "";

            // filling the Date and Time textbox whenever date on calender is selected
            // clear textbox whenever a new date is selected then fill textbox with the date and time selected on the calendar
            MeetingDate.Text = string.Empty;
            MeetingDate.Text = Calendar1.SelectedDate.Date.ToString("dd/MM/yy");


            //get the role of the user currently logged in
            SqlConnection role_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
            role_con.Open();

            String role = ""; // declaring the string role

            SqlCommand role_cmd = new SqlCommand("Select Role from Accounts Where Email_Address = '" + Session["field1"] + "'", role_con);
            SqlDataReader role_reader = role_cmd.ExecuteReader(); //data reader for checking the account role

            while (role_reader.Read())
            {

                role = role_reader.GetString(0);

            }

            role_reader.Close();

            // check if they linked or unlinked

            if (role == "Organizer") //if the logged in user is a organiser, get the convener
            {
                Int32 unlinked = -1; //declaring unlinked organiser as int -1

                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//declaring sql connction string as con
                con.Open(); //opening sql connection


                //sql command to get how many times the current email appears in the "Organizer_Email" coloumn
                SqlCommand uo_command = new SqlCommand("Select count(Organizer_Email) from Accounts where Organizer_Email ='" + Session["field1"] + "'", con);
                SqlDataReader uo_reader = uo_command.ExecuteReader(); //declaring the data reader

                while (uo_reader.Read())// opening reader
                {
                    unlinked = uo_reader.GetInt32(0);

                }

                uo_reader.Close(); //closing data reader 

                // if the count is 0, the organiser in unliked
                if (unlinked != 0)
                {

                    string convener = "";

                    SqlCommand getConvener_cmd = new SqlCommand("Select  Email_Address from Accounts Where Organizer_Email = '" + Session["field1"] + "'", role_con);// get the conveners email
                    SqlDataReader getConvener_reader = getConvener_cmd.ExecuteReader();// declaring data reader
                    while (getConvener_reader.Read())// opening data reader
                    {
                        convener = getConvener_reader.GetString(0);// getting convener email and stroing into string 
                    }


                    // filling the confirmed appointments drop down list
                    SqlConnection meeting_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    meeting_con.Open();

                    int seriesID = 0;
                    DateTime meetingDateTime = new DateTime();
                    string meetingStatus = "";


                    ConfirmedMeetings.Items.Insert(0, "Select a meeting...");
                    int j = 1;

                    SqlCommand meeting_cmd = new SqlCommand("Select Series_ID from Series Where Email_Address = '" + convener + "'", meeting_con);
                    SqlDataReader meeting_reader = meeting_cmd.ExecuteReader();

                    while (meeting_reader.Read())
                    {
                        seriesID = meeting_reader.GetInt32(0);
                        seriesIDs.Add(seriesID);
                    }

                    meeting_reader.Close();

                    //getting meeting date and time
                    SqlCommand meeting2_cmd;
                    SqlDataReader meeting2_reader;

                    foreach (int i in seriesIDs)
                    {
                        meeting2_cmd = new SqlCommand("Select Meeting_Date_Time, Status from Meeting Where Series_ID = '" + i + "'", meeting_con);
                        meeting2_reader = meeting2_cmd.ExecuteReader();


                        while (meeting2_reader.Read())
                        {
                            if (!meeting2_reader.IsDBNull(0))
                            {

                                meetingDateTime = meeting2_reader.GetDateTime(0);
                                meetingStatus = meeting2_reader.GetString(1);

                                if ((meetingDateTime.Date == Calendar1.SelectedDate.Date) && (meetingStatus != "Cancelled"))
                                {
                                    ConfirmedMeetings.Items.Insert(j, meetingDateTime.ToString());
                                    j++;
                                }
                            }
                        }

                        meeting2_reader.Close();

                    }
                }

                else {

                    Response.Write("<script>alert('Please note that there is no meeting information available to unlinked organizers.')</script>");

                }
            }

            else if (role == "Convener")
            {


                // filling the confirmed appointments drop down list
                SqlConnection meeting_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                meeting_con.Open();

                int seriesID = 0;
                DateTime meetingDateTime = new DateTime();
                string meetingStatus = "";


                ConfirmedMeetings.Items.Insert(0, "Select a meeting...");
                int j = 1;

                SqlCommand meeting_cmd = new SqlCommand("Select Series_ID from Series Where Email_Address = '" + Session["field1"] + "'", meeting_con);
                SqlDataReader meeting_reader = meeting_cmd.ExecuteReader();

                while (meeting_reader.Read())
                {
                    seriesID = meeting_reader.GetInt32(0);
                    seriesIDs.Add(seriesID);
                }

                meeting_reader.Close();

                //getting meeting date and time
                SqlCommand meeting2_cmd;
                SqlDataReader meeting2_reader;

                foreach (int i in seriesIDs)
                {
                    meeting2_cmd = new SqlCommand("Select Meeting_Date_Time, Status from Meeting Where Series_ID = '" + i + "'", meeting_con);
                    meeting2_reader = meeting2_cmd.ExecuteReader();


                    while (meeting2_reader.Read())
                    {
                        if (!meeting2_reader.IsDBNull(0))
                        {

                            meetingDateTime = meeting2_reader.GetDateTime(0);
                            meetingStatus = meeting2_reader.GetString(1);

                            if ((meetingDateTime.Date == Calendar1.SelectedDate.Date) && (meetingStatus != "Cancelled"))
                            {
                                ConfirmedMeetings.Items.Insert(j, meetingDateTime.ToString());
                                j++;
                            }
                        }
                    }

                    meeting2_reader.Close();

                }
            }

        }



        protected void logout_Click1(object sender, EventArgs e)
        {

            Session["field1"] = null;//clears the username from session field to prevent access without login
            Response.Redirect("Login.aspx");//redirects to login page


        }

        protected void ConfirmedMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ConfirmedMeetings.SelectedValue.StartsWith("Select"))
            {
                Response.Write("<script>alert('Please select the meeting time you wish to confirm.')</script>");
            }

            else
            {
                //getting attendee ID from meeting table
                int attendeeID = 0;
                DateTime selectedMeeting = Convert.ToDateTime(ConfirmedMeetings.SelectedValue.ToString()); //convert the string selected from the drop down to DateTime format
                int seriesID = 0;

                SqlConnection selectedMeeting_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
                selectedMeeting_con.Open(); // opening the sql connection
                SqlCommand selectedMeeting_cmd = new SqlCommand("Select Attendee_ID, series_ID from Meeting Where Meeting_Date_Time = '" + selectedMeeting.ToString(" yyyy-MM-dd hh:mm:ss tt") + "'", selectedMeeting_con); // sql query to select attendee ID from the Meeting Table
                SqlDataReader read_aID = selectedMeeting_cmd.ExecuteReader(); //sql data reader
                while (read_aID.Read()) //opening sql data reader
                {
                    attendeeID = read_aID.GetInt32(0);
                    seriesID = read_aID.GetInt32(1);
                }

                read_aID.Close();



                //getting First name and last name from Attendee table
                string firstName = "";
                string lastName = "";

                SqlConnection aName_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
                aName_con.Open(); // opening the sql connection

                SqlCommand aName_cmd = new SqlCommand("Select First_Name, Last_Name from Attendee Where Attendee_ID = '" + attendeeID + "'", aName_con); // sql query to select attendee first and last name from Atrendee table
                SqlDataReader read_aName = aName_cmd.ExecuteReader(); //sql data reader
                while (read_aName.Read()) //opening sql data reader
                {
                    firstName = read_aName.GetString(0);
                    lastName = read_aName.GetString(1);
                }

                read_aName.Close();


                // clear textbox whenever a new meeting is selected
                // filling the Student Name textbox with students first and last name
                AttendeeName.Text = string.Empty;
                AttendeeName.Text = firstName + " " + lastName;

                //selecting the annotation from the meeting table
                string annotation = "";

                SqlConnection annotation_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
                annotation_con.Open(); // opening the sql connection
                SqlCommand annotation_cmd = new SqlCommand("Select Annotation from Meeting Where Meeting_Date_Time = '" + selectedMeeting.ToString(" yyyy-MM-dd hh:mm:ss tt") + "'", annotation_con); // sql query to select Annotation from the Meeting Table
                SqlDataReader read_annotation = annotation_cmd.ExecuteReader(); //sql data reader
                while (read_annotation.Read()) //opening sql data reader
                {
                    if (!read_annotation.IsDBNull(0))
                    {
                        annotation = read_annotation.GetString(0);
                        annotationsbox.Text = annotation;
                    }

                    else
                    {
                        annotationsbox.Text = "Add Annotation...";
                    }

                }

                read_annotation.Close();

                string meetingTitle = "";
                SqlConnection title_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
                title_con.Open(); // opening the sql connection
                SqlCommand title_cmd = new SqlCommand("Select Series_title from Series Where Series_ID = '" + seriesID + "'", title_con); // sql query to select Annotation from the Meeting Table
                SqlDataReader read_title = title_cmd.ExecuteReader(); //sql data reader
                while (read_title.Read()) //opening sql data reader
                {
                    meetingTitle = read_title.GetString(0);
                    MeetingTitleTxtbox.Text = meetingTitle;
                }


            }
        }


        protected void MeetingDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            //getting attendee ID from meeting table
            int attendeeID = 0;
            DateTime selectedMeeting = Convert.ToDateTime(ConfirmedMeetings.SelectedValue.ToString()); //convert the string selected from the drop down to DateTime format


            SqlConnection selectedMeeting_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
            selectedMeeting_con.Open(); // opening the sql connection
            SqlCommand selectedMeeting_cmd = new SqlCommand("Select Attendee_ID from Meeting Where Meeting_Date_Time = '" + selectedMeeting.ToString(" yyyy-MM-dd hh:mm:ss tt") + "'", selectedMeeting_con); // sql query to select attendee ID from the Meeting Table
            SqlDataReader read_aID = selectedMeeting_cmd.ExecuteReader(); //sql data reader
            while (read_aID.Read()) //opening sql data reader
            {
                attendeeID = read_aID.GetInt32(0);
            }

            read_aID.Close();


            //update the annotations
            SqlConnection updateAnnotations_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
            updateAnnotations_con.Open(); // opening the sql connection
            SqlCommand cmd = new SqlCommand("UPDATE Meeting SET Annotation='" + annotationsbox.Text + "'  WHERE Attendee_ID = '" + attendeeID + "' ", updateAnnotations_con); //sql query
            cmd.ExecuteNonQuery(); //executing query

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
