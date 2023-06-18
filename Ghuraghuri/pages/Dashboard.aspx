<%@ Page Title="" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Ghuraghuri.pages.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="dashboard_user">
        <div class="box">
            <div class="content">
                <span id="counter1" ></span>
                <h3>Tour Completed</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter2" ></span>
                <h3>Blog</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter3" ></span>
                <h3>Orders</h3>
            </div>
        </div>
        
    </section>
    <section class="dashboard_admin">
        <div class="box">
            <div class="content">
                <span id="counter4" ></span>
                <h3>Users</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter5" ></span>
                <h3>Agencies</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter6" ></span>
                <h3>Places</h3>
            </div>
        </div>
        
    </section>
     <section class="dashboard_agency">
        <div class="box">
            <div class="content">
                <span id="counter7" ></span>
                <h3>Offered Tours</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter8" ></span>
                <h3>Running Tours</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter9" ></span>
                <h3>Pending Bookings</h3>
            </div>
        </div>
        
    </section>

    


    <script src="../javascript/script_counter.js"></script>
</asp:Content>
