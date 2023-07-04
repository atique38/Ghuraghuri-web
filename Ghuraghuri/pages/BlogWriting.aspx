<%@ Page Title="Write Blog" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BlogWriting.aspx.cs" Inherits="Ghuraghuri.pages.WebForm7" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="https://cdn.tiny.cloud/1/no-api-key/tinymce/6/tinymce.min.js" referrerpolicy="origin"></script>
    <script>
        tinymce.init({
            selector: "#<%= tiny.ClientID %>",
            plugins: [
                'a11ychecker', 'advlist', 'advcode', 'advtable', 'autolink', 'checklist', 'export',
                'lists', 'link', 'image', 'charmap', 'preview', 'anchor', 'searchreplace', 'visualblocks',
                'powerpaste', 'fullscreen', 'formatpainter', 'insertdatetime', 'media', 'table', 'help', 'wordcount'
            ],
            toolbar: 'undo redo | a11ycheck casechange blocks | bold italic backcolor | alignleft aligncenter alignright alignjustify |' +
                'bullist numlist checklist outdent indent | removeformat | code table help'
        });
    </script>
    <link href="../css/style_editor.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="blog_title">
         <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Title</p>
                     <asp:TextBox ID="BlogTitle" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
             </div>
             <div class="photo">
            
                 <h4>Featured Photo:<span style="color:#ff0000">*</span></h4>
                 <asp:FileUpload ID="featuredUpload" runat="server" Accept=".jpg, .jpeg, .png, .gif" style="margin-top:.5rem" />
          
            </div>
         </div>
     </section>
    <div class="editor">
        <asp:TextBox ID="tiny" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
    <asp:Button ID="SubmitBlog" runat="server" Text="Submit" class="btn" OnClick="SubmitBlog_Click"/>
</asp:Content>
