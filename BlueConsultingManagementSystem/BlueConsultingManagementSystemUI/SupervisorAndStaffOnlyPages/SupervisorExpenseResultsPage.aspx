<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorExpenseResultsPage.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorExpenseResultsPage" %>

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
        <asp:Button ID="UnapprovedResultsButton" runat="server" Text="Unapproved" OnClick="UnapprovedResultsButton_Click" />
        <asp:Button ID="ExpenseResultsButton" runat="server" Text="Expense Results" OnClick="ExpenseResultsButton_Click" />
        <asp:Button ID="RejectedResultsButton" runat="server" Text="Rejected Submits" OnClick="RejectedResultsButton_Click" />
        
             <br />
             <br />
             <asp:GridView ID="GridView1" runat="server">
             </asp:GridView>
        
    </div>
    </form>
</body>
</html>
