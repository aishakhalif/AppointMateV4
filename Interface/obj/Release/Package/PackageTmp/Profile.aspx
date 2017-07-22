<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Interface.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
     <link href="index.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">

        
           <div class="main">
            <div class="header">
                <div class="header_resize">
                    <div class="logo">
                        <h1><a href="index.aspx"><small></small>
                            <br />
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
                        <li><a href="index.aspx" >Home</a></li>
                        <li><a href="Book_Meeting.aspx">Book Meeting</a></li>
                        <li><a href="Profile.aspx" class="active">My Profile</a></li>
                        <li><a href="Calendar">Calendar</a></li>
                        <li><a href="Change_Password.aspx">Change Password</a></li>
                    </ul>
                </div>
                    <div class="clr"></div>
                    <h2 class="bigtext"><span>My Profile</span>
                      </h2>

                    <div class="clr"></div>
                </div>
            </div>
            <div class="body">




                <div class="body_resize">
                    <div class="left">
                        <h2><strong>Role:</strong>&nbsp;&nbsp;<asp:Label ID="role_label" runat="server" Text="Label"></asp:Label></h2><div class="bg"></div>
                         <h2><strong>First Name: </strong>&nbsp;&nbsp;<asp:Label ID="firstName_label" runat="server" Text="Label"></asp:Label></h2><div class="bg"></div>
                         <h2><strong>Last Name:</strong>&nbsp;&nbsp;<asp:Label ID="lastName_label" runat="server" Text="Label"></asp:Label></h2><div class="bg"></div>
                         <h2><strong>Email:</strong>&nbsp;&nbsp;<asp:Label ID="email_label" runat="server" Text="Label"></asp:Label></h2>
                       
                        <div class="bg"></div>
                        <h2><strong>Last Login Date:</strong>&nbsp;&nbsp;&nbsp;<asp:Label ID="lastLogin_label" runat="server" Width="355px"></asp:Label>
                        </h2>
                       

                        </div>
                            <div class="clr"></div>
                        </div>
                   
                    <div class="footer">
                        <div class="footer_resize">
                            <p>© 2016 Appoint Mate V4 | Copyright &amp; Disclaimer | Created and Designed by Applied Software Networking (ASN)</p>
                        </div>
                        <div class="clr"></div>
                    </div>
                





            </div>



        </div>
  
  
        
          
           
          
       
    </form>
</body>
</html>
