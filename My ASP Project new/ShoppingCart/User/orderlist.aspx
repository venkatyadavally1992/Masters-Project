<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="orderlist.aspx.cs" Inherits="ShoppingCart.User.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    
    </div>
    <p>
        YOUR ORDER SUCEESS FULL
    </p>
    
    <p>
        Your Tansaction Id : <asp:Label ID="Label1" runat="server" BorderColor="#FF3399" 
            Font-Bold="True" Font-Underline="True" ForeColor="Blue" /></p>
    <p>
        your Payment is $:<asp:Label ID="lblamt" runat="server" BorderColor="#FF3399" 
            Font-Bold="True" Font-Underline="True" ForeColor="Blue"></asp:Label>
    </p>
</asp:Content>
