<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Account_Status.aspx.cs" Inherits="Interface.WebForm20" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Change Account Status</title>
    <link href="index.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style3 {
            margin-left: 5px;
        }
    </style>

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
                            <li><a href="Link_Accounts.aspx">Link Accounts</a></li>
                            <li><a href="Unlink_Accounts.aspx">Unlink Accounts</a></li>
                            <li><a href="Change_Account_Status.aspx" class="active">Change Account Status</a></li>

                        </ul>
                        <br />
                        <br />
                    </div>
                     <div class="clr"></div>
                    <h2 class="bigtext"><span>Change Account Status</span>
                        <br />
                        Please select the role and associated email address to change the account status.</h2>

                    <div class="clr"></div>
                </div>
            </div>
            <div class="body">
                <div class="body_resize">
                    <div class="left">
                        <h2>Select Role:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style2" Height="23px" Width="210px
                                " OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>Convener</asp:ListItem>
                                <asp:ListItem>Organizer</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Required" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </h2>






                        <div class="bg"></div>
                        <h2>Email Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style3" Height="23px" Width="210px
                                " OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" ErrorMessage="Required" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </h2>

                        <div class="bg"></div>
                        <h2>Last Login Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Width="303px"></asp:Label></h2>

                        <div class="bg"></div>
                        <h2>Current Status:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Width="303px"></asp:Label></h2>
                                                <div class="bg"></div>
                        <h2>Set Account Status:&nbsp; <asp:DropDownList ID="DropDownList3" runat="server" CssClass="auto-style3" Height="23px" Width="210px
                                " OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>Select a status...</asp:ListItem>
                                <asp:ListItem>Inactive</asp:ListItem>
                                <asp:ListItem>Active</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList3" ErrorMessage="Required" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                        </h2>
                                             

                        <div class="bg"></div>
                        <div class="submit">
                            <asp:Button ID="Button1" runat="server" CssClass="auto-style4" Text="Update Status" OnClick="Button1_Click" />
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