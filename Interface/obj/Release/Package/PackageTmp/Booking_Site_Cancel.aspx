<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking_Site_Cancel.aspx.cs" Inherits="Interface.WebForm12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cancel Meeting</title>
     <link href="index.css" rel="stylesheet" type="text/css" />
    
        <!-- Function to "disable" back button (just redirects user to this page again) -->
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

</head>
<body>
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
                        <h2 class="bigtext"><span>Cancel Meeting</span>
                            <br />
                            Please provide the reason for cancellation.
                    <br />
                            
                        </h2>

                        <div class="clr"></div>
                    </div>
                </div>
                <div class="body">
                    <div class="body_resize">
                        <div class="left">
                            <h2>Reason</h2>
                            <p>
                               <asp:TextBox ID="reason" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Height="127px" Width="370px" MaxLength="250" TextMode="MultiLine"></asp:TextBox>

                             <br /> 
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="reason" ErrorMessage="Please enter cancellation reason max Input 240 characters " ForeColor="Red" ValidationExpression="^[\s\S]{1,245}$" ValidationGroup="cancel" Display="Dynamic"></asp:RegularExpressionValidator>

                                

                            </p>
                            <div class="bg"></div>
                            

                            <div class="submit">
                               
        
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel "  ValidationGroup =" cancel"/>
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
