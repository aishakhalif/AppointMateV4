<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book_Meeting_Summary.aspx.cs" Inherits="Interface.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Series Summary</title>
      <link href="index.css" rel="stylesheet" type="text/css" /> 
    
        <!-- Function to "disable" back button (just redirects user to this page again) -->
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

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
                        <li><a href="index.aspx" >Home</a></li>
                        <li><a href="Book_Meeting.aspx" class="active">Book Meeting</a></li>
                        <li><a href="Profile.aspx">Profile</a></li>
                        <li><a href="Calendar.aspx">Calendar</a></li>
                        <li><a href="Change_Password.aspx">Change Password</a></li>
                    </ul>
                </div>
                <div class="clr"></div>
                <h2 class="bigtext"><span>Series Summary </span>
                    <br />
                    Please confirm the following series: </h2>

                <div class="clr"></div>
            </div>
        </div>
        <div class="body">
            <div class="body_resize">
                <div class="left">
                    
                    <p>  
                          <asp:Label ID="Label1" runat="server"></asp:Label>
                    </p>
                                <div class="bg"></div>
                        
                    
                    <p> 
                          <asp:Label ID="Label2" runat="server"></asp:Label>
                    </p>
                                <div class="bg"></div>
                       <p> 
                             <asp:Label ID="Label3" runat="server">Duration</asp:Label> <asp:Label ID="Label5" runat="server" Text="minutes"></asp:Label>
                    </p>
                                <div class="bg"></div>
                       
                       <p>
                                  <asp:Label ID="Label4" runat="server"></asp:Label>
                               </p> 
                                
                     
                    
                       
                           <div class="submit">
                                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm" />
                </div>
                    
                                

                    <h2>&nbsp;</h2>
                </div>
                <div class="right">
                    
                    <h2>Series Name</h2> 
                    
                    <div class="bg"></div>
                    <h2>Series Location</h2>
                   <div class="bg"></div>
                   <h2>Series Duration</h2> 
                   <div class="bg"></div>
                    <h2>Series Message</h2>
                    
                </div>
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
        
            </form>
</body>
</html>
