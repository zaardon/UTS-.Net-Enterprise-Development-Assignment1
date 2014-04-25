<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantAddReport.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantAddReport" %>

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
      <asp:TextBox ID="LocationBox" runat="server" CssClass="form-control" placeholder="Enter location of Expense"></asp:TextBox></td> 
</tr>
            <tr>
  <td>description</td>
  <td>
      <asp:TextBox ID="DescriptionBox" runat="server" CssClass="form-control" placeholder="Enter Description of Expense"></asp:TextBox></td> 
</tr>
            <tr>
  <td>amount</td>
  <td>
      <asp:TextBox ID="AmountBox" runat="server" CssClass="form-control" placeholder="Enter Amount of Expense"></asp:TextBox>  </td> 
</tr>
            <tr>
  <td>currency</td>
  <td>
      <asp:DropDownList ID="CurrencyList" runat="server" CssClass="form-control" >
          <asp:ListItem>AUD</asp:ListItem>
          <asp:ListItem>CNY</asp:ListItem>
          <asp:ListItem>EUR</asp:ListItem>
      </asp:DropDownList></td> 
</tr>

            <tr>
                <td> Department Type</td>
                <td> <asp:DropDownList ID="DepartmentList" runat="server" CssClass="form-control" >
                    <asp:ListItem Value="HigherEducation">Higher Education Services</asp:ListItem>
                    <asp:ListItem Value="LogisticServices">Logistic Services</asp:ListItem>
                    <asp:ListItem Value="StateServices">State Services</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="DeptLabel" runat="server" Text="" Visible ="false"></asp:Label>
                </td>

            </tr>
            <tr>
  <td>Date</td>
  <td>
      <asp:Calendar ID="ExpenseCalendar" runat="server"></asp:Calendar>
      </td> 
</tr>
<tr>
  <td>PDF RECEIPT</td>
  <td>
      <asp:FileUpload ID="PDFFileUpload" runat="server" CssClass="btn-primary" /></td> 
</tr>



</table>
       

        

        <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" CssClass="btn-lg btn-primary" />
       
       <p>

       </p>
        <asp:Button ID="BackButton" runat="server" Text="Back" ControlStyle-CssClass="btn btn-primary" OnClick="BackButton_Click" />
        

    </form>
            </div>
         </div>
    </div>
    <div class="modal-dialog">
    <div class="alert-danger">
    <asp:Label ID="excLbl" runat="server" Text=""></asp:Label>
        </div>
        </div>
</body>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
