<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Spot.aspx.cs" Inherits="Ghuraghuri.pages.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_spot.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="t_spot" id="t_spot">
      <h1 class="heading">Toutist Spots</h1>
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

    </section>
    <script src="../javascript/home_script.js"></script>
</asp:Content>
