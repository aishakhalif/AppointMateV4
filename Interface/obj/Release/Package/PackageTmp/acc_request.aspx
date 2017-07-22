<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acc_request.aspx.cs" Inherits="Interface.acc_request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Request New User</title>
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
                <h2 class="bigtext"><span>Welcome to Appointmate V4 </span>
                    <br />
                    Please enter the following details and<br />
                    we will get back to you.
                </h2>

                <div class="clr"></div>
            </div>
        </div>
        <div class="body">
            <div class="body_resize">
                <div class="left">
        <p> First Name&nbsp;&nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtFirstName" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="167px" MaxLength="50" OnTextChanged="txtFirstNam_TextChanged"></asp:TextBox> 
        

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirstName" EnableTheming="True" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
        

                    </p>  <div class="bg"></div>

        <p> Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtLastName" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="167px" MaxLength="50"></asp:TextBox> 
        

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
        

                    </p>  <div class="bg"></div>

        <p> Work E-Mail&nbsp;&nbsp;    <asp:TextBox ID="txtEmail" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="167px" MaxLength="50" TextMode="Email" />  
        
         
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
        
         
                    </p>  <div class="bg"></div>
         
                    <p> Role&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
                <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="167px">
                    <asp:ListItem Selected="True">Select a role...</asp:ListItem>
                    <asp:ListItem>Convener</asp:ListItem>
                    <asp:ListItem Value="Organizer">Organizer</asp:ListItem>
            </asp:DropDownList>
                    </p>  <div class="bg"></div>
                                               
                                  
                        
                            <div class="submit">
                   
                                <asp:Button ID="newuser" runat="server" Text="Confirm Request"  OnClick="Confirm_RequestButton_Click"/>
                            
               
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
