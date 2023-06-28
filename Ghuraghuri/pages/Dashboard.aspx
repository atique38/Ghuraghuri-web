<%@ Page Title="" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Ghuraghuri.pages.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="dashboard_user" id="user_dash" runat="server">
        <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="box">
            <div class="content">
                <span id="counter1"></span>
                <h3>Tour Completed</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter2"></span>
                <h3>Blog</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter3"></span>
                <h3>Orders</h3>
            </div>
        </div>

    </section>
    <section class="dashboard_admin" id="admin_dash" runat="server">
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="box" style="width:13rem">
            <div class="content">
                <span id="counter4"></span>
                <h3>Users</h3>
            </div>
        </div>
        <div class="box" style="width:13rem">
            <div class="content">
                <span id="counter5"></span>
                <h3>Agencies</h3>
            </div>
        </div>
        <div class="box" style="width:13rem">
            <div class="content">
                <span id="counter6"></span>
                <h3>Places</h3>
            </div>
        </div>
        <div class="box" style="width:13rem">
            <div class="content">
                <span id="counter10"></span>
                <h3>Pending Orders</h3>
            </div>
        </div>

    </section>
    <section class="dashboard_agency" id="agency_dash" runat="server">
        <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="box">
            <div class="content">
                <span id="counter7"></span>
                <h3>Offered Tours</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter8"></span>
                <h3>Earned(tk)</h3>
            </div>
        </div>
        <div class="box">
            <div class="content">
                <span id="counter9"></span>
                <h3>Pending Bookings</h3>
            </div>
        </div>

    </section>

    <!--user order-->
    <section class="order_history" id="order_hist" runat="server">
        <h3>My Orders</h3>
        <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="OrderHistoryTable" runat="server" class="cart_table">

        </asp:Table>
    </section>

    <!--user booking history-->
    <section class="booking_history" id="booking_hist" runat="server">
        <h3>My Bookings</h3>
        <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="BookingHistoryTable" runat="server" class="cart_table">
        </asp:Table>
    </section>

    <!--agency booking dashboard-->
    <section class="booking_history" id="ag_booking_dash" runat="server">
        <h3>Booking Status</h3>
        <asp:Label ID="Label5" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="AgBookingDash" runat="server" class="cart_table">

        </asp:Table>
    </section>
    <!--admin order dashboard-->
    <section class="booking_history" id="ad_order_dash" runat="server">
        <asp:Label ID="Label6" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="OrdersTable" runat="server" class="cart_table">

        </asp:Table>
    </section>
    <script src="../javascript/script_counter.js"></script>
</asp:Content>
