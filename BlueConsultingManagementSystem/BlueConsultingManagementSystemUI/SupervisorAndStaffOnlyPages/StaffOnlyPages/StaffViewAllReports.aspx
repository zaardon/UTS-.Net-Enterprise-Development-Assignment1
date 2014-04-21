<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffViewAllReports.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.StaffViewAllReports" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="modal-dialog">
        <div class ="panel panel-primary" style="align-content:center">
            <div class="panel-heading">
             <h1 class="panel-title"> Blue management system 
                 
                </h1>
                </div>
          <div id="padSpacer" align="center">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="AllApprovedReportsGridViewSQLConnection" runat="server" OnRowCommand="AllApprovedReportsGridViewSQLConnection_RowCommand" CssClass="table table-responsive">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReport" ShowHeader="True" Text="View Report" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" CssClass="btn btn-primary" />
    </div>
    </form>
</body>
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
