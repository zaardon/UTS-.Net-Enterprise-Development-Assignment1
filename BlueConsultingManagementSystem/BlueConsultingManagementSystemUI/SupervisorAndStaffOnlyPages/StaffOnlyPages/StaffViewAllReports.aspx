<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffViewAllReports.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.StaffViewAllReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="AllApprovedReportsGridViewSQLConnection" runat="server" >
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReport" ShowHeader="True" Text="View Report" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
