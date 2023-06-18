<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupOption.aspx.cs" Inherits="Ghuraghuri.pages.SignupOption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign up option</title>
    <script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="../css/style_role.css" />
</head>
<body>
    <header class="header">
       <a href="Home.aspx" runat="server" class="logo"><img src="/images/tourism.png" alt="logo"/>Ghuraghuri</a>
        <nav class="nav">
            <div id="nav_close" class="fa-solid fa-xmark"></div>
            <a class="home" href="Home.aspx" runat="server">Home</a>
            <a class="packages" href="#" runat="server">Packages</a>
            <a class="nav_spot" href="#" runat="server">Tourist-spot</a>
            <a class="nav_Shop" href="#" runat="server">Shop</a>
            <a class="nav_blog" href="#" runat="server">Blog</a>
            <a class="login" href="LogInOption.aspx" runat="server">Log In</a>
        </nav>
        <div class="icons">
          <div id="menu" class="fa-solid fa-bars"></div>
        </div>
    </header>

    <div class="wrapper">
        <div class="role_box signup">
            <h2>Choose your role</h2>
            <form class="role_info" runat="server">
                <asp:LinkButton ID="UserSignup" runat="server" class="btn" onclick="UserSignup_Click1">User</asp:LinkButton>
                <asp:LinkButton ID="AgencySignup" runat="server" class="btn" onclick="AgencySignup_Click1">Agency</asp:LinkButton>
            </form>
        </div>

    </div>
    <script src="../javascript/master_script.js"></script>
</body>
</html>
