<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BlueConsultingManagementSystemUI.Login" %>

<!DOCTYPE html>
<link rel="stylesheet" href="css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="css/css/bootstrap.min.css" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>   
</head>
<body>
   <div class="modal-dialog">
        <div class ="panel panel-primary" style="align-content:center">  
            <div class="panel-heading">
             <h1 class="panel-title"> Blue management system</h1>
                </div>
          <div id="padSpacer" align="center">
        <form id="form1" runat="server" >
    
        <asp:Login ID="Login1" DestinationPageUrl="~/index.aspx" runat="server" CssClass="form-group"></asp:Login>     
    </form>
            </div>    
        </div>
       </div>
       <div class="well">
        <h3>Student numbers and UTS AND WHATE EVER ELSE
            </br>
            Also working on centring the elements in aspx.css is a pain
        </h3>
    </div>
</body>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="css/js/bootstrap.min.js"></script>
    <script src="css/js/docs.min.js"></script>

</html>
