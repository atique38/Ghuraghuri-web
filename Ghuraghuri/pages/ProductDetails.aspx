<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Ghuraghuri.pages.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css"/>-->
    <link href="../css/swipper1.css" rel="stylesheet" />
     <link href="../css/style_package_details.css" rel="stylesheet" />
     <!--<script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>-->
    <script src="../javascript/fontawesome.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="package_heading">
        <h1 id="pdct_name" runat="server" style="font-size:2rem;color:#08B38B">Product Name</h1>
        <div  class="rate">
            <i class="fa-solid fa-star"></i>
            <p id="pdct_rate" runat="server">4.5(100)</p>
         </div>
    </section>
    <section class="basic_data">
         <div class="gallery">
        <div class="swiper mySwiper">
    <div class="swiper-wrapper" id="div_container" runat="server">
      
    </div>
    
  </div>
       

    </div>
    <div class="right">
        <h3 style="font-size:1.25rem">Price:<span style="color: #DC7303" id="pdct_price" runat="server">500tk</span></h3>
            
        <h3>Select Quantity</h3>
            
        <asp:LinkButton ID="LinkButton2" runat="server" class="date" Width="100%" ForeColor="Black" OnClick="LinkButton2_Click">
            <i class="fa-solid fa-bag-shopping"></i>
            <span id="pdctCount" runat="server">Select Quantity</span>
        </asp:LinkButton>
        <asp:Panel ID="Panel1" runat="server" class="person" Visible="false">
            <small style="color:#808080;font-weight:bold">10 Products are available</small>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Text="1" class="inp"></asp:TextBox>
            <asp:Button ID="ApplyBtn" runat="server" Text="Apply" class="btn" OnClick="ApplyBtn_Click" />
        </asp:Panel>
        <div class="btn_ptoduct" >
            <asp:Button ID="BuyBtn" runat="server" Text="Buy Now" class="btn_pdct btn1" OnClick="BuyBtn_Click"/>
            <asp:Button ID="BookBtn" runat="server" Text="Add To Cart" class="btn_pdct btn2" OnClick="BookBtn_Click"/>
        </div>
        
         </div>
    </section>
    <section class="details">
        
        <div id="product_info" runat="server" style="margin-top:.5rem;text-align:justify"> 
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
