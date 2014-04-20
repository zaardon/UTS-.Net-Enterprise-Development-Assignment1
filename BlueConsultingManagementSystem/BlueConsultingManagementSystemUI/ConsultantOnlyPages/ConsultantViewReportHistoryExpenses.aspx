<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantViewReportHistoryExpenses.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantViewReportHistoryExpenses" %>

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

                        Consultant 

                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="ConsultantSelectReportName.aspx">

                                Add a expense 

                            </a>
                        </li>
                        <li>
                            <a href="ConsultantViewReportHistory.aspx">

                                View All submitted reports 

                            </a>
                        </li>
                        <li>
                            <a href="ConsultantViewReportHistory.aspx">

                                View all Approved reports

                            </a>
                        </li>
                        <li>
                            <a href="ConsultantViewReportHistory.aspx">

                                View in progress reports

                            </a>
                        </li>
                      
                    </ul>
                </li>
            </ul>
        </div>
        </div>
</div>  
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
        <asp:GridView ID="ReportExpenseHistoryDetailsSQLConnection" runat="server" CssClass="table table-responsive"></asp:GridView>
    </div>
           </div>    
        </div>
       </div>
    </form>
</body>
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
