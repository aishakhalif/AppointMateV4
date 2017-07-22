<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Interface.WebForm9" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
 <link href="index.css" rel="stylesheet" type="text/css"/>   
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="header">
            <div class="header_resize">
                <div class="logo">
                    <h1><a href="index.aspx"><small></small><br />
                        </a></h1>
                </div>
                <div class="logo_text">   <div class="submit">
                                <asp:Button ID="logout" runat="server" OnClick="logout_Click1" Text="Logout" />
                            </div></div>
                <div class="clr"></div>
            </div>
            <div class="headert_text_resize">
                <div class="menu">
                    <ul>
                        <li><a href="Book_Meeting.aspx">Book Meeting</a></li>
                        <li><a href="Profile.aspx">My Profile</a></li>
                        <li><a href="Calendar">Calendar</a></li>
                        <li><a href="Change_Password.aspx">Change Password</a></li>
                    </ul>
                </div>
                <div class="clr"></div>
                <h2 class="bigtext"><span>Welcome to Appointmate </span>
                    <br />
                    The right solution for your appointments.</h2>

                <div class="clr"></div>
            </div>
        </div>
        <div class="body">
            <div class="body_resize">
                <div class="left">
                    <h2>Book New Meeting Series  </h2>
                   <a href="Book_Meeting.aspx"> <img src="img_1.png" alt="img_1" width="89" height="78" class="floated" /></a>
                    <p>
                        Conveners and their Organizers get the ability to book meetings here. </p>
        <div class="bg"></div>
                        <h2>Calendar </h2>
                       <a href ="Calendar.aspx" ><img src="img_2.png" alt="img_2" width="89" height="82" class="floated" /></a>
                        <p>View and print past, present and future meetings details here</p>
                        
                    <div class="bg"></div>
                    <h2>About Us  </h2>
                   <a href="About_us.aspx"> <img src="about.jpg" alt="img_1" width="89" height="78" class="floated" /></a>
                    <p>
                       Meeting bookings made easier. </p>
        <div class="bg"></div>
                </div>
              
                <div class="clr"></div>

           

            </div>
        </div>
      
        <div class="footer">
            <div class="footer_resize">
                <p>© 2016 Appoint Mate V4 | Copyright &amp; Disclaimer | Created and Designed by Applied Software Networking (ASN)</p>
            </div>
            <div class="clr"></div>
        </div>
    </div>
        </form>
</body>
</html>
