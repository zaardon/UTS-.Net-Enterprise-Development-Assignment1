<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffViewReportDetails.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.StaffOnlyPages.StaffViewReportDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="ApprovedReportDetailsSQLConnection" runat="server" OnRowCommand="ApprovedReportDetailsSQLConnection_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReceipt" ShowHeader="True" Text="Receipt" />
            </Columns>
        </asp:GridView>
    </div>
                <div class="modal-dialog">
    <div class="alert-danger">
    <asp:Label ID="excLbl" runat="server" Text=""></asp:Label>
        </div>
        </div>
    </form>
</body>
</html>
