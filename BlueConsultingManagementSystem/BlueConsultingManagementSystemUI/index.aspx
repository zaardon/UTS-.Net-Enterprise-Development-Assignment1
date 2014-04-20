<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BlueConsultingManagementSystemUI.index" %>
<!DOCTYPE html>
<link rel="stylesheet" href="css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home | Blue Consulting</title>
    <link rel="icon" type="image/ico" href="images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="style.css" />
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
         <br />
        <asp:Button ID="ConsultantBtn" runat="server" Text="Consultant" OnClick="ConsultantBtn_Click" CssClass="btn-lg btn-primary" />
        <p></p>
        <asp:Button ID="SuperStaffbtn" runat="server" Text="Supervisor and Staff" OnClick="SuperStaffbtn_Click" CssClass=" btn-lg btn-primary" />
        
        <p></p>
        

    </div>
    </form>
</body>
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="css/js/bootstrap.min.js"></script>
    <script src="css/js/docs.min.js"></script>
</html>
