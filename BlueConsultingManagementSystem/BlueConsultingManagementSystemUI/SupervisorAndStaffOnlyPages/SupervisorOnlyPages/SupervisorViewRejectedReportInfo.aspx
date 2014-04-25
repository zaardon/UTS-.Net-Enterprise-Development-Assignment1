<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorViewRejectedReportInfo.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorOnlyPages.SupervisorViewRejectedReportInfo" %>

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
                <h1 class="panel-title"> Blue management Consultant expense  

                </h1>
                </div>
            <div id="padSpacer" align="center">
    <form id="form1" runat="server">
<div>
    </div>
        <asp:GridView ID="RejectedReportInfoSQLConnection" runat="server" OnRowCommand="RejectedReportInfoSQLConnection_RowCommand" CssClass="table-condensed">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Receipt" ShowHeader="True" Text="Receipt" ControlStyle-CssClass="btn-primary"/>
            </Columns>
        </asp:GridView>
        <asp:Button ID="BacktoSupervisor" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="BacktoSupervisor_Click" />
    </div>
                                   </div>
         </div>
                        <div class="modal-dialog">
    <div class="alert-danger">
    <asp:Label ID="excLbl" runat="server" Text=""></asp:Label>
        </div>
        </div>
    </form>
                    
</body>
             <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
