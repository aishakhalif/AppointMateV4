<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Interface.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
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
                        <li><a href="Profile.aspx" >My Profile</a></li>
                        <li><a href="Calendar">Calendar</a></li>
                        <li><a href="Change_Password.aspx">Change Password</a></li>
                    </ul>
                </div>
                    <div class="clr"></div>
                    <h2 class="bigtext"><span>Error page</span>
                        <br /> Something went wrong, please start a new session. 
                      </h2>

                    <div class="clr"></div>
             




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



        
  
  
        
          
           
          
       
    </form>
</body>
</html>
