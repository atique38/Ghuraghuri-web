<%@ Page Title="Blog Details" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="BlogDetails.aspx.cs" Inherits="Ghuraghuri.pages.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_blog_details.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="blog_details">
        <h1 id="blg_title" runat="server" style="font-size:2rem;color:#08B38B">Blog Title</h1>
        <small id="author" runat="server" style="color:#808080">By Author, 23 may,2023</small>
         <div class="image">
             <img src="../images/bg-1.jpg" id="blogImg" runat="server"/>
         </div>
        
        <div id="blog_info" runat="server" style="margin-top:.5rem;text-align:justify">
            
        </div>
    </section>
</asp:Content>
