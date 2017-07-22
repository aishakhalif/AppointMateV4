<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Interface.Calendar" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title><link href="index.css" rel="stylesheet" type="text/css" /><script language="javascript" type="text/javascript">

          //function to print the meeting details
          function PrintPage(printDiv) {
              var printContents = document.getElementById(printDiv).innerHTML;
              var originalContents = document.body.innerHTML;
              document.body.innerHTML = printContents;
              window.print();
              document.body.innerHTML = originalContents;
          }

    </script>
    <style type="text/css">
        #printDiv {
            height: 355px;
            margin-top: 13px;
        }
    </style>
</head><body><form id="form1" runat="server">
        
        <div class="main">
            <div class="header">
                <div class="header_resize">
                    <div class="logo">
                        <h1><a href="index.aspx"><small></small>
                            <br />
                         
                            </a></h1>
                    </div>
                    <div class="logo_text"><div class="submit">
                                <asp:Button ID="logout" runat="server" OnClick="logout_Click1" Text="Logout" />
                            </div></div>
                    <div class="clr"></div>
                </div>
                <div class="headert_text_resize">
                    <div class="menu">
                       
                        <ul>
                            <li><a href="index.aspx">Home</a></li>
                            <li><a href="Book_Meeting.aspx" >Book Meeting</a></li>
                            <li><a href="Profile.aspx">Profile</a></li>
                            <li><a href="Calendar.aspx" class="active">Calendar</a></li>
               <li><a href="Change_Password.aspx">   Change Password</a></li>
                        </ul>
                    </div>
                    <div class="clr"></div>
                    <h2 class="bigtext"><span>Calendar</span>
                    <br />
                    View meetings and annotations.</h2>

                    <div class="clr"></div>
                </div>
            </div>
            <div class="body">
                <div class="body_resize">
                    <div class="left">

                        
                            <div class="calendarWrapper">

                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="303px" Width="556px" NextPrevFormat="FullMonth" style="margin-left: 38px" OnSelectionChanged="Calendar1_SelectionChanged">
                                    <DayHeaderStyle BackColor="#25BAE4" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <TitleStyle BackColor="#ff4500" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                </asp:Calendar>
                                </div>
                        
                    
                        <div class="bg">

                            <div runat="server" id ="printDiv">

                            <br />
                            <asp:Label ID="MeetingDateLabel" runat="server" Text="Date" style="margin-left: 81px" ></asp:Label>
                            <br />
                            <asp:TextBox ID="MeetingDate" runat="server" style="margin-left: 81px" Width="320px" OnTextChanged="MeetingDate_TextChanged" ReadOnly ="true"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="ConfirmedMeeting_Label" runat="server" Text="Confirmed Appointments" style="margin-left: 81px"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ConfirmedMeetings" runat="server" style="margin-left: 81px"  Width="320px" OnSelectedIndexChanged ="ConfirmedMeetings_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Label ID="MeetingTitle" runat="server" Text="Meeting Title" Width="320px" style="margin-left: 81px"></asp:Label>
                            <br />
                            <asp:TextBox ID="MeetingTitleTxtbox" runat="server" Width="320px" style="margin-left: 81px" ReadOnly ="true"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="AttendeeName_label" runat="server" Text="Attendee Name" Width="320px" style="margin-left: 81px"></asp:Label>
                            <br />
                            <asp:TextBox ID="AttendeeName" runat="server" Width="320px" style="margin-left: 81px" ReadOnly ="true"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="AnnotationsLabel" runat="server" Text="Annotations" style="margin-left: 81px"></asp:Label>
                            <br />
                            <asp:TextBox ID="annotationsbox" runat="server" Height="62px" Width="320px" BorderColor="#CCCCCC" BorderStyle="Solid" MaxLength="250" TextMode="MultiLine"  style="margin-left: 81px"/>
                            <br />
                            <br />

                            </div>

                            <br />
                            <asp:Button ID="SaveButton" runat="server" Text="Save Changes" OnClick= "SaveChanges_Click" style="margin-left: 81px"/>
                            <br />
                            <br />
                           <asp:LinkButton ID="PrintButton" runat="server" Text="Print Data" tooltip="Click to Print All Records" OnClientClick="PrintPage('printDiv')" style="margin-left: 81px" OnClick="LinkButton1_Click"></asp:LinkButton>
                            <br />
                            <br />
                             
                            </div> 
                           
                        
                   

                    </div>
                </div>
              
            </div>
        
        
          <div class="clr">
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
          </div>
      
        <div class="footer">
            <div class="footer_resize">
                <p>© 2016 Appoint Mate V3 | Copyright & Disclaimer | Created and Designed by Appointime Solutions</p>
            </div>
            <div class="clr"></div>
        </div>


</div>

    
                    
               
                    
              
    </form>
</body>
</html>

