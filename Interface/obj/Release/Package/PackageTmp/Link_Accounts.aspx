﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Link_Accounts.aspx.cs" Inherits="Interface.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Accounts</title>
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
                            <li><a href="Create_account.aspx">Create Accounts</a></li>
                            <li><a href="Link_Accounts.aspx" class="active">Link Accounts</a></li>
                            <li><a href="Unlink_Accounts.aspx">Unlink Accounts</a></li>
                            <li><a href="Change_Account_Status.aspx">Change Account Status</a></li>

                        </ul>
                    </div>
                    <div class="clr"></div>
                    <h2 class="bigtext"><span>Link Accounts</span>
                        <br />
                        Please select the Convener and Organizer to link their accounts.</h2>

                    <div class="clr"></div>
                </div>
            </div>
            <div class="body">




                <div class="body_resize">
                    <div class="left">
                        <h2>Convener&nbsp; &nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="200px" AutoPostBack="true">
                                <asp:ListItem Selected="True">Please select a convener...</asp:ListItem>
                            </asp:DropDownList>
                        </h2>






                        <div class="bg"></div>
                        <h2>Organizer&nbsp;&nbsp;    
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style3" Height="23px" Width="200px">
                                <asp:ListItem Selected="True">Please select an organizer...</asp:ListItem>
                            </asp:DropDownList></h2>


                        <div class="bg"></div>


                        
                            <div class="submit">
                                <asp:Button ID="Button1" runat="server" CssClass="auto-style4" Text="Link Accounts" onCLick="Button1_Click"/>
                            </div>
                        
                      

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
