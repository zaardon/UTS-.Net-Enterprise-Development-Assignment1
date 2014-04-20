<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantViewReportHistoryExpenses.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantViewReportHistoryExpenses" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


       <div class="modal-dialog">
        <div class ="panel panel-primary" style="align-content:center">
            <div class="panel-heading">
             <h1 class="panel-title"> Blue management system - Report Name :
                 <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </h1>
                </div>
          <div id="padSpacer" align="center">
      <form id="form1" runat="server">
    <div>

<asp:GridView ID="ReportExpenseHistoryDetailsSQLConnection" runat="server" OnRowCommand="ReportExpenseHistoryDetailsSQLConnection_RowCommand" CssClass="table-responsive">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReceipt" ShowHeader="True" Text="Receipt" ControlStyle-CssClass="btn-primary" />
            </Columns>
        </asp:GridView>
    </div>
         <asp:Button ID="BackButton" runat="server" Text="Back" ControlStyle-CssClass="btn btn-primary" OnClick="BackButton_Click" />
   
           </div>
        </div>
       </div>
    
    </form>
</body>
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
