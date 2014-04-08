<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorReportsDisplayPage.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorReportsDisplayPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <asp:GridView ID="DisplayResultsGridSQLConnection" runat="server"></asp:GridView>
    </div>

        <asp:Label ID="CurrentAmount" runat="server" Text="The current amount is: "></asp:Label>
        <asp:Label ID="DisplayNumber" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="ApproveButton" runat="server" Text="Approve" OnClick="ApproveButton_Click" />
        <asp:Button ID="DenyButton" runat="server" Text="Deny" OnClick="DenyButton_Click" />
             <br />
        
             <br />
             <asp:Label ID="ConfirmLabel" runat="server" Text="Are you sure you want to confirm?" Visible="false"></asp:Label>
             <br />
             <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" Visible=" false" />
             <br />
    </form>
</body>
</html>
