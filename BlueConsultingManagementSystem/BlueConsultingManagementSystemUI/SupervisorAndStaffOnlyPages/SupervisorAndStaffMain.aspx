<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorAndStaffMain.aspx.cs" Inherits="BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorAndStaffMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         Please select the type of report you wish to view:<br />
        <br />
        <asp:Button ID="UnapprovedResultsButton" runat="server" Text="Unapproved" OnClick="UnapprovedResultsButton_Click" />
        <asp:Button ID="ExpenseResultsButton" runat="server" Text="Expense Results" OnClick="ExpenseResultsButton_Click" />
        <asp:Button ID="RejectedResultsButton" runat="server" Text="Rejected Submits" OnClick="RejectedResultsButton_Click" />
        

        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Higher Education" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="HigherEducationGridViewSQLConnection" Visible="False" runat="server" onrowcommand="HigherEducationGridViewSQLConnection_RowCommand" >
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Report" ShowHeader="True" Text="View Report" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Logistic Services" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="LogisticServicesGridViewSQLConnection" Visible="false"  runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="Label3" runat="server" Text="State Services" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="StateServicesGridViewSQLConnection" Visible="false"  runat="server">
        </asp:GridView>


    </div>
    </form>
</body>
</html>
