<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorRejectedReportsPage.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SuperVisorOnlyPages.SupervisorRejectedReportsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Rejected results:
        <asp:GridView ID="RejectedResultsGridViewSQLConnection" runat="server"></asp:GridView>
        
    </div>
    </form>
</body>
</html>
