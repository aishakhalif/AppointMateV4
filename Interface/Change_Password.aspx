<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="Interface.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
     <link href="index.css" rel="stylesheet" type="text/css" />    
   
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
                <div class="logo_text"> <div class="submit">
                                <asp:Button ID="Button2" runat="server" OnClick="logout_Click1" Text="Logout" />
                            </div></div>
                <div class="clr"></div>
            </div>
            <div class="headert_text_resize">
                <div class="menu">
                    <ul>
                        <li><a href="index.aspx">Home</a></li>
                        <li><a href="Book_Meeting.aspx">Book Meeting</a></li>
                        <li><a href="Profile.aspx">Profile</a></li>
                        <li><a href="Calendar.aspx" >Calendar</a></li>
                        <li><a href="Change_Password.aspx" class="active" >Change Password</a></li>
                    </ul>
                </div>
                <div class="clr"></div>
                <h2 class="bigtext"><span>Change Password </span>
                    <br />
                    Please select a new password.</h2>

                <div class="clr"></div>
            </div>
        </div>
        <div class="body">
            <div class="body_resize">
                 <div class="left">

                      
                     <p>Current password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;       <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Required" ForeColor="Red" ValidationGroup="pw"></asp:RequiredFieldValidator>
                     </p>

                        <div class="bg"></div>


<p>New password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="At least 6 characters" ForeColor="Red" ValidationExpression="^[\s\S]{6,10}$" ValidationGroup="pw" Display="Dynamic"></asp:RegularExpressionValidator>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Required" ForeColor="Red" ValidationGroup="pw" Display="Dynamic"></asp:RequiredFieldValidator>
             </p>     

                        <div class="bg"></div>
   <p>   Confirm new password&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" TextMode="Password" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px"></asp:TextBox> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Required" ForeColor="Red" ValidationGroup="pw"></asp:RequiredFieldValidator>
                     </p>
     
                        <div class="bg"></div>
                     <p>
                         <asp:Label ID="Label1" runat="server"></asp:Label>

                     </p>
                   
                        
                        
                            <div class="submit">
                                 <asp:Button ID="Button1" runat="server" CssClass="auto-style4" ValidationGroup="pw" Text="Change Password" OnClick="Button1_Click" />
             </div>
                        
                     
                     
                    </div>
               
     

                <div class="clr"></div>
           
        <div class="footer">
            <div class="footer_resize">
                <p>© 2016 Appoint Mate V4 | Copyright &amp; Disclaimer | Created and Designed by Applied Software Networking (ASN)</p>
            </div>
            <div class="clr"></div>
        </div>
    </div>

         
          
 </div>
          
</div>

    </form>
</body>
</html>
