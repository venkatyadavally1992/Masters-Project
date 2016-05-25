<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="showproducts.aspx.cs" Inherits="ShoppingCart.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            font-size: large;
            color: #003399;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">




    <table cellpadding="10" cellspacing="10" class="auto-style1">
        <tr>
            <td class="auto-style2"><strong>Show Products</strong></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DL_Products" runat="server" RepeatColumns="4">
                    <ItemTemplate>
                        <div class="prod_box">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"showproductdetails.aspx?ID="+ Eval("id")%>'>
                                               <span><img src='<%#Eval("Main_img") %>' style ="width :100px;height :100px;" /></span>                    
                                        </asp:HyperLink>
                            <div class="prod_details">
                                <h1>
                                    <asp:HyperLink ID="Main_img" runat="server" CssClass="dark-color active-hover" NavigateUrl='<%#"showproductdetails.aspx?id="+Eval("id")%>'>       
                                        <b class="middle-color">›</b><asp:Label ID="dd" runat="server" Text='<%#Eval("Name")%>'  /></b>                                       
                                        </asp:HyperLink></h1><p>

                                    <asp:Label ID ="lbldetails" runat ="server" Text ='<%# Eval ("details") %>'></asp:Label></p></div></div></ItemTemplate></asp:DataList></td></tr></table></asp:Content>