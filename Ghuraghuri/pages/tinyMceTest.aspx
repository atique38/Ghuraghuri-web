<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tinyMceTest.aspx.cs" Inherits="Ghuraghuri.pages.tinyMceTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TinyMCE Text Editor Example</title>
    
    <script src="https://cdn.tiny.cloud/1/your-api-key/tinymce/5/tinymce.min.js" referrerpolicy="origin"></script>
    <script>
        tinymce.init({
            selector: '#myTextarea',
            height: 500,
            plugins: [
                'advlist autolink lists link image charmap print preview anchor',
                'searchreplace visualblocks code fullscreen',
                'insertdatetime media table paste code help wordcount'
            ],
            toolbar: 'undo redo | formatselect | bold italic backcolor | \
            alignleft aligncenter alignright alignjustify | \
            bullist numlist outdent indent | removeformat | help'
        });
    </script>
    <style>
        body {
            margin: 0;
            padding: 0;
        }
        textarea {
            width: 100%;
            height: 500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <textarea id="myTextarea"></textarea>
       <input type="hidden" id="hiddenField" name="hiddenField" />
        <asp:Button ID="submitButton" runat="server" Text="Button" OnClick="submitButton_Click"/>
    </form>
    <div id="data_container">
    </div>
    <script src="../javascript/tinyscript.js"></script>
</body>
</html>
