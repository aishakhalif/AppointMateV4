    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book_Meeting.aspx.cs" Inherits="Interface.Create_Account" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Meeting Appoint Mate</title>
    <link href="index.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .ddl {}
    </style>

    <!-- Function to "disable" back button (just redirects user to this page again) -->
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

</head>

<body onload="noBack();"
    onpageshow="if (event.persisted) noBack();" onunload="">
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
                            <li><a href="index.aspx">Home</a></li>
                            <li><a href="Book_Meeting.aspx" class="active">Book Meeting</a></li>
                            <li><a href="Profile.aspx">Profile </a></li>
                            <li><a href="Calendar.aspx">Calendar</a></li>
                            <li><a href="Change_Password.aspx">Change Password</a></li>
                        </ul>
                        <br />
                        <br />
                    </div>
                    <div class="clr"></div>
                    <h2 class="bigtext"><span>Book New Meeting Series </span>
                        <br />
                        You can select a series and send meeting requests here. </h2>

                    <div class="clr"></div>
                </div>
            </div>
            <div class="body">
                <div class="body_resize">
                    <div class="left">

                        <p>
                            <asp:TextBox ID="seriesinput" runat="server" Height="23px" Width="267px" BorderColor="#CCCCCC" BorderStyle="Solid" MaxLength="20" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ValidationGroup=" check" ControlToValidate="seriesinput" ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        <div class="bg"></div>


                        <p>
                            <asp:TextBox ID="location" runat="server" Height="23px" Width="267px" BorderColor="#CCCCCC" BorderStyle="Solid" MaxLength="50" />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup=" check" ErrorMessage="Required" ControlToValidate="location" ForeColor="Red"></asp:RequiredFieldValidator>

                        </p>
                        <div class="bg"></div>
                        <p>
                            <asp:DropDownList ID="duration" runat="server" Height="35px" Width="267px" OnSelectedIndexChanged="duration_SelectedIndexChanged" CssClass="ddl">

                                <asp:ListItem Selected="True">5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>35</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>55</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>65</asp:ListItem>
                                <asp:ListItem>70</asp:ListItem>
                                <asp:ListItem>75</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>85</asp:ListItem>
                                <asp:ListItem>90</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ValidationGroup=" check" ControlToValidate="duration" ForeColor="Red"></asp:RequiredFieldValidator>
                       </p>
                        <div class="bg"></div>

                        <p>
                            <asp:DropDownList ID="breakStart" runat="server" Height="35px" Width="267px" OnSelectedIndexChanged="breakStart_SelectedIndexChanged">
                                <asp:ListItem Value="Select time...">Select time...</asp:ListItem>
                                <asp:ListItem Value="1">11:00</asp:ListItem>
                                <asp:ListItem Value="2">11:30</asp:ListItem>
                                <asp:ListItem Value="3">12:00</asp:ListItem>
                                <asp:ListItem Value="4">12:30</asp:ListItem>
                                <asp:ListItem Value="5">13:00</asp:ListItem>
                                <asp:ListItem Value="6">13:30</asp:ListItem>

                               
                                <asp:ListItem Value="7">14:00</asp:ListItem>
                                <asp:ListItem Value="8">14:30</asp:ListItem>
                                <asp:ListItem Value="9">15:00</asp:ListItem>
                                <asp:ListItem Value="10">15:30</asp:ListItem>

                               
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ValidationGroup=" check" ControlToValidate="duration" ForeColor="Red"></asp:RequiredFieldValidator>
                       </p>

                         <div class="bg"></div>

                        <p>
                            <asp:DropDownList ID="breakEnd" runat="server" Height="35px" Width="267px" OnSelectedIndexChanged="breakEnd_SelectedIndexChanged">
                                <asp:ListItem Value="Select time...">Select time...</asp:ListItem>
                                <asp:ListItem Value="1">11:30</asp:ListItem>
                                <asp:ListItem Value="2">12:00</asp:ListItem>
                                <asp:ListItem Value="3">12:30</asp:ListItem>
                                <asp:ListItem Value="4">13:00</asp:ListItem>
                                <asp:ListItem Value="5">13:30</asp:ListItem>
                                <asp:ListItem Value="6">14:00</asp:ListItem>

                               
                                <asp:ListItem Value="7">14:30</asp:ListItem>
                                <asp:ListItem Value="8">15:00</asp:ListItem>
                                <asp:ListItem Value="9">15:30</asp:ListItem>
                                <asp:ListItem Value="10">16:00</asp:ListItem>

                               
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ValidationGroup=" check" ControlToValidate="duration" ForeColor="Red"></asp:RequiredFieldValidator>
                       </p>

                         <div class="bg"></div>

                        
                        <p>
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="267px" Height="33px" BorderColor="#CCCCCC" BorderStyle="Solid" /> 

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload1" ValidationGroup=" check" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <a href="csv_file.csv"  target="blank">CSV Template</a>

                        </p>
                        <div class="bg"></div>
                        <p>
                            <asp:TextBox ID="message" runat="server" Height="62px" Width="267px" BorderColor="#CCCCCC" BorderStyle="Solid" MaxLength="250" TextMode="MultiLine" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup=" check" runat="server" ErrorMessage="Required" ControlToValidate="message" ForeColor="Red"></asp:RequiredFieldValidator>
              
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="message" ErrorMessage="Max Input 240 Characters " ForeColor="Red" ValidationExpression="^[\s\S]{0,245}$" ValidationGroup=" check"></asp:RegularExpressionValidator>
              
                              </p>
                        <div class="bg"></div>

                        
                            <div class="submit">
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Next" ValidationGroup=" check" />
                            </div>
                        
                       

                        <h2>&nbsp;</h2>
                    </div>
                    <div class="right">

                        <h2>Title</h2>

                        <div class="bg"></div>
                        <h2>Location</h2>
                         <div class="bg"></div>
                        <h2>Duration of Meeting</h2>
                         <div class="bg"></div>
                        <h2>Break Start</h2>
                         <div class="bg"></div>
                        <h2>Break End</h2>
                         <div class="bg"></div>
                        <h3>List of Attendees</h3>
                         <div class="bg"></div>
                        <h2>Series Message</h2>
                        <div class="bg"></div>
                        
                    </div>
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




    </form>



</body>
</html>
