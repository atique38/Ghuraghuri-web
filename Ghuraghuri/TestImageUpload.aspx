<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestImageUpload.aspx.cs" Inherits="Ghuraghuri.TestImageUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
       <input type="file" name="imageFiles" accept="image/*" multiple="multiple"/>
        <br />
        <asp:Button ID="Upload" runat="server" Text="Submit" OnClick="Upload_Click" />
        <asp:Button ID="Display" runat="server" Text="Show" OnClick="Display_Click"/>
        <div id="container" runat="server">

        </div>

        <br />
        <br />
        <asp:FileUpload ID="fileUpload1" runat="server" />
        <asp:FileUpload ID="fileUpload2" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />


    </form>
</body>
</html>
