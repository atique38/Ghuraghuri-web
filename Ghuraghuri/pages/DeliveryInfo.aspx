<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeliveryInfo.aspx.cs" Inherits="Ghuraghuri.pages.WebForm23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_delivery.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="delivery">
        <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="deliver_container">
            <h2 style="text-align:center">Delivery Information</h2>
            <asp:Label ID="Label1" runat="server" Text="Address:" class="lb"></asp:Label>
            <asp:TextBox ID="adrs" runat="server" class="inp"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Phone No." class="lb"></asp:Label>
            <asp:TextBox ID="phn" runat="server" class="inp" TextMode="Number"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Payment Method:" class="lb"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                <asp:ListItem Selected="True" class="rb">Cash On Delivery</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" class="btn" OnClick="ConfirmBtn_Click"/>
        </div>
    </section>
</asp:Content>
