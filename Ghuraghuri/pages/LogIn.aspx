<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Ghuraghuri.pages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="/css/style_login.css"/>
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
            <h2>Log In</h2>
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
            <form runat="server">
                
                <div class="input-box">
                
                    <input id="Text1" runat="server" type="email" placeholder="Email "/>
                                  
                </div>

                <div class="input-box">
                   
                    <input id="Text2" placeholder="Password" type="password" runat="server"/>
                      
                </div>

               
                <asp:Button ID="Loginbtn" runat="server" Text="Log In" OnClick="Loginbtn_Click" />
                <div class="login_register">
                    <p>Don't have an account?<a href="SignupOption.aspx" class="reg_link">Sign Up</a></p>
                </div>
                
            </form>

        </div>


    </div>

     <script src="../javascript/master_script.js"></script>
</body>
</html>
