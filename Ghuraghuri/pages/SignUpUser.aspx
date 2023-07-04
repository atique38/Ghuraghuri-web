<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpUser.aspx.cs" Inherits="Ghuraghuri.pages.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="/css/style_signup.css"/>
</head>
<body>
    <header class="header">
        <a href="Home.aspx" runat="server" class="logo"><img src="/images/tourism.png" alt="logo"/>Ghuraghuri</a>
        <nav class="nav">
            <div id="nav_close" class="fa-solid fa-xmark"></div>
            <a class="home" href="Home.aspx" runat="server">Home</a>
            <a class="packages" href="Packages.aspx" runat="server">Packages</a>
            <a class="nav_spot" href="Spot.aspx" runat="server">Tourist-spot</a>
            <a class="nav_Shop" href="ShopPage.aspx" runat="server">Shop</a>
            <a class="nav_blog" href="BlogPage.aspx" runat="server">Blog</a>
            <a class="login" href="LogInOption.aspx" runat="server">Log In</a>
        </nav>
        <div class="icons">
          <div id="menu" class="fa-solid fa-bars"></div>
        </div>
    </header>

    <div class="wrapper">
        <div class="form-box signup">
            <h2>Sign Up</h2>
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
            <form runat="server">
                 <div class="input-box">
                
                    <input id="u_name" runat="server" type="text" placeholder="Full Name "/>
                                   
                </div>
                <div class="input-box">
                
                    <input id="DisplayName" runat="server" type="text" placeholder="Display Name(Short) "/>
                                   
                </div>
                <div class="input-box">
                
                    <input id="u_email" runat="server" type="email" placeholder="Email "/>
                                  
                </div>
                <div class="input-box">
                
                    <input id="Phone" runat="server" type="text" placeholder="Phone No. "/>
                                  
                </div>

                <div class="input-box">
                   
                    <input id="u_pass" runat="server" type="password" placeholder="Password "/>
                      
                </div>

               
                <asp:Button ID="submit" runat="server" Text="Sign Up" OnClick="submit_Click" />
                <div class="login_register">
                    <p>Already have an account?<a href="LogInOption.aspx" class="reg_link">Log In</a></p>
                </div>
                
            </form>

        </div>


    </div>

     <script src="../javascript/master_script.js"></script>
</body>
</html>
