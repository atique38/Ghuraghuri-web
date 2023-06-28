<%@ Page Title="Bookings" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="Ghuraghuri.pages.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="booking_history" id="booking_hist" runat="server">
        
        <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="BookingHistoryTable" runat="server" class="cart_table">

        </asp:Table>
    </section>
</asp:Content>
