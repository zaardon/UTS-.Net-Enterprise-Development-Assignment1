<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorAndStaffMain.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorAndStaffMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Your department level is:<br />
        <br />
        Please select the type of report you wish to view:<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Unapproved" />
        <asp:Button ID="Button2" runat="server" Text="Expense Results" />
        <asp:Button ID="Button3" runat="server" Text="Rejected Submits" />

    </div>
    </form>
</body>
</html>
