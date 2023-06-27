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
                     <p>Display<br /> Name</p>
                    <p id="u_disName" runat="server">Atique</p>
                    <i class='bx bxs-edit' id="disname_edt"></i>
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
                     <p id="u_phn" runat="server">None</p>
                     <i class='bx bxs-edit' id="phone_edt"></i>
                 </div>
                 <hr>

                 <div class="info">
                     <p>Gender</p>
                     <p id="u_gender" runat="server">Prefer not to say</p>
                     <i class='bx bxs-edit' id="gender_edt"></i>
                 </div>
                 <hr>

             </div>
         </div>
     </section>
     <section class="change_pass" id="u_pass" runat="server">
         <asp:Label ID="u_error" runat="server" Text="" ForeColor="Red"></asp:Label>
         <asp:Label ID="u_done" runat="server" Text="" ForeColor="#08B38B"></asp:Label>
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
                 <asp:Button ID="u_pass_update" runat="server" Text="Update" class="btn" OnClick="u_pass_update_Click"/>
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
                    <p id="agName" runat="server">example</p>
                    <i class='bx bxs-edit' id="agency_edt"></i>
                     
                 </div>
                 <hr>
                 <div class="info">
                     <p>Owner</p>
                    <p id="ownName" runat="server">Atique Faisal</p>
                    <i class='bx bxs-edit' id="owner_edt"></i>
                     
                 </div>
                 <hr>
                 <div class="info">
                     <p>Email</p>
                     <p id="agEmail" runat="server">example@gmail.com</p>
                     <i class='bx bx-check' style="color:#08B38B"></i>
                     
                 </div>
                 <hr>

                 <div class="info">
                     <p>Phone</p>
                     <p id="ag_phn" runat="server">None</p>
                     <i class='bx bxs-edit' id="agency_phone_edt"></i>
                 </div>
                 <hr>

                 <div class="info">
                     <p>Address</p>
                     <p id="ag_adrs" runat="server">Pockategate,kuet,khulna</p>
                     <i class='bx bxs-edit' id="address_edt"></i>
                 </div>
                 <hr>

             </div>
         </div>
     </section>

     <section class="change_pass" id="ag_pass" runat="server">
         <asp:Label ID="ag_error" runat="server" Text="" ForeColor="Red"></asp:Label>
         <asp:Label ID="ag_done" runat="server" Text="" ForeColor="#08B38B"></asp:Label>
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
                 <asp:Button ID="ag_pass_update" runat="server" Text="Update" class="btn" OnClick="ag_pass_update_Click"/>
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
                     <p id="ad_email" runat="server">example@gmail.com</p>
                     
                 </div>
                 <hr>
             </div>
         </div>
     </section>

     <section class="change_pass" id="ad_pass" runat="server">
         <asp:Label ID="ad_error" runat="server" Text="" ForeColor="Red"></asp:Label>
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
                 <asp:Button ID="ad_update_pass" runat="server" Text="Update" class="btn" OnClick="ad_update_pass_Click"/>
             </div>
         </div>
     </section>
    <!--admin account end-->

    <!--popup user name edit-->
    <section class="popup">
        <asp:Label ID="uname_edt_error" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit Name</p>
             <i class='bx bx-x' id="name_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox10" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="U_NameEdt" runat="server" Text="Update" class="btn" OnClick="U_NameEdt_Click"/>
             </div>
         </div>
     </section>

    <section class="popup_display_name">
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit Display Name</p>
             <i class='bx bx-x' id="disname_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox16" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="DisnameEdt" runat="server" Text="Update" class="btn" OnClick="DisnameEdt_Click"/>
             </div>
         </div>
     </section>
    <!--popup user phone edit-->
    <section class="popup_phone">
        <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit phone number</p>
             <i class='bx bx-x' id="phone_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Phone</p>
                     <asp:TextBox ID="TextBox11" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
                 <asp:Button ID="U_phn_edt" runat="server" Text="Update" class="btn" OnClick="U_phn_edt_Click"/>
             </div>
         </div>
     </section>
     <!--popup user gender edit-->
    <section class="popup_gender">
        <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>
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
                 <asp:Button ID="GenderEdt" runat="server" Text="Update" class="btn" OnClick="GenderEdt_Click"/>
             </div>
         </div>
     </section>


    <!--popup agency name edit-->
    <section class="popup_agency">
        <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit Agency Name</p>
             <i class='bx bx-x' id="agency_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox12" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="ag_name_edt" runat="server" Text="Update" class="btn" OnClick="ag_name_edt_Click"/>
             </div>
         </div>
     </section>
     <!--popup owner name edit-->
    <section class="popup_owner">
        <asp:Label ID="Label5" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit Owner Name</p>
             <i class='bx bx-x' id="owner_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Name</p>
                     <asp:TextBox ID="TextBox13" runat="server"  class="inp"></asp:TextBox>
                     
                 </div>
                 <hr>
                 <asp:Button ID="ag_ownername_edt" runat="server" Text="Update" class="btn" OnClick="ag_ownername_edt_Click"/>
             </div>
         </div>
     </section>
    <!--popup agency phone edit-->
    <section class="popup_agency_phone">
        <asp:Label ID="Label6" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit phone number</p>
             <i class='bx bx-x' id="agency_phone_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Phone</p>
                     <asp:TextBox ID="TextBox14" runat="server"  class="inp"></asp:TextBox>
 
                 </div>
                 <hr>
                 <asp:Button ID="ag_phn_edt" runat="server" Text="Update" class="btn" OnClick="ag_phn_edt_Click"/>
             </div>
         </div>
     </section>
    <!--popup agency address edit-->
    <section class="popup_address">
         <asp:Label ID="Label7" runat="server" Text="" ForeColor="Red"></asp:Label>
         <div class="container">
             <p class="heading">Edit Address</p>
             <i class='bx bx-x' id="address_close"></i>
             <div class="content">
                 <div class="info">
                     <p runat="server" class="lb">Address</p>
                     <asp:TextBox ID="TextBox15" runat="server"  class="adrs" TextMode="MultiLine"></asp:TextBox>
 
                 </div>
                 <hr>
                 <asp:Button ID="ag_adrs_edt" runat="server" Text="Update" class="btn" OnClick="ag_adrs_edt_Click"/>
             </div>
         </div>
     </section>

    

    <script src="../javascript/profile_script.js"></script>
</asp:Content>
