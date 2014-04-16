<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantViewReportHistory.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantViewReportHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="ConsultantHistorySQLConnection" runat="server" OnRowCommand="ConsultantHistorySQLConnection_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReport" ShowHeader="True" Text="View Report" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
