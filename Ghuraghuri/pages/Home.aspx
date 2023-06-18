<%@ Page Title="Home" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Ghuraghuri.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <!-- <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css"/>-->
    <link href="../css/swipper1.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/style_home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="home" id="home">
        <div class="swiper home_slider">
            <div class="swiper-wrapper">

                <div class="swiper-slide">
                   <div class="box" style="background: url(/images/bg-1.jpg) no-repeat;">
                     <div class="content">
                        <span>Make your tour</span>
                        <h3>Easy</h3>
                        <a id="started_btn1" href="SignupOption.aspx" class="btn" runat="server">Get started</a>
                     </div>
                   </div>
                </div>

                <div class="swiper-slide">
                    <div class="box second" style="background: url(/images/bg-2.jpg) no-repeat;">
                      <div class="content">
                         <span>Never stop</span>
                         <h3>Exploring</h3>
                         <a id="started_btn2" href="SignupOption.aspx" class="btn" runat="server">Get started</a>
                      </div>
                    </div>
                 </div>

                 <div class="swiper-slide">
                    <div class="box" style="background: url(/images/bg-3.jpg) no-repeat;">
                      <div class="content">
                         <span>Stop dreaming</span>
                         <h3>Start<br>Traveling</h3>
                         <a id="started_btn3" href="SignupOption.aspx" class="btn" runat="server">Get started</a>
                      </div>
                    </div>
                 </div>

            </div>

            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
        </div>

    </section>

    <section class="t_spot" id="t_spot">
      <h1 class="heading">Toutist Spots</h1>
        <div class="swiper t_spot-slider">
          <div class="swiper-wrapper" runat="server" id="div_container">

            <div class="swiper-slide t_slide">

              <div class="image">
                <img src="/images/sundarban.jpg" alt="">
              </div>
              <div class="content">
                <h3>Spot Name</h3>
                <p>Forest</p>
              </div>

            </div>

            <div class="swiper-slide t_slide">

              <div class="image">
                <img src="/images/hill.jpg" alt="">
              </div>
              <div class="content">
                <h3>Spot Name</h3>
                <p>Hill</p>
              </div>

            </div>

            <div class="swiper-slide t_slide">

              <div class="image">
                <img src="/images/sundarban.jpg" alt="">
              </div>
              <div class="content">
                <h3>Spot Name</h3>
                <p>Forest</p>
              </div>

            </div>

            <div class="swiper-slide t_slide">

              <div class="image">
                <img src="/images/hill.jpg" alt="">
              </div>
              <div class="content">
                <h3>Spot Name</h3>
                <p>Hill</p>
              </div>

            </div>

            <div class="swiper-slide t_slide">

              <div class="image">
                <img src="/images/sundarban.jpg" alt="">
              </div>
              <div class="content">
                <h3>Spot Name</h3>
                <p>Forest</p>
              </div>

            </div>


          </div>
          <div class="swiper-button-next"></div>
          <div class="swiper-button-prev"></div>
        </div>

    </section>

    <section class="category">
      <h1 class="heading">Adventure Idea</h1>
      <div class="box_container">

        <div class="box">
          <img src="/images/cycling.jpg" alt="">
          <h3>Cycling</h3>
          <p>Some sights must be taken in slowly: rock formations shaped over thousands of...</p>
          <a href="#" class="read_btn">Read More</a>
        </div>

        <div class="box">
          <img src="/images/camping.jpg" alt="">
          <h3>Camping</h3>
          <p>Picture dense woods of pines, trickling waterfalls, slipping into...</p>
          <a href="#" class="read_btn">Read More</a>
        </div>

        <div class="box">
          <img src="/images/kayak.jpg" alt="">
          <h3>Kayaking</h3>
          <p>You could zoom down a mountain river gorge as white-water mist pummels...</p>
          <a href="#" class="read_btn">Read More</a>
        </div>

        <div class="box">
          <img src="/images/parasailing.jpg" alt="">
          <h3>Parasailing</h3>
          <p>Do you ever dream of flying -- making lazy circles in the sky like a seagull or...</p>
          <a href="#" class="read_btn">Read More</a>
        </div>

        <div class="box">
          <img src="/images/zipline.jpg" alt="">
          <h3>Zip line</h3>
          <p>A zip line is, at its most simple, a cable that starts at a higher point than it ends...</p>
          <a href="#" class="read_btn">Read More</a>
        </div>

      </div>
    </section>

     

    <section class="package" id="package">
      <h1 class="heading">Popular Packages</h1>
      
      <div class="swiper box_container-slider">
          <div class="swiper-wrapper" id="package_container" runat="server">
              <div class="swiper-slide box">
                  <div class="image">
                      <img src="/images/sea-beach.jpg" alt="">
                  </div>
                  <div class="content">

                      <div class="agency">
                          <i class="fa-solid fa-building"></i>
                          <p>Agency Name</p>
                      </div>

                      <h4>Package Name</h4>
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

              </div>

              <div class="swiper-slide box">
                  <div class="image">
                      <img src="/images/sea-beach.jpg" alt="">
                  </div>
                  <div class="content">

                      <div class="agency">
                          <i class="fa-solid fa-building"></i>
                          <p>Agency Name</p>
                      </div>

                      <h4>Package Name</h4>
                      <p>3 days,4 night</p>

                      <div class="price_rating">
                          <div class="rate">
                              <i class="fa-solid fa-star"></i>
                              <p style="color: #DC7303;">4.5</p>
                          </div>
                          <p class="amount">5000tk</p>
                      </div>
                      <a href="#" class="explore_btn">Explore Now</a>

                  </div>

              </div>

              <div class="swiper-slide box">
                  <div class="image">
                      <img src="/images/sea-beach.jpg" alt="">
                  </div>
                  <div class="content">

                      <div class="agency">
                          <i class="fa-solid fa-building"></i>
                          <p>Agency Name</p>
                      </div>

                      <h4>Package Name</h4>
                      <p>3 days,4 night</p>

                      <div class="price_rating">
                          <div class="rate">
                              <i class="fa-solid fa-star"></i>
                              <p style="color: #DC7303;">4.5</p>
                          </div>
                          <p class="amount">5000tk</p>
                      </div>
                      <a href="#" class="explore_btn">Explore Now</a>

                  </div>

              </div>

              <div class="swiper-slide box">
                  <div class="image">
                      <img src="/images/sea-beach.jpg" alt="">
                  </div>
                  <div class="content">

                      <div class="agency">
                          <i class="fa-solid fa-building"></i>
                          <p>Agency Name</p>
                      </div>

                      <h4>Package Name</h4>
                      <p>3 days,4 night</p>

                      <div class="price_rating">
                          <div class="rate">
                              <i class="fa-solid fa-star"></i>
                              <p style="color: #DC7303;">4.5</p>
                          </div>
                          <p class="amount">5000tk</p>
                      </div>
                      <a href="#" class="explore_btn">Explore Now</a>

                  </div>

              </div>
              <div class="swiper-slide box ">
                  <div class="image">
                      <img src="/images/sea-beach.jpg" alt="">
                  </div>
                  <div class="content">

                      <div class="agency">
                          <i class="fa-solid fa-building"></i>
                          <p>Agency Name</p>
                      </div>

                      <h4>Package Name</h4>
                      <p>3 days,4 night</p>

                      <div class="price_rating">
                          <div class="rate">
                              <i class="fa-solid fa-star"></i>
                              <p style="color: #DC7303;">4.5</p>
                          </div>
                          <p class="amount">5000tk</p>
                      </div>
                      <a href="#" class="explore_btn">Explore Now</a>

                  </div>

              </div>

      </div>



        <div class="swiper-button-next"></div>
         <div class="swiper-button-prev"></div>

      </div>
    </section>

    <section class="shop" id="shop">
      <h1 class="heading">Featured Product</h1>
        <div class="swiper product-slider">
          <div class="swiper-wrapper" id="shop_container" runat="server">

           
            <div class="swiper-slide slide">

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
                  <i class="fa-solid fa-star"></i>
                  <i class="fa-solid fa-star-half-stroke"></i>
                </div>
              </div>

            </div>

            <div class="swiper-slide slide">

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
                  <i class="fa-solid fa-star"></i>
                  <i class="fa-solid fa-star-half-stroke"></i>
                </div>
              </div>

            </div>

            <div class="swiper-slide slide">

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
                  <i class="fa-solid fa-star"></i>
                  <i class="fa-solid fa-star-half-stroke"></i>
                </div>
              </div>

            </div>

            <div class="swiper-slide slide">

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
                  <i class="fa-solid fa-star"></i>
                  <i class="fa-solid fa-star-half-stroke"></i>
                </div>
              </div>

            </div>

            <div class="swiper-slide slide">

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
                  <i class="fa-solid fa-star"></i>
                  <i class="fa-solid fa-star-half-stroke"></i>
                </div>
              </div>

            </div>

          </div>
          <div class="swiper-button-next"></div>
          <div class="swiper-button-prev"></div>
        </div>

    </section>


    <section class="blog" id="blog">
      <h1 class="heading">Blog Posts</h1>
      <div class="swiper blog-slider">
        <div class="swiper-wrapper" id="blog_container" runat="server">

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
      </div>
    </section>


    <script src="../javascript/swipperBundle.js"></script>
    <!--<script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>-->
    <script src="../javascript/home_script.js"></script>
</asp:Content>
