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
        <asp:TextBox ID="UserBox" runat="server" Text ="Username"></asp:TextBox> <br />
        <asp:TextBox ID="PassBox" runat="server" Text ="Password" ></asp:TextBox> <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /> <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="" Visble="false"></asp:Label>
    </div>
    </form>
</body>
</html>
