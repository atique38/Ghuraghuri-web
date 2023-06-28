<%@ Page Title="Orders" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Ghuraghuri.pages.WebForm26" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/style_dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="booking_history" id="ag_booking_dash" runat="server">
        <asp:Label ID="Label5" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="OrdersTable" runat="server" class="cart_table">

        </asp:Table>
    </section>
</asp:Content>
