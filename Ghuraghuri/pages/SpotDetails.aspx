<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="SpotDetails.aspx.cs" Inherits="Ghuraghuri.pages.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css"/>-->
    <link href="../css/swipper1.css" rel="stylesheet" />
    <link href="../css/style_spot_details.css" rel="stylesheet" />
    <!--<script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>-->
    <script src="../javascript/fontawesome.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="gallery">
        <div class="swiper mySwiper">
    <div class="swiper-wrapper" id="div_container" runat="server">
      
      <div class="swiper-slide">
        <img src="https://swiperjs.com/demos/images/nature-2.jpg" />
      </div>
      <div class="swiper-slide">
        <img src="https://swiperjs.com/demos/images/nature-3.jpg" />
      </div>
      <div class="swiper-slide">
        <img src="https://swiperjs.com/demos/images/nature-4.jpg" />
      </div>
      <div class="swiper-slide">
        <img src="https://swiperjs.com/demos/images/nature-5.jpg" />
      </div>
      
      <div class="swiper-slide">
        <img src="https://swiperjs.com/demos/images/nature-7.jpg" />
      </div>
      <div class="swiper-slide">
        <img src="https://swiperjs.com/demos/images/nature-8.jpg" />
      </div>
     
    </div>
    
  </div>

    </section>

    <section class="details">
        <h1 id="spt_name" runat="server" style="font-size:2rem;color:#08B38B">Spot Name</h1>
        <h3 id="spt_type" runat="server" style="color:#0094ff">Type</h3>
        <small id="spt_location" runat="server" class="fa-solid fa-location-dot" style="color:#808080"> Address</small>
        <div id="spt_info" runat="server" style="margin-top:.5rem">
        </div>
    </section>


    <!--<script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>-->
    <script src="../javascript/swipperBundle.js"></script>
    <script>
        var swiper = new Swiper(".mySwiper", {
            effect: "coverflow",
            grabCursor: true,
            centeredSlides: true,
            slidesPerView: "auto",
            coverflowEffect: {
                rotate: 50,
                stretch: 0,
                depth: 100,
                modifier: 1,
                slideShadows: true,
            },
            
        });
        
    </script>
</asp:Content>
