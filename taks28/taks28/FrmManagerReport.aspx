<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmManagerReport.aspx.cs" Inherits="taks28.FrmManagerReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" />
           <%-- <asp:GridView ID="dtGrid" runat="server">
            </asp:GridView>--%>
            <asp:GridView id="dtGrid" runat="server" AutoGenerateColumns="false" OnRowDataBound="dtGrid_RowDataBound">
            <Columns>
                <asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" />
                <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" />
                <asp:BoundField DataField="LAST_LOGIN_DATE" HeaderText="Login Date" />
                <asp:BoundField DataField="USER_CNT" HeaderText="User Count" />
                 <asp:BoundField DataField="IMAGE_NAME" HeaderText="Image Name" />
                <asp:TemplateField HeaderText="User Image">
                    <ItemTemplate>
                        <asp:Image runat="server" id="USER_IMAGE" Height="100" Width="100" CssClass="zoomable-image" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                 </asp:GridView>
            <div id="dialog" style="display: none">
</div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/start/jquery-ui.css" />
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>
<script type="text/javascript">
    $(function () {
        $(".zoomable-image").click(function () {
            var imageUrl = $(this).attr('src');
            $('#dialog').html('<img src="' + imageUrl + '" />');
            $('#dialog').dialog({
                autoOpen: true,
                modal: true,
                height: 'auto',
                width: 'auto',
                title: "Zoomed Image"
            });
        });
    });
</script>