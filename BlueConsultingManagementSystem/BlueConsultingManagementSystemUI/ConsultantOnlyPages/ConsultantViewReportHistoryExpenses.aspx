<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantViewReportHistoryExpenses.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantViewReportHistoryExpenses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="ReportExpenseHistoryDetailsSQLConnection" runat="server" OnRowCommand="ReportExpenseHistoryDetailsSQLConnection_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReceipt" ShowHeader="True" Text="Receipt" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
