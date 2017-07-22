<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="Interface.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            position: absolute;
            top: 389px;
            left: 559px;
            z-index: 1;
        }
        .auto-style5 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div style="position: absolute; width: 234px; height: 37px; z-index: 1; right: 847px; top: 14px; border-left-style: solid; border-left-color: #FFFFFF; border-right-style: solid; border-right-color: #FFFFFF; border-bottom-style: solid; border-bottom-color: #FFFFFF; background-color: #FFFFFF; float:left" id="layer1" align="left">
<p align="right"><font size="6" color="#800000">Appoint Mate V3</font></div>
<div align="right">
<table border="1" width="777" height="41" align="right">
<tr>
<td width="117" bordercolor="#800000" bgcolor="#800000" align="right">
<p align="center"><span dir="ltr"><font color="#FFFFFF" size="4">Home</font></span></td>
<td width="146" bordercolor="#800000" bgcolor="#800000" align="right">
<p align="center"><span dir="ltr"><font color="#FFFFFF" size="4">About us</font></span></td>
<td width="150" bordercolor="#800000" bgcolor="#800000" align="right">
<p align="center"><span dir="ltr"><font color="#FFFFFF" size="4">Book meeting</font></span></td>
<td width="137" bordercolor="#800000" bgcolor="#800000" align="right">
<p align="center"><span dir="ltr"><font color="#FFFFFF" size="4">Calendar</font></span></td>
<td width="193" bordercolor="#800000" bgcolor="#800000" align="right">
<p align="center"><span dir="ltr"><font color="#FFFFFF" size="4">My Profile</font></span></td>
</tr>
</table>
</div>
<p align="center">&nbsp;&nbsp;&nbsp; </p>

<hr>
<div align="center">
&nbsp;<p><u><font size="6"><b>Change Password</b></font></u></p>
<table border="1" width="40%" height="150">
<tr>
<td width="203"><font size="5">Current Password</font></td>
<td>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
        </td>
</tr>
<tr>
<td width="203"><font size="5">New Password</font></td>
<td>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </td>
</tr>
<tr>
<td width="203"><font size="5">Confirm Password</font></td>
<td>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
        </td>
</tr>
<tr>
<td colspan="2" class="auto-style5">
            <asp:Button ID="Button1" runat="server" CssClass="auto-style4" Text="Change Password" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
</tr>
</table>
<p>&nbsp;</div>
<hr>
<p align="center">© 2016 Appoint Mate V3 | Copyright &amp; Disclaimer | Created and 
Designed by Appointime Solutions</p>

    </form>
</body>
</html>
