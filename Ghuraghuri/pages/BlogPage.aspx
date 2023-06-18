<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="BlogPage.aspx.cs" Inherits="Ghuraghuri.pages.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_blogPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="blog" id="blog">
      <h1 class="heading">Blog Posts</h1>
       <div class="blog_container" id="blog_container" runat="server">

          <div class="slide">
            <img src="/images/blog.jpg" alt="">
            <div class="icon">
              <a href="#"><i class="fa-solid fa-calendar-days"></i>17 Mar, 2023</a>
              <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
            </div>
            <h3>Blog Title</h3>
            <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
            <a href="#" class="read_btn">Read More</a>
          </div>

          <div class="swiper-slide slide">
            <img src="/images/blog.jpg" alt="">
            <div class="icon">
              <a href="#">
                  <i class="fa-solid fa-calendar-days"></i>
                  <span>17 Mar, 2023</span>

              </a>
              <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
            </div>
            <h3>Blog Title</h3>
            <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
            <a href="#" class="read_btn">Read More</a>
          </div>

          <div class="swiper-slide slide">
            <img src="/images/blog.jpg" alt="">
            <div class="icon">
              <a href="#"><i class="fa-solid fa-calendar-days"></i>17 Mar, 2023</a>
              <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
            </div>
            <h3>Blog Title</h3>
            <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
            <a href="#" class="read_btn">Read More</a>
          </div>

          <div class="swiper-slide slide">
            <img src="/images/blog.jpg" alt="">
            <div class="icon">
              <a href="#"><i class="fa-solid fa-calendar-days"></i>17 Mar, 2023</a>
              <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
            </div>
            <h3>Blog Title</h3>
            <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
            <a href="#" class="read_btn">Read More</a>
          </div>

          <div class="swiper-slide slide">
            <img src="/images/blog.jpg" alt="">
            <div class="icon">
              <a href="#"><i class="fa-solid fa-calendar-days"></i>17 Mar, 2023</a>
              <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
            </div>
            <h3>Blog Title</h3>
            <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
            <a href="#" class="read_btn">Read More</a>
          </div>

          <div class="swiper-slide slide">
            <img src="/images/blog.jpg" alt="">
            <div class="icon">
              <a href="#"><i class="fa-solid fa-calendar-days"></i>17 Mar, 2023</a>
              <a href="#"><i class="fa-solid fa-user"></i>by admin</a>
            </div>
            <h3>Blog Title</h3>
            <p style="color: black;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.</p>
            <a href="#" class="read_btn">Read More</a>
          </div>
          
        </div>
    </section>
    <script src="../javascript/home_script.js"></script>
</asp:Content>
