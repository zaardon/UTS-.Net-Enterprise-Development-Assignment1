<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantAddReport.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantAddReport" %>

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
        <div class ="panel panel-primary"  >  
            <div class="panel-heading">
                <h1 class="panel-title"> Blue management Consultant expense</h1>
                </div>
             <div id="padSpacer" align="center">
    <form id="form1" runat="server">
    <div>
    </div>
        <table style="width:300px">

            <tr>
                <td>Report name</td>
                <td>
                    <asp:TextBox ID="reportBox" runat="server" CssClass="form-control" placeholder="Enter Report Name"></asp:TextBox></td>
            </tr>
<tr>
  <td>location</td>
  <td>
      <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter location of Expense"></asp:TextBox></td> 
</tr>
            <tr>
  <td>description</td>
  <td>
      <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Enter Description of Expense"></asp:TextBox></td> 
</tr>
            <tr>
  <td>amount</td>
  <td>
      <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Enter Amount of Expense"></asp:TextBox>  </td> 
</tr>
            <tr>
  <td>currency</td>
  <td>
      <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" >
          <asp:ListItem>AUD</asp:ListItem>
          <asp:ListItem>CNY</asp:ListItem>
          <asp:ListItem>EUR</asp:ListItem>
      </asp:DropDownList></td> 
</tr>

            <tr>
                <td> Department Type</td>
                <td> <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" >
                    <asp:ListItem Value="HigherEducation">Higher Education Services</asp:ListItem>
                    <asp:ListItem Value="LogisticServices">Logistic Services</asp:ListItem>
                    <asp:ListItem Value="StateServices">State Services</asp:ListItem>
                    </asp:DropDownList></td>

            </tr>

<tr>
  <td>PDF RECEIPT</td>
  <td>
      <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-primary" /></td> 
</tr>
            <tr>
  <td>date</td>
  <td>
      <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
      </td> 
</tr>


</table>
       

        

        <asp:Button ID="submitbtn" runat="server" OnClick="submitbtn_Click" Text="submit" CssClass="btn-lg btn-primary" />
       

        

    </form>
            </div>
         </div>
    </div>
</body>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
