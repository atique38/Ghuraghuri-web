<%@ Page Title="" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Ghuraghuri.pages.WebForm13" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_add_tour.css" rel="stylesheet" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="add_product">
        <div class="box">
          <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name<span style="color:#ff0000">*</span></p>
                     <asp:TextBox ID="pd_name" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
             </div>
         </div>
     </div>
        <div class="box">
          <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Price(TK)<span style="color:#ff0000">*</span></p>
                     <asp:TextBox ID="Cost" runat="server"  class="inp" TextMode="Number"></asp:TextBox>
                 </div>
                 <hr>
             </div>
         </div>
     </div>
        <div class="box">
          <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Quantity<span style="color:#ff0000">*</span></p>
                     <asp:TextBox ID="pd_quantity" runat="server"  class="inp" TextMode="Number"></asp:TextBox>
                 </div>
                 <hr>
             </div>
         </div>
     </div>
     <div class="photo">
        <h4>Product Photos:<span style="color:#ff0000">*</span></h4>
             
        <asp:FileUpload ID="galleryUpload" runat="server" AllowMultiple="true" Accept=".jpg, .jpeg, .png, .gif" style="margin-top:.5rem" name="galleryUpload"/>
        <h4>Featured Photo:<span style="color:#ff0000">*</span></h4>
             
        <asp:FileUpload ID="featuredUpload" runat="server" Accept=".jpg, .jpeg, .png, .gif" style="margin-top:.5rem" />
          
     </div>
   </section>

    <h4 style="margin-left:1.5rem">Details:<span style="color:#ff0000">*</span></h4>
    <div class="editor">
        <asp:TextBox ID="tiny" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
     <asp:Button ID="SubmitProduct" runat="server" Text="Submit" class="btn" OnClick="SubmitProduct_Click"/>
</asp:Content>
