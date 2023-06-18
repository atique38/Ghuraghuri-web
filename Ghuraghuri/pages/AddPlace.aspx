<%@ Page Title="" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddPlace.aspx.cs" Inherits="Ghuraghuri.pages.WebForm9" ValidateRequest="false" %>
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
        })
    </script>
    <link href="../css/style_add_place.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="add_tour">
        <div class="box">
          <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Place Name<span style="color:#ff0000">*</span></p>
                     <asp:TextBox ID="PlaceName" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
             </div>
         </div>
     </div>
        <div class="box">
          <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Type<span style="color:#ff0000">*</span></p>
                     <asp:TextBox ID="PlaceType" runat="server"  class="inp"></asp:TextBox>
                 </div>
                 <hr>
             </div>
         </div>
      </div>

        <div class="box">
          <div class="container">
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Location<span style="color:#ff0000">*</span></p>
                     <asp:TextBox ID="PlaceLocation" runat="server"  class="inp"></asp:TextBox>
                 </div>
                 <hr>
             </div>
         </div>
      </div>
         
        <div class="photo">
             <h4>Gallery Photos:</h4>
             
             <asp:FileUpload ID="galleryUpload" runat="server" AllowMultiple="true" Accept=".jpg, .jpeg, .png, .gif" style="margin-top:.5rem" name="galleryUpload"/>
             <h4>Featured Photo:<span style="color:#ff0000">*</span></h4>
             
             <asp:FileUpload ID="featuredUpload" runat="server" Accept=".jpg, .jpeg, .png, .gif" style="margin-top:.5rem" />
          
        </div>
      
     
    </section>
    <h4 style="margin-left:1.5rem">Details:<span style="color:#ff0000">*</span></h4>
    <div class="editor">
        <asp:TextBox ID="tiny" runat="server" TextMode="MultiLine"></asp:TextBox>
        <input type="hidden" id="hiddenField" name="hiddenField" />
    </div>
    <asp:Button ID="Submit_btn" runat="server" Text="Submit" class="btn" OnClick="Submit_btn_Click" />
    
</asp:Content>
