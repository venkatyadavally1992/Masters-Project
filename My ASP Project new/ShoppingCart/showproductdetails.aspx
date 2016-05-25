<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="showproductdetails.aspx.cs" Inherits="ShoppingCart.WebForm2" %>
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
        <td class="auto-style2"><strong>Prodcut Details :</strong><asp:Label ID="lblICart" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewCart.aspx">View Cart</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Main_Img") %>' />
                    <br />
                <%--<asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Eval("ImageUrl") %>' Visible="False"></asp:Label><br />--%>
                   Name        : <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    <br />
                    Details   : <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Details") %>'></asp:Label>
                    <br />
                   Cost         : <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Cost", "{0:##0.00}" ) %>'></asp:Label>
                    <br />
                <br />
                <br />
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
    <tr>
        <td>
            Avalible : 
            <asp:Label ID="lblPrice" runat="server" Text='0'></asp:Label>
             <br />
            <asp:TextBox ID="txtQty" runat="server" Width="50px" CssClass="numb" MaxLength="3">1</asp:TextBox>
            <label style="color: red"></label>
            <br />
            <asp:Button ID="btnAdd" runat="server"  OnClientClick="if ( ! Uservalidation()) return false;" OnClick="Button1_Click" Text="Add to Cart" />
                            <script>
                                function Uservalidation() {
                                    var flag = 0;
                                    if (document.getElementById('<%=txtQty.ClientID %>').value == "") {
                                        document.getElementById('<%=txtQty.ClientID %>').style.borderColor = "red";
                                        document.getElementById('<%=txtQty.ClientID %>').nextElementSibling.innerHTML = "Fill...";
                                        flag = 1;
                                    }
                                    else {
                                        var Qty = document.getElementById('<%=txtQty.ClientID %>').value;
                                        var avb = document.getElementById('<%=HfStock.ClientID %>').value;
                                        if (parseInt(Qty) <= parseInt(avb))
                                        {
                                            document.getElementById('<%=txtQty.ClientID %>').style.borderColor = "#DDD";
                                            document.getElementById('<%=txtQty.ClientID %>').nextElementSibling.innerHTML = "";
                                        }
                                        else
                                        {
                                            document.getElementById('<%=txtQty.ClientID %>').style.borderColor = "red";
                                            document.getElementById('<%=txtQty.ClientID %>').nextElementSibling.innerHTML = "Fill less Quantity...";
                                            flag = 1;
                                            
                                        }
                                    }

                                    if (flag == 1) {
                                        return false;
                                    }
                                    else {
                                        return true;
                                    }
                                }

                            </script>
            <br />
            <br />
            <asp:HiddenField ID="HfStock" runat="server" />
            
            <asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Return to Products Page</asp:HyperLink>
        </td>
    </tr>
</table>
</asp:Content>












   
   
    
    
        
           
           
        
    
    
