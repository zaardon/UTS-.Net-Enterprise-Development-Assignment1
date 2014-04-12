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
        <asp:GridView ID="RejectedResultsGridViewSQLConnection" runat="server" OnRowCommand="RejectedResultsGridViewSQLConnection_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReport" ShowHeader="True" Text="View Report" />
            </Columns>
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
