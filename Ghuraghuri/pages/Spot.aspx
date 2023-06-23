<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Spot.aspx.cs" Inherits="Ghuraghuri.pages.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_spot.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="t_spot" id="t_spot">
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
                <div class="spot_container" runat="server" id="div_container">

                    <div class="t_slide">

                        <div class="image">
                            <img src="/images/sundarban.jpg" alt="">
                        </div>
                        <div class="content">
                            <h3>Spot Name</h3>
                            <p>Forest</p>
                        </div>

                    </div>

                    <div class="t_slide">

                        <div class="image">
                            <img src="/images/hill.jpg" alt="">
                        </div>
                        <div class="content">
                            <h3>Spot Name</h3>
                            <p>Hill</p>
                        </div>

                    </div>

                    <div class="t_slide">

                        <div class="image">
                            <img src="/images/sundarban.jpg" alt="">
                        </div>
                        <div class="content">
                            <h3>Spot Name</h3>
                            <p>Forest</p>
                        </div>

                    </div>

                    <div class="t_slide">

                        <div class="image">
                            <img src="/images/hill.jpg" alt="">
                        </div>
                        <div class="content">
                            <h3>Spot Name</h3>
                            <p>Hill</p>
                        </div>

                    </div>

                    <div class="t_slide">

                        <div class="image">
                            <img src="/images/sundarban.jpg" alt="">
                        </div>
                        <div class="content">
                            <h3>Spot Name</h3>
                            <p>Forest</p>
                        </div>

                    </div>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <script src="../javascript/passing_script.js"></script>
    </section>
    
</asp:Content>
