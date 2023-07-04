<%@ Page Title="Package Details" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="PackageDetails.aspx.cs" Inherits="Ghuraghuri.pages.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css"/>-->
    <link href="../css/swipper1.css" rel="stylesheet" />
    <link href="../css/style_package_details.css" rel="stylesheet" />
    <!--<script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>-->
    <script src="../javascript/fontawesome.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="package_heading">
        <h1 id="spt_name" runat="server" style="font-size:2rem;color:#08B38B">Spot Name</h1>
        <div  class="rate">
            <i class="fa-solid fa-star"></i>
            <p id="pack_rate" runat="server">4.5(100)</p>
            <div class="vr"></div>
            <p id="Small1" runat="server" style="color:#808080;align-self:center"> Agency Name</p>
         </div>
    </section>

    <section class="basic_data">
        <div class="gallery">
            <div class="swiper mySwiper">
                <div class="swiper-wrapper" id="div_container" runat="server">

                    <%--<div class="swiper-slide">
                        <img src="https://swiperjs.com/demos/images/nature-2.jpg" />
                    </div>--%>
                    

                </div>

            </div>


        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="right">
                    <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <asp:Label ID="done" runat="server" Text="" ForeColor="#08B38B"></asp:Label>
                    <h3 style="font-size: 1.25rem">Cost:<span style="color: #DC7303" id="pack_price" runat="server">5000tk</span></h3>
                    <small style="color: black" id="tour_duration" runat="server">Duration</small>
                    <h3>Select Date and Travelers</h3>

                    <asp:LinkButton ID="LinkButton1" runat="server" class="date" Width="100%" ForeColor="Black" OnClick="LinkButton1_Click">
                        <i class="fa-solid fa-calendar-days"></i>
                        <span id="selected_date" runat="server">Select Date</span>
                    </asp:LinkButton>
                    <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" TitleStyle-BackColor="#99FFCC" TitleStyle-Font-Bold="true" class="calender" SelectedDayStyle-BackColor="#00FF99"></asp:Calendar>

                    <asp:LinkButton ID="LinkButton2" runat="server" class="date" Width="100%" ForeColor="Black" OnClick="LinkButton2_Click">
                        <i class="fa-solid fa-user"></i>
                        <span id="touristNum" runat="server">Total Persons</span>
                    </asp:LinkButton>
                    <asp:Panel ID="Panel1" runat="server" class="person">
                        <small style="color: #808080; font-weight: bold">You can select up to 15 tourist</small>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Text="2" class="inp" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:Button ID="ApplyBtn" runat="server" Text="Apply" class="btn" OnClick="ApplyBtn_Click" />
                    </asp:Panel>
                    <asp:Button ID="BookBtn" runat="server" Text="Book Now" class="btn" OnClick="BookBtn_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </section>
   

    <section class="details">
        
        <div id="package_info" runat="server" style="margin-top:.5rem;text-align:justify"> 
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
