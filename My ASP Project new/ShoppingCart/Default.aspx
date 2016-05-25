<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoppingCart._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Online Super Market</h2>
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Category</h3>
    <table cellpadding="10" cellspacing="10" class="auto-style1">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DL_Products" runat="server" RepeatColumns="4">
                    <ItemTemplate>
                        <div class="prod_box">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"ShowProducts.aspx?ID="+ Eval("id")%>'>
                                               <span><img src='<%#Eval("Main_img") %>' style ="width :100px;height :100px;" /></span>                    
                                        </asp:HyperLink>
                            <div class="prod_details">
                                <h1>
                                    <asp:HyperLink ID="Main_img" runat="server" CssClass="dark-co
                                        
                                        
                                        r active-hover" NavigateUrl='<%#"showproducts.aspx?id="+Eval("id")%>'>       
                                        <b class="middle-color">›</b><asp:Label ID="dd" runat="server" Text='<%#Eval("Name")%>'  /></b>                                       
                                        </asp:HyperLink></h1></div></div></ItemTemplate></asp:DataList></td></tr></table></asp:Content>