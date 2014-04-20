<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorRejectedReportsPage.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SuperVisorOnlyPages.SupervisorRejectedReportsPage" %>

<!DOCTYPE html>
<link rel="stylesheet" href="../../css/css/bootstrap-theme.css" type="text/css">
<link rel="stylesheet" href="../../css/css/bootstrap.min.css" type="text/css" />
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
            <a class="navbar-brand" href="../../index.aspx">

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
                            <a href="../SupervisorUnapprovedResults.aspx">

                                Unapproved expenses 

                            </a>
                        </li>
                        <li>
                            <a href="../SupervisorExpenseTotalPage.aspx">

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
        Rejected results:
        <asp:GridView ID="RejectedResultsGridViewSQLConnection" runat="server" OnRowCommand="RejectedResultsGridViewSQLConnection_RowCommand" CssClass="table-responsive table-condensed">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="ViewReport" ShowHeader="True" Text="View Report" ControlStyle-CssClass="btn btn-primary"/>
            </Columns>
        </asp:GridView>
        
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
