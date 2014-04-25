<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewExpenseTotal.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.ViewExpenseTotal" %>

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
                <h1 class="panel-title"> Blue management Consultant expense -
                    
                </h1>
                </div>
             <div id="padSpacer" align="center">
    <form id="form1" runat="server">
         <div>
    </div>
           
        <asp:Label ID="TotalExpenses" runat="server" Text=""></asp:Label>
    
        <br />
        <asp:Label ID="RemainingBudget" runat="server" Text=""></asp:Label>
    
        <br />
        <br />
        <asp:GridView ID="AllDepartmentExpensesGridViewSQLConnection" runat="server" Visible="false">
        </asp:GridView>
    
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" CssClass="btn btn-primary" />
    
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
