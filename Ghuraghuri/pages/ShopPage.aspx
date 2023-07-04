<%@ Page Title="Products" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShopPage.aspx.cs" Inherits="Ghuraghuri.pages.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_shopPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="shop" id="shop">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="search_bar">
                    <!--<h1 class="heading">Blog Posts</h1>-->
                    <asp:TextBox ID="searchTxt" runat="server" placeholder="Search product name" class="inp"></asp:TextBox>
                    <asp:LinkButton ID="SearchBtn" runat="server" class="src_btn" OnClick="SearchBtn_Click">
                        <i class="fa-solid fa-magnifying-glass"></i>
                    </asp:LinkButton>

                </div>
                <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="shop_container" id="shop_container" runat="server">

                    <%--<div class="slide">

                        <div class="image">
                            <img src="/images/backpack.png" alt="">
                            <div class="icons">
                                <a href="#" class="fa-solid fa-cart-shopping"></a>
                                <a href="#" class="fa-solid fa-eye"></a>
                            </div>
                        </div>
                        <div class="content">
                            <h3>Poduct Name</h3>
                            <div class="price">1000tk</div>
                            <div class="stars">
                                <i class="fa-solid fa-star"></i>
                                <i class="fa-solid fa-star"></i>
                                <i class="fa-solid fa-star"></i>
                                <i class="fa-solid fa-star-half-stroke"></i>
                                <i class="fa-regular fa-star"></i>


                            </div>
                        </div>

                    </div>--%>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </section>
    <script src="../javascript/home_script.js"></script>
</asp:Content>
