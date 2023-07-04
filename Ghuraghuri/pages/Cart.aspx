<%@ Page Title="Cart" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Ghuraghuri.pages.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_cart.css" rel="stylesheet" />
    <title>Cart</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section>
                <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
                <asp:Table ID="cartTable" runat="server" class="cart_table">
                </asp:Table>
                <div style="display:flex;justify-content:end;margin:1rem">
                    <h3>Total: </h3>
                    <h3 id="totalCost" runat="server">0</h3>
                </div>
                <asp:Button ID="PlaceOrder" runat="server" Text="Place Order"  OnClick="PlaceOrder_Click" Enabled="false" CssClass="disabled"/>
            </section>
           
        </ContentTemplate>
    </asp:UpdatePanel>

    
    <script src="../javascript/passing_script.js"></script>
</asp:Content>
