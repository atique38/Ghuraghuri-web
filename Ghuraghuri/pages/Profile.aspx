<%@ Page Title="Profile" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Ghuraghuri.pages.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/style_profile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="user_account" runat="server">

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
            <h4>Change Password</h4>
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
</asp:Content>
