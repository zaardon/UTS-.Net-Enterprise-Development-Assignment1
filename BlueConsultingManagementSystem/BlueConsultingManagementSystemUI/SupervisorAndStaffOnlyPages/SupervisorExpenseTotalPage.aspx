<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorExpenseTotalPage.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorExpenseTotalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            RENAME THIS PAGE!!!!
        <asp:Label ID="TotalExpenses" runat="server" Text=""></asp:Label>
    
        <br />
        <asp:Label ID="RemainingBudget" runat="server" Text=""></asp:Label>
    
        <br />
        <br />
        <asp:GridView ID="AllDepartmentExpensesGridViewSQLConnection" runat="server" Visible="false">
        </asp:GridView>
    
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    
    </div>
    </form>
</body>
</html>
