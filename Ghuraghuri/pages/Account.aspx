<%@ Page Title="" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Ghuraghuri.pages.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/style.css" />
    <link href='https://unpkg.com/boxicons@2.0.9/css/boxicons.min.css' rel='stylesheet'>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--user account-->
     <section class="pro_pic" runat="server" id="proPic">
         <img id="imgview" src="../images/profile.png"/>
         <br />
         <input type="file" name="imageFiles" accept="image/*" id="FileUpload1" onchange="readURL(this);"/>
         <asp:Button ID="ImageUpload" runat="server" Text="Update" class="btn" OnClick="ImageUpload_Click"/>
     </section>
     <section class="basic_info" id="u_info" runat="server">
         <div class="container">
             <p class="heading">Basic Information</p>
             <div class="content">
                 <div class="info">
                     <p>Name</p>
                    <p id="U_Name" runat="server">Atique Faisal</p>
                    <i class='bx bxs-edit' id="name_edt"></i>
                     
                 </div>
                 <hr>
                 <div class="info">
                     <p>Email</p>
                     <p id="u_email" runat="server">example@gmail.com</p>
                     <i class='bx bx-check' style="color:#08B38B"></i>
                     
                 </div>
                 <hr>

                 <div class="info">
                     <p>Phone</p>
                     <p>None</p>
                     <i class='bx bxs-edit' id="phone_edt"></i>
                 </div>
                 <hr>

                 <div class="info">
                     <p>Gender</p>
                     <p>Prefer not to say</p>
                     <i class='bx bxs-edit' id="gender_edt"></i>
                 </div>
                 <hr>

             </div>
         </div>
     </section>
     <section class="change_pass" id="u_pass" runat="server">
         <div class="container">
             <p class="heading">Password</p>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Current Password</p>
                     <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <div class="info">
                      <p runat="server" class="lb">New Password</p>
                      <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>

                 <div class="info">
                      <p runat="server" class="lb">Confirm Password</p>
                      <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                 </div>
                 <hr>
                 <asp:Button ID="Button1" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
    <!--user account end-->

    <!--agency account-->
     <section class="basic_info" id="ag_info" runat="server">
         <div class="container">
             <p class="heading">Basic Information</p>
             <div class="content">
                 <div class="info">
                     <p>Agency</p>
                    <p>example</p>
                    <i class='bx bxs-edit' id="agency_edt"></i>
                     
                 </div>
                 <hr>
                 <div class="info">
                     <p>Owner</p>
                    <p>Atique Faisal</p>
                    <i class='bx bxs-edit' id="owner_edt"></i>
                     
                 </div>
                 <hr>
                 <div class="info">
                     <p>Email</p>
                     <p>example@gmail.com</p>
                     <i class='bx bx-check' style="color:#08B38B"></i>
                     
                 </div>
                 <hr>

                 <div class="info">
                     <p>Phone</p>
                     <p>None</p>
                     <i class='bx bxs-edit' id="agency_phone_edt"></i>
                 </div>
                 <hr>

                 <div class="info">
                     <p>Address</p>
                     <p>Pockategate,kuet,khulna</p>
                     <i class='bx bxs-edit' id="address_edt"></i>
                 </div>
                 <hr>

             </div>
         </div>
     </section>

     <section class="change_pass" id="ag_pass" runat="server">
         <div class="container">
             <p class="heading">Password</p>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Current Password</p>
                     <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <div class="info">
                      <p runat="server" class="lb">New Password</p>
                      <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>

                 <div class="info">
                      <p runat="server" class="lb">Confirm Password</p>
                      <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                 </div>
                 <hr>
                 <asp:Button ID="Button2" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
    <!--agency account end-->

     <!--admin account-->
     <section class="basic_info" id="ad_info" runat="server">
         <div class="container">
             <p class="heading">Basic Information</p>
             <div class="content">
                 <div class="info">
                     <p>Email</p>
                     <p>example@gmail.com</p>
                     <i class='bx bxs-edit'></i>
                     
                 </div>
                 <hr>
             </div>
         </div>
     </section>

     <section class="change_pass" id="ad_pass" runat="server">
         <div class="container">
             <p class="heading">Password</p>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Current Password</p>
                     <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <div class="info">
                      <p runat="server" class="lb">New Password</p>
                      <asp:TextBox ID="TextBox8" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>

                 <div class="info">
                      <p runat="server" class="lb">Confirm Password</p>
                      <asp:TextBox ID="TextBox9" runat="server" TextMode="Password" class="inp"></asp:TextBox>
                 </div>
                 <hr>
                 <asp:Button ID="Button3" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
    <!--admin account end-->

    <!--popup user name edit-->
    <section class="popup">
         <div class="container">
             <p class="heading">Edit Name</p>
             <i class='bx bx-x' id="name_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox10" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="Button4" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
    <!--popup user phone edit-->
    <section class="popup_phone">
         <div class="container">
             <p class="heading">Edit phone number</p>
             <i class='bx bx-x' id="phone_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Phone</p>
                     <asp:TextBox ID="TextBox11" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
                 <asp:Button ID="Button5" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
     <!--popup user gender edit-->
    <section class="popup_gender">
         <div class="container">
             <p class="heading">Edit Gender</p>
             <i class='bx bx-x' id="gender_close"></i>
             <div class="content">
                 <div class="radio">
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                         <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                         <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                         <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                         <asp:ListItem Text="Rather not to say" Value="4" Selected="True"></asp:ListItem>
                     </asp:RadioButtonList>
                 </div>
                 <hr>
                 <asp:Button ID="Button6" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>


    <!--popup agency name edit-->
    <section class="popup_agency">
         <div class="container">
             <p class="heading">Edit Agency Name</p>
             <i class='bx bx-x' id="agency_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox12" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="Button7" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
     <!--popup agency name edit-->
    <section class="popup_owner">
         <div class="container">
             <p class="heading">Edit Owner Name</p>
             <i class='bx bx-x' id="owner_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox13" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="Button8" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
    <!--popup agency phone edit-->
    <section class="popup_agency_phone">
         <div class="container">
             <p class="heading">Edit phone number</p>
             <i class='bx bx-x' id="agency_phone_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Phone</p>
                     <asp:TextBox ID="TextBox14" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
                 <asp:Button ID="Button9" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>
    <!--popup agency address edit-->
    <section class="popup_address">
         <div class="container">
             <p class="heading">Edit Address</p>
             <i class='bx bx-x' id="address_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Address</p>
                     <asp:TextBox ID="TextBox15" runat="server"  class="adrs" TextMode="MultiLine"></asp:TextBox>
 
                 </div>
                 <hr>
                 <asp:Button ID="Button10" runat="server" Text="Update" class="btn"/>
             </div>
         </div>
     </section>

    

    <script src="../javascript/profile_script.js"></script>
</asp:Content>
