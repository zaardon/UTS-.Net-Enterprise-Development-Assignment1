<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorUnapprovedResults.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorUnapprovedResults" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       
    <form id="form1" runat="server">
    <div>
     <div class="modal-dialog">
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title" margin-left: 30%;> Blue management Consultant Unapproved</h1>
                </div>
        <div id="padSpacer" align="center">
        <asp:GridView ID="UnapprovedReportsGridViewSQLConnection" runat="server" onrowcommand="UnapprovedReportsGridViewSQLConnection_RowCommand" CssClass="table table-responsive">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ReportName" ShowHeader="True" Text="View Report" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
            <asp:Button ID="BacktoSupervisor" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="BacktoSupervisor_Click" />
         
    </div>
         </div>
        </div>
    </form>
</body>
    
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>

</html>
