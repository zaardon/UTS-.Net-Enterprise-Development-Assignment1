<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorViewRejectedReports.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SuperVisorOnlyPages.SupervisorViewRejectedReports" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     
     <div class="modal-dialog">
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title"> Blue Management Consultant Expense  

                </h1>
                </div>
            <div id="padSpacer" align="center">
    <form id="form1" runat="server">
    <div>
    </div>
        Rejected Results:
        <asp:GridView ID="RejectedResultsGridViewSQLConnection" runat="server" OnRowCommand="RejectedResultsGridViewSQLConnection_RowCommand" CssClass="table-responsive table-condensed">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Report" ShowHeader="True" Text="View Report" ControlStyle-CssClass="btn btn-primary"/>
            </Columns>
        </asp:GridView>
         <asp:Button ID="BacktoSupervisor" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="BacktoSupervisor_Click" />
    </div>
           
         
    </form>
                               </div>
         </div>
    </div>
</body>
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
