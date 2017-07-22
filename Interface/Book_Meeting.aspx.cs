using System;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;


namespace Interface
{
    public partial class Create_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (Session["field1"] != null) //checks if username stored after login is null
                {

                    Session["field1"].ToString();

                    //a check to see if organiser is unlinked

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

                    if (role == "Organizer") //if the logged in user is organiser, check if they are unlinked
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
                        if (unlinked == 0)
                        {
                            Response.Redirect("Unlinked_Organizer_Book_Meeting.aspx");
                        }
                    }
                }

                else
                {
                    Response.Redirect("login.aspx");//if username session feild is null the system redirects to login page
                }
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)// my next button
        {



            //checking if a time is selected in the list and not the default "Select Time..." 
            if (breakEnd.Text.StartsWith("Select") || breakStart.Text.StartsWith("Select"))
            {
                Response.Write("<script>alert('You have not correctly selected the lunch break start and end times.')</script>");
            }

            //checking that the break start and end times are not the same
            else if (breakEnd.SelectedItem.Text.CompareTo(breakStart.SelectedItem.Text) <= 0)
            {
                Response.Write("<script>alert('The break end time cannot be before or the same as the start time. Please select an appropriate end time.')</script>");
            }

            //checking that the lunch break is not more than an hour
            else if (breakEnd.SelectedIndex >= (breakStart.SelectedIndex + 2))
            {
                Response.Write("<script>alert('Lunch breaks can only be a maximum of 1 hour.')</script>");
            }


            else
            {

                try
                {

                    //this code opens the databse connection and checks the role of the current user
                    SqlConnection am = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                    am.Open();
                    String accounttype = "";//declaring accountytpe as string 
                    SqlCommand atype = new SqlCommand("Select  Role from Accounts Where Email_Address = '" + Session["field1"] + "'", am);
                    SqlDataReader tdata = atype.ExecuteReader();//my data reader for checking the account role
                    while (tdata.Read())//opening my data reader for checking the account role
                    {
                        accounttype = tdata.GetString(0);//storing account type to string "accounttype"
                    }
                    tdata.Close();//opening my data reader for checking the account role
                    String SEmail = "";// stores the role of the current user in a string.

                    if (accounttype == "Organizer")//if the logged in user is organiser 

                    {

                        String conmail = "";// string to store Conveners Email
                        SqlCommand oat = new SqlCommand("Select  Email_Address from Accounts Where Organizer_Email = '" + Session["field1"] + "'", am);
                        SqlDataReader oats = oat.ExecuteReader(); //my data reader for reading convener email
                                                                  //selects the Convneres email from database 
                        while (oats.Read())//opening my data reader for reading convener email
                        {
                            conmail = oats.GetString(0);//storing conveners email to string "conmail"

                        }

                        SEmail = conmail;// storing convener email in string to use for updating series data
                        oats.Close(); //closing my data reader for reading convener email
                    }


                    else
                    {

                        //storing login username in string to use for updating series data
                        SEmail = Session["field1"].ToString();
                    }

                    //system can't store any text with an apostrophe so check for it
                    if (seriesinput.Text.Contains("'") || location.Text.Contains("'"))
                    {
                        Response.Redirect("Book_Meeting.aspx");
                        Response.Write("<script>alert('Please ensure there are no apostrophes in the meeting title or location')</script>");
                    }

                    else
                    {
                       
                        //storing series data into the database
                        TimeSpan breakStartTime = TimeSpan.Parse(breakStart.Text);
                        TimeSpan breakEndTime = TimeSpan.Parse(breakEnd.Text);
                        //DateTime breakStartTime = DateTime.Parse(breakStart.Text, System.Globalization.CultureInfo.CurrentCulture);
                        //DateTime breakEndTime = DateTime.Parse(breakEnd.Text, System.Globalization.CultureInfo.CurrentCulture);
                        SqlCommand xp = new SqlCommand();//declaring new sql command
                        xp.CommandType = System.Data.CommandType.Text;
                        xp.Connection = am;
                        xp.CommandText = "Insert into Series(Email_Address, Series_Title, Series_Message, Series_Location, Meeting_Duration, Lunch_Break_Start, Lunch_Break_End) OUTPUT INSERTED.Series_ID Values('" + SEmail + "', '" + seriesinput.Text + "', '" + message.Text + "', '" + location.Text + "', '" + duration.Text + "', '" + breakStart.SelectedItem.Text + "','" + breakEnd.SelectedItem.Text + "')";
                        Int32 Series_ID = (int)xp.ExecuteScalar();
                        Session["SID"] = Series_ID;//storing the series ID returned from database into a session variable "SID"

                    }
                    

                    if (FileUpload1.HasFile)//condition to check if file uploder has file or not
                    {

                        if (!FileUpload1.FileName.Contains(".csv"))
                        {
                            Response.Write("<script>alert('Please upload a .CSV file.')</script>");
                        }

                        else
                        {
                            string path = string.Concat(Server.MapPath("~/" + FileUpload1.FileName));//my path to store csv file 
                            FileUpload1.SaveAs(path);

                            using (TextFieldParser csvParser = new TextFieldParser(path))//my text field parser to parse csv data
                            {
                                csvParser.SetDelimiters(new string[] { "," });
                                csvParser.HasFieldsEnclosedInQuotes = true;
                                string[] headingLine = csvParser.ReadFields(); //store the heading line in an aray of strings                              
                                System.Diagnostics.Debug.WriteLine("headlingLine length: " + headingLine.Length);
                                while (!csvParser.EndOfData)
                                {
                                    string[] fields = csvParser.ReadFields();
                                    //check if the length is 5
                                    if (fields.Length == 5)
                                    {
                                        //if so, check that none of them are empty
                                        for (int i = 0; i < headingLine.Length; i++)
                                        {
                                            if (fields[i].ToString().Equals(""))
                                            {
                                                Response.Redirect("Book_Meeting.aspx");
                                                Response.Write("<script>alert('Looks like the .csv file uploaded had incorrect data. Please upload another one.');location.href='Book_Meeting.aspx'</script>");
                                            }
                                        }

                                        int Person_Id = Int32.Parse(fields[0]);//getting person ID from csv file
                                        string Title = fields[1];//getting title from csv
                                        string GivenName = fields[2];//getting given name from csv file
                                        string Surname = fields[3];//getting surname from my csv file
                                        string Email = fields[4];//getting email from my csv file
                                        SqlCommand load = new SqlCommand("INSERT INTO Attendee (Series_ID, Person_ID, Title, First_Name, Last_Name, Email_Address, One_time_Link_Status ) Values ('" + Session["SID"] + "', '" + Person_Id + "', '" + Title + "', '" + GivenName + "' , '" + Surname + "','" + Email + "', ' Valid ') ", am);//uploading csv data into the database, the one time link status is set to "Valid" here and later becomes invalid once the link is used
                                        load.ExecuteNonQuery();
                                    }

                                    else
                                    {
                                        Response.Redirect("Book_Meeting.aspx");
                                        Response.Write("<script>alert('Looks like the .csv file uploaded had incorrect data. Please upload another one.');location.href='Book_Meeting.aspx'</script>");
                                    }
                                }

                                Response.Redirect("Book_Meeting_2.aspx");// redirects to 2nd page of book meeting
                            }
                        }
                    }

                    else
                    {
                        Response.Write("<script>alert('Please attach a CSV file'  )</script>");// error display if file uploader for csv is empty
                    }

                }


                catch (SqlException)
                {
                    Response.Redirect("Error.aspx");// error handling redirects to error page 

                }


            }
        }

        protected void duration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void breakStart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void breakEnd_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        protected void logout_Click1(object sender, EventArgs e)//logout button
        {
            Session["field1"] = null;//clears the username from session field to prevent access without login
            Response.Redirect("Login.aspx");//redirects to login page

        }
    }

}