<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantMain.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantMain" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <div class="modal-header">
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title"> Blue management Consultant Expense</h1>
                </div>
             <div id="padSpacer" align="center">
    <form id="form1" runat="server">
    <div>
    </div>
        <asp:Button ID="AddReportButton" runat="server" Text="Add a Report" OnClick="AddReportButton_Click" CssClass="btn-primary" />
        <asp:Button ID="SubmittedReportsButton" runat="server" Text="View All Submitted Reports" OnClick="SubmittedReportsButton_Click" CssClass="btn-primary" />
        <asp:Button ID="ApprovedReportsButton" runat="server" Text="View All Approved Reports" OnClick="ApprovedReportsButton_Click" CssClass="btn-primary" />
        <asp:Button ID="UnapprovedReportsButton" runat="server" Text="View in Progress Report" OnClick="UnapprovedReportsButton_Click" CssClass="btn-primary"/>
        <p>

        </p>
        <asp:Button ID="BackButton" runat="server" Text="Back" ControlStyle-CssClass="btn btn-primary" OnClick="BackButton_Click" />
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
