<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorAndStaffMain.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorAndStaffMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         Please select the type of report you wish to view:<br />
        <br />
        <asp:Button ID="ReportsButton" runat="server" Text="Reports" OnClick="ReportsButton_Click" />
        <asp:Button ID="ExpenseResultsButton" runat="server" Text="Expense Results" OnClick="ExpenseResultsButton_Click" />
        <asp:Button ID="RejectedResultsButton" runat="server" Text="Rejected Submits" OnClick="RejectedResultsButton_Click" />
        

        <br />
    </div>
    </form>
</body>
</html>
