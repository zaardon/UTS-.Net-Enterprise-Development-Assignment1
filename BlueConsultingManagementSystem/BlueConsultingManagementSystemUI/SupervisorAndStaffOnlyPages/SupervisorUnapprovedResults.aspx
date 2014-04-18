<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorUnapprovedResults.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorUnapprovedResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

         RENAME THIS PAGE!!!!
    Unapproved report results:
        <asp:GridView ID="UnapprovedReportsGridViewSQLConnection" runat="server" onrowcommand="UnapprovedReportsGridViewSQLConnection_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ReportName" ShowHeader="True" Text="View Report" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
