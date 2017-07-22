<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Interface.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AppointMate V4</title>
     <link href="index.css" rel="stylesheet" type="text/css" /> 
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
            
                                       
            <div class="main">
        <div class="header">
            <div class="header_resize">
                <div class="logo">
                    <h1><a ><small></small><br />
                        </a></h1>
                </div>
               
                <div class="clr"></div>
            </div>
            <div class="headert_text_resize">
              
                <div class="clr"></div>
                <h2 class="bigtext">&nbsp;</h2>
                <h2 class="bigtext">&nbsp;</h2>
                <h2 class="bigtext"><span>Welcome to AppointMate V4</span><br />
                    The right solution for your appointments.<br />
                    Please login to continue.</h2>

                <div class="clr"></div>
            </div>
        </div>
        <div class="body">
            <div class="body_resize">
                <div class="left">
        <p> Username <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em" Width="230px" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" MaxLength="50" TextMode="Email" OnTextChanged="UserName_TextChanged"></asp:TextBox>
             <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Required" ToolTip="User Name is required." ValidationGroup="Login1" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>  <div class="bg"></div>                           
                                       <p> Password&nbsp; <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password" Width="232px" BorderColor="#CCCCCC" BorderStyle="Solid" MaxLength="10" Height="23px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Required" ToolTip="Password is required." ValidationGroup="Login1" ForeColor="Red"></asp:RequiredFieldValidator>
                                 
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                 </p>   

                       <div class="bg"></div>
                        
                            <div class="submit">
                    <asp:Button ID="LoginButton" runat="server" Text="Log In"  OnClick="LoginButton_Click" ValidationGroup="Login1"/>
                                <asp:Button ID="newuser" runat="server" Text="Request Account"    OnClick="newuserButton_Click"/>
                            
               
                </div>

                    </div>
                </div>
               
                <div class="clr"></div>
            </div>
       <div class="clr"></div>
                        
                 
                    <div class="footer">
                        <div class="footer_resize">
                            <p>© 2016 Appoint Mate V4 | Copyright &amp; Disclaimer | Created and Designed by Applied Software Networking (ASN)</p>
                        </div>
                        <div class="clr"></div>
            <div class="clr"></div>
       
    
            
            
            
                                    
       </div>
                </div> 
     
    </div>
    
    </form>
</body>
</html>
