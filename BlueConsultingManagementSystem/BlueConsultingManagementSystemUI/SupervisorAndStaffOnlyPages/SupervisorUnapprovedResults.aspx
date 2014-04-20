<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorUnapprovedResults.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorUnapprovedResults" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../css/css/bootstrap.min.css" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <div class="navbar navbar-inverse">

    <div class="container">
        <div class="navbar-header">
            <button class="navbar-toggle" data-target=".navbar-collapse" data-toggle="collapse" type="button">
                <span class="sr-only">

                    Toggle navigation

                </span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="../index.aspx">

                Blue Management Expense reporting

            </a>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">

                        Supervisor 

                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="SupervisorUnapprovedResults.aspx">

                                Unapproved expenses 

                            </a>
                        </li>
                        <li>
                            <a href="SupervisorExpenseTotalPage.aspx">

                                Department Budget

                            </a>
                        </li>
                        <li>
                            <a href="SupervisorOnlyPages/SupervisorRejectedReportsPage.aspx">

                                Rejected expenses

                            </a>
                        </li>
                                        
                    </ul>
                </li>
            </ul>
        </div>
        </div>
</div>
    <form id="form1" runat="server">
    <div>
     <div class="modal-dialog">
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title" margin-left: 30%;> Blue management Consultant Unapproved</h1>
                </div>
    
        <asp:GridView ID="UnapprovedReportsGridViewSQLConnection" runat="server" onrowcommand="UnapprovedReportsGridViewSQLConnection_RowCommand" CssClass="table table-responsive">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ReportName" ShowHeader="True" Text="View Report" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>
         </div>
        </div>
    </form>
</body>
    
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>

</html>
