<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileUser.aspx.cs" Inherits="Ghuraghuri.pages.ProfileUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
    <script src="https://kit.fontawesome.com/e9586f465a.js" crossorigin="anonymous"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons+Sharp" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons+Outlined" rel="stylesheet"/>
    <link rel="stylesheet" href="../css/style_profile.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            
            <aside runat="server" id="side_menu">
                <div class="top">
                    <a href="Home.aspx" runat="server" class="logo"><img src="/images/tourism.png" alt="logo"/>Ghuraghuri</a>
                    <span id="close" class="material-icons-outlined" runat="server" visible="false">close</span>
                    
                </div>
                <div class="sidebar">
                    <asp:LinkButton ID="Dashboard" runat="server" class="sidebar_link" OnClick="Dashboard_Click">
                        <span class="material-icons-outlined">grid_view</span>
                        <h3>Dashboard</h3>
                        </asp:LinkButton>
                    <asp:LinkButton ID="Account" runat="server" class="sidebar_link" OnClick="Account_Click">
                        <span class="material-icons-sharp">person_outline</span>
                        <h3>Account</h3>
                        </asp:LinkButton>

                    <asp:LinkButton ID="History" runat="server" class="sidebar_link" OnClick="History_Click">
                        <span class="material-icons-sharp">history</span>
                        <h3>Booking History</h3>
                        </asp:LinkButton>

                     <asp:LinkButton ID="Orders" runat="server" class="sidebar_link" OnClick="Orders_Click">
                        <span class="material-icons-outlined">local_mall</span>
                        <h3>Orders</h3>
                        </asp:LinkButton>

                    <asp:LinkButton ID="Reviews" runat="server" class="sidebar_link" OnClick="Reviews_Click">
                        <span class="material-icons-outlined">reviews</span>
                        <h3>Reviews</h3>
                        </asp:LinkButton>
                     <asp:LinkButton ID="AddTour" runat="server" class="sidebar_link" OnClick="AddTour_Click">
                        <span class="material-icons-outlined">control_point</span>
                        <h3>Add tour</h3>
                        </asp:LinkButton>
                    <asp:LinkButton ID="Approvals" runat="server" class="sidebar_link" OnClick="Approvals_Click">
                        <span class="material-icons-outlined">feedback</span>
                        <h3>Approvals</h3>
                        </asp:LinkButton>
                     <asp:LinkButton ID="Bookings" runat="server" class="sidebar_link" OnClick="Bookings_Click">
                        <span class="material-icons-outlined">library_books</span>
                        <h3>Bookings</h3>
                        </asp:LinkButton>
                    <asp:LinkButton ID="Blog" runat="server" class="sidebar_link" OnClick="Blog_Click">
                        <span class="material-icons-outlined">post_add</span>
                        <h3>Post Blog</h3>
                        </asp:LinkButton>
                     <asp:LinkButton ID="LogOut" runat="server" class="sidebar_link" OnClick="LogOut_Click">
                        <span class="material-icons-sharp">logout</span>
                        <h3>Log out</h3>
                        </asp:LinkButton>
                    
                    
                </div>
            </aside>

            <div class="right">
                
                <header>
                    <span class="material-icons-outlined" id="menu_btn">menu</span>
                    <h1>Account</h1>
                    <div class="propic">
                        <div>
                            <h4 id="pro_name" runat="server">Name</h4>
                            <small id="pro_rol" runat="server">User</small>
                        </div>
                        <img src="../images/tourism.png" alt="Profile image"/>
                        
                    </div>
                </header>
                <!--user account-->
                <section class="user_account" runat="server" visible="false">
                    
                    <div class="input_box" runat="server">
                        <div class="info">
                            <h4 runat="server" class="lb">Name</h4>
                            
                            <asp:TextBox ID="TextBox1" runat="server" class="inp"></asp:TextBox>
                        </div>
                         <div class="info">
                             <h4 runat="server" class="lb">Email</h4>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Email" ReadOnly="true" class="inp"></asp:TextBox>
                        </div>
                         <div class="info">
                             <h4 runat="server" class="lb">Gender</h4>
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="gender" class="radio"/>
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="gender" class="radio"/>
                            <asp:RadioButton ID="RadioButton3" runat="server" Text="Other" GroupName="gender" class="radio"/>
                        </div>
                        
                        <asp:Button ID="Button1" runat="server" Text="Save" class="btn"/>
                    </div>
                    <div class="change_pass">
                        <h2>Change Password</h2>
                        <div class="pass">
                             <h4 runat="server" class="lb">Current Password</h4>
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                        </div>
                        <div class="pass">
                            <h4 runat="server" class="lb">New Password</h4>
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button2" runat="server" Text="Update" class="btn"/>
                    </div>
                </section>

                <!--agency account-->
                <section class="agency_account" runat="server" visible="false">
                    
                    <div class="input_box" runat="server">
                        <div class="info">
                            <h4 runat="server" class="lb">Agency Name</h4>
                            <asp:TextBox ID="TextBox5" runat="server" class="inp"></asp:TextBox>
                        </div>
                        <div class="info">
                            <h4 runat="server" class="lb">Owner Name</h4>
                            <asp:TextBox ID="TextBox9" runat="server" class="inp"></asp:TextBox>
                        </div>
                         <div class="info">
                             <h4 runat="server" class="lb">Email</h4>
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="Email" ReadOnly="true" class="inp"></asp:TextBox>
                        </div>
                        <div class="info">
                            <h4 runat="server" class="lb">Address</h4>
                            <asp:TextBox ID="TextBox10" runat="server" class="inp" TextMode="MultiLine" ></asp:TextBox>
                        </div>
                        
                        
                        <asp:Button ID="Button3" runat="server" Text="Save" class="btn"/>
                    </div>
                    <div class="change_pass">
                        <h2>Change Password</h2>
                        <div class="pass">
                             <h4 runat="server" class="lb">Current Password</h4>
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                        </div>
                        <div class="pass">
                            <h4 runat="server" class="lb">New Password</h4>
                            <asp:TextBox ID="TextBox8" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button4" runat="server" Text="Update" class="btn"/>
                    </div>
                </section>

                <!--admin account-->
                <section class="agency_account" runat="server">
                    
                    <div class="input_box" runat="server">
                        
                         <div class="info">
                             <h4 runat="server" class="lb">Email</h4>
                            <asp:TextBox ID="TextBox13" runat="server" TextMode="Email" class="inp"></asp:TextBox>
                        </div>
                       
                        <asp:Button ID="Button5" runat="server" Text="Save" class="btn"/>
                    </div>
                    <div class="change_pass">
                        <h2>Change Password</h2>
                        <div class="pass">
                             <h4 runat="server" class="lb">Current Password</h4>
                            <asp:TextBox ID="TextBox15" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                        </div>
                        <div class="pass">
                            <h4 runat="server" class="lb">New Password</h4>
                            <asp:TextBox ID="TextBox16" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button6" runat="server" Text="Update" class="btn"/>
                    </div>
                </section>

                <!--add tour admin-->

                
            </div>
        </div>
    </form>
</body>
</html>
