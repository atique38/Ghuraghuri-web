<%@ Page Title="Order History" Language="C#" MasterPageFile="~/pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Ghuraghuri.pages.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_order_history.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="order_history">
        <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Table ID="OrderHistoryTable" runat="server" class="cart_table">

        </asp:Table>
    </section>
</asp:Content>
