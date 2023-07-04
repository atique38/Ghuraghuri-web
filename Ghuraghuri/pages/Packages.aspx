<%@ Page Title="Packages" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Packages.aspx.cs" Inherits="Ghuraghuri.pages.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_packages.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="package" id="package">
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
                <div class="package_container" id="package_container" runat="server">
                   <%-- <div class="packages_slide">
                        <div class="image">
                            <img src="/images/sea-beach.jpg" alt="">
                        </div>
                        <div class="content">

                            <div class="agency">
                                <i class="fa-solid fa-building"></i>
                                <p>Agency Name</p>
                            </div>

                            <h3>Package Name</h3>
                            <p>3 days,4 night</p>

                            <div class="price_rating">
                                <div class="rate">
                                    <i class="fa-solid fa-star"></i>
                                    <p style="color: #DC7303;">4.5</p>
                                </div>
                                <p class="amount">5000tk</p>
                            </div>

                            <a class="explore_btn">Explore Now</a>

                        </div>

                    </div>--%>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </section>
    <script src="../javascript/passing_script.js"></script>
</asp:Content>
