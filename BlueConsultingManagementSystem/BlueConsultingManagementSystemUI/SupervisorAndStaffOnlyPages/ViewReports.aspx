<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.ViewReports" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../css/css/bootstrap.min.css" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title"> Blue management Consultant expense -
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                </h1>
                </div>
             <div id="padSpacer" align="center">
    <form id="form1" runat="server">
      <div>
    </div>
       

            <br />

        <br />

        <asp:GridView ID="DisplayResultsGridSQLConnection" runat="server" onrowcommand="DisplayResultsGridSQLConnection_RowCommand" CssClass="table-condensed">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Receipt" ShowHeader="True" Text="Receipt" ControlStyle-CssClass="btn btn-primary"  />
            </Columns>
        </asp:GridView>
    

        <asp:Label ID="CurrentAmount" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="ApproveButton" runat="server" Text="Approve" OnClick="ApproveButton_Click" CssClass="btn-success" />
        <asp:Button ID="DenyButton" runat="server" Text="Deny" OnClick="DenyButton_Click" CssClass="btn-danger"/>
             <br />
        
             <br />
             <asp:Label ID="ConfirmLabel" runat="server" Text="Are you sure you want to confirm?" Visible="false"></asp:Label>
             <br />
             <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" Visible=" false" OnClick="ConfirmButton_Click" CssClass="btn-info" />
             <br />
            <p>

            </p>
            <asp:Button ID="BacktoSupervisor" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="BacktoSupervisor_Click" />
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
