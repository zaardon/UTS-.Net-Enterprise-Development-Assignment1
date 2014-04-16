<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantSelectReportName.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantSelectReportName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="WelcomeMessage" runat="server" Text=""></asp:Label>
        <asp:GridView ID="CurrentReportNamesSQLConnection" runat="server" OnRowCommand="CurrentReportNamesSQLConnection_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ContinueReport" ShowHeader="True" Text="Continue Report" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="NewReportButton" runat="server" Text="New Report" OnClick="NewReportButton_Click" />
    </div>
    </form>
</body>
</html>
