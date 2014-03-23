<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BlueConsultingManagementSystemUI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Welcome to the Blue Consulting Management System!
        <br />
        Please login
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Text ="Username"></asp:TextBox> <br />
        <asp:TextBox ID="TextBox2" runat="server" Text ="Password"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="Login" />
    </div>
    </form>
</body>
</html>
