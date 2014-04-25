<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantSelectReportName.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantSelectReportName" %>

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
                <h1 class="panel-title"> Blue management Consultant expense - <asp:Label ID="WelcomeMessage" runat="server" Text=""></asp:Label></h1>
                </div>
             <div id="padSpacer" align="center">
    <form id="form1" runat="server">
    <div>
        
        
        <asp:GridView ID="CurrentReportNamesSQLConnection" runat="server" OnRowCommand="CurrentReportNamesSQLConnection_RowCommand" CssClass="table table-responsive">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" ShowHeader="True" Text="Continue Report" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="NewReportButton" runat="server" Text="New Report" OnClick="NewReportButton_Click" ControlStyle-CssClass="btn btn-primary"/>
        <p></p>
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
