<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGrigview.aspx.cs" Inherits="Ghuraghuri.TestGrigview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Column 1" />
                <asp:BoundField DataField="email" HeaderText="Column 2" />
                <asp:BoundField DataField="password" HeaderText="Column 3" />
                <asp:BoundField DataField="profile_image" HeaderText="Column 4" />
               
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
