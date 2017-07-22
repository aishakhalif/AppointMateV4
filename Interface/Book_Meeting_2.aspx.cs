using System;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Interface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CheckBoxList cblist = new CheckBoxList();// declaring cblist as checkbox list
        Int32 MinSlot = 0;//declaring minslot as integer 
        static int countSelected = 0;
        static DateTime dt;// declaring dt as static datetime
        static ArrayList timeslots = new ArrayList();// declaring timeslots as static arraylist

        protected void Page_Load(object sender, EventArgs e)//page load 
        {

            if (!this.IsPostBack)
            {
                countSelected = 0;
            }

            if (Session["field1"] != null)//checking if session feild is not null
            {

                //retrieving the break start time from the database
                TimeSpan breakStartTime = new TimeSpan();
                SqlConnection breakStart_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
                breakStart_con.Open(); // opening the sql connection
                SqlCommand breakStart_cmd = new SqlCommand("Select * from Series Where Series_ID = '" + (int)Session["SID"] + "'", breakStart_con); // sql query to select meeting break start and end times for this particular session
                SqlDataReader read_breakStart = breakStart_cmd.ExecuteReader(); //sql data reader to get the break start time of meeting
                while (read_breakStart.Read()) //opening sql data reader
                {
                    breakStartTime = (TimeSpan)read_breakStart["Lunch_Break_Start"]; //read in time as a TimeSpan


                }

                breakStart_con.Close();


                //retrieving the break end time from the database
                TimeSpan breakEndTime = new TimeSpan();
                SqlConnection breakEnd_con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016"); // sql connection string to database
                breakStart_con.Open(); // opening the sql connection
                SqlCommand breakEnd_cmd = new SqlCommand("Select * from Series Where Series_ID = '" + (int)Session["SID"] + "'", breakEnd_con); // sql query to select meeting break start and end times for this particular session
                SqlDataReader read_breakEnd = breakStart_cmd.ExecuteReader(); //sql data reader to get the break start time of meeting
                while (read_breakEnd.Read()) //opening sql data reader
                {
                    breakEndTime = (TimeSpan)read_breakEnd["Lunch_Break_End"]; //read in time as a TimeSpan
                }

                breakEnd_con.Close();

                //retrieving the meeting duration from the database
                Int32 Duration = 0;// declaring duration as integer, intial value is 0
                SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//my connection string to database
                am.Open();//opening my sql connection
                SqlCommand cmd_sub = new SqlCommand("Select  Meeting_Duration from Series Where Series_ID = '" + (int)Session["SID"] + "'", am); // my sql query to select meeting duration
                SqlDataReader read_data = cmd_sub.ExecuteReader();//my sql data reader to get the duration of meeting
                while (read_data.Read())//opening sql data reader
                {
                    Duration = read_data.GetInt32(0); //storing duration in string "duration"
                }



                //declaring my time spans
                TimeSpan start = new TimeSpan(9, 0, 0);
                TimeSpan end = new TimeSpan(22, 0, 0);
                TimeSpan increment = new TimeSpan(0, Duration, 0);


                while (start <= end) //while loop to create time slots
                {
                    if ((start.CompareTo(breakStartTime) < 0) || (start.CompareTo(breakEndTime) >= 0))//if statment to add lunch break 
                    {

                        if ((breakStartTime - start).CompareTo(increment) == (breakStartTime.CompareTo(start)))
                        {
                            cblist.Items.Add(new ListItem(start.ToString())); //adding timeslots to my checkbox list
                            cblist.RepeatColumns = 4;
                        }
                    }

                    start = start.Add(increment);// declaring duration as my new start
                }

                PlaceHolder1.Controls.Add(cblist);// adding timeslots to a placeholder 
                am.Close();//closing sql connection 
                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//new sql connection 
                con.Open();//opening new sql connection 
                SqlCommand AIDCOUNT = new SqlCommand("Select  count(Attendee_ID) from Attendee Where Series_ID = '" + (int)Session["SID"] + "'", con); // sql query to count number of attendees in current series 
                SqlDataReader read_data1 = AIDCOUNT.ExecuteReader();//data reader for counting number of attendees in current series 
                while (read_data1.Read())// opening my data reader
                {
                    MinSlot = read_data1.GetInt32(0);// storing the attendee count in integer 
                    mslots.Text = Convert.ToString(MinSlot);//converting the attendee count to string
                }
                read_data1.Close();//closing my data reader 
                con.Close();//closing my sql connection
            }
            else
            {
                Response.Redirect("login.aspx");//if login session is cleared the system redirects to login page
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // my add button
        {
            foreach (ListItem item in cblist.Items) // my function to convert the timeslots to date time
            {
                dt = Calendar1.SelectedDate;
                Double hours1;
                Double mins1;
                if (item.Selected)
                {
                    string store = item.Value;
                    string hours = store.Substring(0, 2);
                    string mins = store.Substring(3, 2);
                    hours1 = Convert.ToDouble(hours);
                    mins1 = Convert.ToDouble(mins);

                    if (dt == DateTime.Today && hours1 <= DateTime.Now.Hour + 1) // check if user selected a time that has already passed
                    {
                        Response.Write("<script>alert('Past times cannot be added. Please select a valid times.');location.href='Book_Meeting_2.aspx'</script>"); // display warning to user and refresh the page so that the "next" button does not appear
                        timeslots.Clear();
                    }

                    else
                    {
                        dt = dt.AddHours(hours1);
                        dt = dt.AddMinutes(mins1);
                        timeslots.Add(dt); // adding timeslots in an array list "timeslots"
                    }
                }
            }



            foreach (ListItem item in cblist.Items)// my function to count number of selected slots

            {
                if (item.Selected)

                {
                    countSelected += 1;

                }
            }


            if (Calendar1.SelectedDate.Date != DateTime.MinValue.Date)// my function to check if any date is selected on the calendar
            {
                if (MinSlot <= countSelected)// my function to check if slected slots are equal to or greated than minimum required slots for the series 
                {

                    Button1.Visible = true;// makes next button visible which is not visible by default

                }

            }

            else
            {
                Response.Write("<script>alert('Please Select a date on the calendar ')</script>");//error message if date is not selected on the calander 
                timeslots.Clear();//clears the data from the array if date is not selected
            }
        }


        protected void Button1_Click(object sender, EventArgs e)//my next button
        {

            try
            {
                SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");//sql connection string
                SqlCommand xp = new SqlCommand();// declaring xp as new sql command
                xp.CommandType = System.Data.CommandType.Text;//declaring sql command properties
                xp.Connection = am;//stating sql connectin for my command
                am.Open();
                for (int i = 0; i < timeslots.Count; i++)// itterating until all the slots are stored into the database
                {
                    DateTime temp = (DateTime)timeslots[i];// converting string values stored in array timeslots to string 
                    xp.CommandText = "Insert into Availability (Series_ID, Availability_Date_Time ) Values('" + (int)Session["SID"] + "',  '" + temp.ToString(" yyyy-MM-dd hh:mm:ss tt") + "')";//my query to store timeslots to database
                    xp.ExecuteNonQuery();//executing my sql query

                }
                timeslots.Clear();//clearing the timeslots array once the timeslots are stored into database
                am.Close();//closing my sql connection
                Response.Redirect("Book_Meeting_Summary.aspx");//redirecting to 3rd page of book meeting

            }

            catch (SqlException)//catching sql exceptions

            {
                Response.Redirect("Error.aspx"); //redirecting to error page if exceptions occour
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate <= DateTime.Today) // if any past day is selected or today's date is selected
            {
                Response.Write("<script>alert('Meetings need to be scheduled atleast 24 hours prior. Please select an appropiate date ')</script>"); // display warning to user
                Calendar1.SelectedDate = DateTime.Today.AddDays(1); // automatically set date selection to current dat
            }

            cblist.ClearSelection();
        }

        protected void logout_Click1(object sender, EventArgs e)//my logout button
        {
            Session["field1"] = null;// clearing the username stored in session variable 
            Response.Redirect("Login.aspx");//redirecting to login page

        }
    }
}