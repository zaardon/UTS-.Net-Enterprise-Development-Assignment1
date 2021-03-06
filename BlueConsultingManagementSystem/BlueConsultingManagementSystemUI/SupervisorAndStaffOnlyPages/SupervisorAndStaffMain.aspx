﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorAndStaffMain.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorAndStaffMain" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="modal-dialog">
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title"> Welcome to the Blue Consulting Management System!</h1>
                </div>
             <div id="padSpacer" align="center">
    <form id="form1" runat="server">
     <div>
    </div>
         Please select the type of report you wish to view:<br />
        <br />
        <asp:Button ID="ReportsButton" runat="server" Text="Consultant Unapproved Reports" OnClick="ReportsButton_Click" CssClass="btn-primary"  />
        <asp:Button ID="ApprovedReportsButton" runat="server" Text="Supervisor Unapproved Reports" Visible = "false" OnClick="ApprovedReportsButton_Click" CssClass="btn-primary" />
        <asp:Button ID="ExpenseResultsButton" runat="server" Text="Expense Results" OnClick="ExpenseResultsButton_Click" CssClass="btn-primary" />
        <asp:Button ID="RejectedResultsButton" runat="server" Text="Rejected Submits" OnClick="RejectedResultsButton_Click" CssClass="btn-primary" />
        
        

        <br />
        <p>

        </p>
        <asp:Button ID="BacktoSupervisor" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="BacktoSupervisor_Click" />
         
    </div>
    </form>
</body>
                   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
