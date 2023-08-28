<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmWelcome.aspx.cs" Inherits="taks28.FrmWelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Label ID="lblusername" runat="server"/>
            <asp:Label ID="lblUsertype" runat="server"/>
            <%--<a href="FrmManagerReport.aspx">Reports</a>--%>
            <asp:LinkButton ID="LnkReport" runat="server" OnClick="LnkReport_Click">Reports</asp:LinkButton>
        </div>
    </form>
</body>
</html>
