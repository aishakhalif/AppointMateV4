﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking_Site_TimeSlots.aspx.cs" Inherits="Interface.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Booking Site</title>
    <link href="index.css" rel="stylesheet" type="text/css" />

    <!-- Function to redirect page after a certain amount of milliseconds (30 minutes, in this case) -->
    <script>
        setTimeout(function () {
            window.location.href = "http://appointmateversion4.azurewebsites.net/OTLTO";
        }, 30 * 60 * 1000);
    </script>

    <!-- Function to "disable" back button (just redirects user to this page again) -->
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

</head>

<body onload="noBack();"
    onpageshow="if (event.persisted) noBack();" onunload="">
    
    <form id="form1" runat="server">
        <div class="auto-style1">


            <div class="main">
                <div class="header">
                    <div class="header_resize">
                        <div class="logo">
                            <h1><a><small></small>
                                <br />
                            </a></h1>
                        </div>

                        <div class="clr"></div>
                    </div>
                    <div class="headert_text_resize">

                        <div class="clr"></div>
                        <h2 class="bigtext">&nbsp;</h2>
                        <h2 class="bigtext">&nbsp;</h2>
                        <h2 class="bigtext"><span>Timeslot</span><br />
                            Please select a timeslot to<br />
                            Confirm or Cancel your meeting. </h2>

                        <div class="clr"></div>
                    </div>
                </div>
                <div class="body">
                    <div class="body_resize">
                        <div class="left">
                            <p>
                                To confirm your meeting, please select a mode of your meeting::
                            </p>
                            <p>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Selected="True">Default Location</asp:ListItem>
                                    <asp:ListItem>Telephonic Meeting</asp:ListItem>
                                </asp:RadioButtonList>
                                &nbsp;
                            </p>
                            <p>
                                Select Time:<asp:DropDownList ID="avail" runat="server" Height="25px" Width="200px" OnSelectedIndexChanged="avail_SelectedIndexChanged" AutoPostBack="True" Style="margin-left: 150px"></asp:DropDownList>
                            </p>

                            <p>
                                Enter Contact Number:
                                <asp:TextBox ID="number" runat="server" ForeColor="#999999" Width="200px" BorderColor="#CCCCCC" BorderStyle="Solid" Height="23px" MaxLength="10" AutoPostBack="true" Style="margin-left: 64px"></asp:TextBox>

                            </p>
                            <p>
                                &nbsp;<asp:Button ID="ConfirmButton" runat="server" OnClick="ConfirmButton_Click" Text="Confirm" Style="margin-left: 293.5px" BackColor="#33CC33" ForeColor="Black" Height="38px" Width="110px" />

                            </p>

                            <div class="bg"></div>

                            <div class="submit">
                                <p>
                                    To cancel your meeting, click the cancel button below..
                                </p>
                                <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" Style="margin-left: 293.5px" BackColor="#FF3300" ForeColor="Black" Height="38px" Width="110px" />
                                &nbsp;
                            </div>

                            <div class="bg">
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
