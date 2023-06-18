<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm15.aspx.cs" Inherits="Ghuraghuri.pages.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/signup_style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="signUp">
        
        <div class="sign_container">
            <h2 style="text-align:center">Sign Up</h2>
            <div class="content">
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Placeholder="Enter Email" class="inp"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Placeholder="Enter Password" class="inp" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Sign Up" class="btn" OnClick="Button1_Click" />
            <div style="text-align:center;margin-top:.5rem;color:black;font-size:1rem">
                <asp:LinkButton ID="LinkButton1" runat="server" style="color:black" OnClick="LinkButton1_Click">
                Already have account? Log In</asp:LinkButton>
            </div>
        </div>
        
    </section>
    
</asp:Content>
