using System;
using System.Data.SqlClient;

namespace Interface
{
    public partial class Login : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection("Data Source=ict333server.database.windows.net;Initial Catalog=database-tmd;User ID=ondopher;Password=Murdoch2016");
                con.Open();
                Session["field1"] = UserName.Text;
                SqlCommand cmd1 = new SqlCommand("UPDATE Accounts SET Last_Login ='" + DateTime.Now.ToString(" yyyy-MM-dd hh:mm:ss tt") + "'WHERE Email_Address='" + UserName.Text + "'", con);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Select Role, Account_Status from Accounts where Email_Address='" + UserName.Text + "' and Password ='" + Password.Text + "'", con);
                string role = "";
                bool status = true;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(1))
                        {
                            role = reader.GetString(0);
                            status = reader.GetBoolean(1);
                        }
                        else
                        {
                            role = reader.GetString(0);

                        }
                    }
                }


                if (role == "CA") //or "Central Admin" -- decide on one and stick to it
                {
                    Response.Redirect("Create_Account.aspx");
                }
                else if (role == "Convener" && status == true || role == "Organizer" && status == true)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Please enter valid Username and Password')</script>");
                }

            }


            catch (SqlException)

            {

                Response.Redirect("Login.aspx");

            }



        }

        protected void newuserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("acc_request.aspx");
        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
