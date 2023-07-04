<%@ Page Title="Blog" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="BlogPage.aspx.cs" Inherits="Ghuraghuri.pages.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_blogPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="blog" id="blog">
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <div class="search_bar">
                    <!--<h1 class="heading">Blog Posts</h1>-->
                    <asp:TextBox ID="searchTxt" runat="server" placeholder="Search place name" class="inp"></asp:TextBox>
                    <asp:LinkButton ID="SearchBtn" runat="server" class="src_btn" OnClick="SearchBtn_Click">
                <i class="fa-solid fa-magnifying-glass"></i>
                    </asp:LinkButton>

                </div>
                <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="blog_container" id="blog_container" runat="server">

                    <%--<div class="slide">
                        <img src="/images/blog.jpg" alt="">
                        <div class="icon">
                            <a href="#"><i class="fa-solid fa-calendar-days"></i>17 Mar, 2023</a>
                            <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
                        </div>
                        <h3>Blog Title</h3>
                        <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
                        <a href="#" class="read_btn">Read More</a>
                    </div>--%>

                </div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
      
    </section>
    <script src="../javascript/passing_script.js"></script>
</asp:Content>
