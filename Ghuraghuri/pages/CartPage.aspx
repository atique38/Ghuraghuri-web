<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Ghuraghuri.pages.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style_cart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="cart">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
                <asp:Table class="cart_table" ID="cartTable" runat="server">
                    <asp:TableHeaderRow class="tr">
                        <asp:TableHeaderCell class="th">Product</asp:TableHeaderCell>
                        <asp:TableHeaderCell class="th">Quantity</asp:TableHeaderCell>
                        <asp:TableHeaderCell class="th">Price</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    
                </asp:Table>
                <div style="display:flex;justify-content:end;margin:1rem">
                    <h3>Total: </h3>
                    <h3 id="total" runat="server">1000</h3>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Place Order" class="btn"/>
            </ContentTemplate>
        </asp:UpdatePanel>

        
    </section>
        
    <script src="../javascript/passing_script.js"></script>
</asp:Content>
