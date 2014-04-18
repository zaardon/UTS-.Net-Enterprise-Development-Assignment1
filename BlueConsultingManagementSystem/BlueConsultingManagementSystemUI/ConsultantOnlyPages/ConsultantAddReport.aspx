﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultantAddReport.aspx.cs" Inherits="BlueConsultingManagementSystemUI.ConsultantOnlyPages.ConsultantAddReport" %>

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
                <h1 class="panel-title" margin-left: 30%;> Blue management Consultant expense</h1>
                </div>
    <form id="form1" runat="server">
    <div>
    </div>
        <table style="width:300px">
<tr>
  <td>date</td>
  <td>
      <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
      </td> 
</tr>
            <tr>
                <td>Report name</td>
                <td>
                    <asp:TextBox ID="reportBox" runat="server"></asp:TextBox></td>
            </tr>
<tr>
  <td>location</td>
  <td>
      <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Text input"></asp:TextBox></td> 
</tr>
            <tr>
  <td>description</td>
  <td>
      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td> 
</tr>
            <tr>
  <td>amount</td>
  <td>
      <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  </td> 
</tr>
            <tr>
  <td>currency</td>
  <td>
      <asp:DropDownList ID="DropDownList1" runat="server">
          <asp:ListItem>AUD</asp:ListItem>
          <asp:ListItem>CNY</asp:ListItem>
          <asp:ListItem>ERU</asp:ListItem>
          <asp:ListItem>USD</asp:ListItem>
      </asp:DropDownList></td> 
</tr>

            <tr>
                <td> Department Type</td>
                <td> <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Value="HigherEducation">Higher Education Services</asp:ListItem>
                    <asp:ListItem Value="LogisticServices">Logistic Services</asp:ListItem>
                    <asp:ListItem Value="StateServices">State Services</asp:ListItem>
                    </asp:DropDownList></td>

            </tr>

<tr>
  <td>PDF RECEIPT</td>
  <td>
      <asp:FileUpload ID="FileUpload1" runat="server" /></td> 
</tr>


</table>
       

        

        <asp:Button ID="submitbtn" runat="server" OnClick="submitbtn_Click" Text="submit" />
       

        

    </form>
            </div>
         </div>
    
</body>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="../css/js/bootstrap.min.js"></script>
    <script src="../css/js/docs.min.js"></script>
</html>
