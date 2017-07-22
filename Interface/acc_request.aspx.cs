using System;
using System.Text;
using System.Net;
using System.Net.Mail;
namespace Interface
{
    public partial class acc_request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_RequestButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (DropDownList1.SelectedIndex == 0)
                {
                    Response.Write("<script>alert('Please select a role.')</script>");
                }
                else {

                    //this code takes the data from request account makes an auto formatted Email from it and sends it to the Central Admin
                    SmtpClient client = new SmtpClient("outlook.office365.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("project_ict333@murdochdubai.ac.ae", "ict@333");
                    MailMessage mail = new MailMessage();
                    mail.To.Add("project_ict333@murdochdubai.ac.ae");
                    mail.Subject = " Appoint Mate account request ";
                    mail.From = new MailAddress("project_ict333@murdochdubai.ac.ae");
                    mail.Body = "Dear CA," + "\n\n" + "A new account with the following details has been requested to be created on Appointmate V4" + "\n\n" + "First Name: " + txtFirstName.Text + "\n" + "Last Name: " + txtLastName.Text + "\n" + "Email Address: " + txtEmail.Text + "\n" + "Role: " + DropDownList1.Text + "\n\n" + "Please verify the details and create the account upon verificaiton.";
                    client.Send(mail);
                    Response.Write("<script>alert('Your request has been sent successfully, Please wait until we get back to you')</script>");

                    //clear all the fields after email is sent
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    DropDownList1.SelectedIndex = 0;
                }

            }

            catch (Exception)
            {

            }

        }

        protected void txtFirstNam_TextChanged(object sender, EventArgs e)
        {

        }
    }
}