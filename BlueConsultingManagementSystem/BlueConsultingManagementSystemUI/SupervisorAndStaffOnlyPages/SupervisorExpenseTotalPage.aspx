<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorExpenseTotalPage.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorExpenseTotalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Total expenses for your department,
        <asp:Label ID="DepartmentLabel" runat="server" Text=""></asp:Label>
    
        , are:
        <asp:Label ID="TotalExpenses" runat="server" Text=""></asp:Label>
    
        <br />
        Remaining budget for your department is:
        <asp:Label ID="RemainingBudget" runat="server" Text=""></asp:Label>
    
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    
    </div>
    </form>
</body>
</html>
