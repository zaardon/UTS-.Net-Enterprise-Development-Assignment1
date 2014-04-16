<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMain.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="AddReportButton" runat="server" Text="Add a Report" OnClick="AddReportButton_Click" />
        <asp:Button ID="SubmittedReportsButton" runat="server" Text="View All Submitted Reports" OnClick="SubmittedReportsButton_Click" />
        <asp:Button ID="ApprovedReportsButton" runat="server" Text="View All Approved Reports" OnClick="ApprovedReportsButton_Click" />
        <asp:Button ID="UnapprovedReportsButton" runat="server" Text="View in Progress Report" OnClick="UnapprovedReportsButton_Click" />
    </div>
    </form>
</body>
</html>
