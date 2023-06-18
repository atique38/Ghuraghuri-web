<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tinytest2.aspx.cs" Inherits="Ghuraghuri.tinyMce.tinytest2" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <!-- TinyMCE -->
    <script src="https://cdn.tiny.cloud/1/50329fnhhsmfbw7fsesrmwiq80a65hstmtg6fnmy7tji98ep/tinymce/6/tinymce.min.js" referrerpolicy="origin"></script>
    <script>
      tinymce.init({
        selector: 'textarea#tiny',
            plugins: [
            'a11ychecker','advlist','advcode','advtable','autolink','checklist','export',
            'lists','link','image','charmap','preview','anchor','searchreplace','visualblocks',
            'powerpaste','fullscreen','formatpainter','insertdatetime','media','table','help','wordcount'
            ],
            toolbar: 'undo redo | a11ycheck casechange blocks | bold italic backcolor | alignleft aligncenter alignright alignjustify |' +
            'bullist numlist checklist outdent indent | removeformat | code table help'
      })
    </script>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <textarea id="tiny" runat="server"></textarea>
            <input type="hidden" id="hiddenField" name="hiddenField"/>
            <asp:Button ID="Button1" runat="server" Text="Get Data" OnClick="Button1_Click"/>

            <div runat="server" id="newdiv">

            </div>
        </div>
    </form>
    <script src="../javascript/tinyscript.js"></script>
</body>
</html>
