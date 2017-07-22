<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book_Meeting_2.aspx.cs" Inherits="Interface.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Time Slots</title>

    <link href="index.css" rel="stylesheet" type="text/css" />

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
                            <li><a href="Profile.aspx">Profile</a></li>
                            <li><a href="Calendar.aspx">Calendar</a></li>
                            <li><a href="Change_Password.aspx">Change Password</a></li>
                        </ul>
                    </div>
                    <div class="clr"></div>
                    <h2 class="bigtext"><span>Please Select Your availability  </span>
                        <br />
                        You can select the relevant time slots according to your availability here.</h2>

                    <div class="clr"></div>
                </div>
            </div>
            <div class="body">
                <div class="body_resize">
                    <div class="left">
                        <div class="calendarWrapper">
                            <p>

                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="303px" Width="556px" NextPrevFormat="FullMonth" style="margin-left: 0px" OnSelectionChanged="Calendar1_SelectionChanged">
                                    <DayHeaderStyle BackColor="#25BAE4" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <TitleStyle BackColor="#ff4500" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                </asp:Calendar>

                            </p>
                        </div>
                        <h2>&nbsp;</h2>
                        <div class="bg"></div>
                        <p>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </p>
                        <div class="bg"></div>
                        
                            <div class="submit">
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add" />
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Next" EnableTheming="False" Visible="False" />
                            </div>
                           

                        

                    </div>
                    <div class="right">
                        <h2>Minimum Slots</h2>
                        <h2>
                            <asp:Label ID="mslots" runat="server" Text=""></asp:Label></h2>

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
