<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Account.aspx.cs" Inherits="Interface.WebForm6" %>

<!DOCTYPE html>
<script runat="server">

</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    
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
                                <li><a href="Create_account.aspx" class="active">Create Accounts</a></li>
                                <li><a href="Link_Accounts.aspx" >Link Accounts</a></li>
                                <li><a href="Unlink_Accounts.aspx" >Unlink Accounts</a></li>
                                <li><a href="Change_Account_Status.aspx">Change Account Status</a></li>
                            </ul>
                        </div>
                        <div class="clr"></div>
                        <h2 class="bigtext"><span>Create Account</span>
                            <br />
                            Please enter the following details to create new account.</h2>

                        <div class="clr"></div>
                    </div>
                </div>
                <div class="body">




                    <div class="body_resize">
                        <div class="left">
                            <p>E-Mail Address&nbsp;&nbsp;
                          
                                <asp:TextBox ID="txtEmail_Address" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="200px" MaxLength="50" TextMode="Email" OnTextChanged="txtEmail_Address_TextChanged" />
     
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail_Address" ErrorMessage="Required" ForeColor="Red" ValidationGroup=" check"></asp:RequiredFieldValidator>
     
                            </p>






                            <div class="bg"></div>
                            <p>Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Visible="True" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="200px" MaxLength="10" />
     
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="At least 6 characters required" ForeColor="Red" ValidationGroup=" check"></asp:RequiredFieldValidator>
     
                            </p>


                             <div class="bg"></div>
                               <p>First Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:TextBox ID="txtFirstName" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="200px" MaxLength="50" />
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required" ForeColor="Red" ValidationGroup=" check"></asp:RequiredFieldValidator>
                            </p>
                           
          


                             <div class="bg"></div>
                                      <p>Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                          <asp:TextBox ID="txtLastName" runat="server" style="z-index: 1" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" Width="200px" MaxLength="50"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required" ForeColor="Red" ValidationGroup=" check" ></asp:RequiredFieldValidator>
                            </p>
                           
          
                                          <div class="bg"></div>
                                      <p>Role&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:DropDownList ID="DropDownList1" runat="server" Height="31px" Width="200px">
                                              <asp:ListItem Selected="True">Select a role...</asp:ListItem>
                                              <asp:ListItem>Convener</asp:ListItem>
                                              <asp:ListItem>Organizer</asp:ListItem>
                                          </asp:DropDownList>
                            </p>
     
                         

                             <div class="bg"></div>


                        
                            <div class="submit">
                                
                                  <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Text="Submit" ValidationGroup=" check" OnClick="Button1_Click" Height="35px" Width="102px" />
                 </div>
                        
                        

                        </div>
                        <div class="clr"></div>

                    

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
