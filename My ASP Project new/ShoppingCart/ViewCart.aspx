<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="ShoppingCart.WebForm3" %>
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
   <%-- <style type="text/css"> 
        .tblTD {
 
            width:200px;
            font-size:15px;
            text-align:center;
            color:white;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table cellpadding="10" cellspacing="10">
    <tr>
        <td ><strong>View Cart:</strong></td>
    </tr>
    <tr>
        <td>
            <asp:Repeater ID="rptProductList" runat="server" onitemcommand="rptProductList_ItemCommand" onitemdatabound="rptProductList_ItemDataBound" >
                <HeaderTemplate >
                    <div style="border:1px solid #6f6e6e; width :100%;">
                        <table style ="width :100%;">
                            <tr style="background: #6f6e6e; height: 25px">
                                
                                <td class="tblTD">
                                    <asp:Label ID="lbl" runat="server" Text="ProductName"> </asp:Label>
                                </td>
                                <td class="tblTD">
                                    <asp:Label ID="Label1" runat="server" Text="Price">     
                                 </asp:Label>
                                </td>
                                <td class="tblTD">
                                    <asp:Label ID="Label2" runat="server" Text="Qty">
                                     </asp:Label>
                                </td>
                                <td class="tblTD">
                                    <asp:Label ID="Label3" runat="server" Text="Total Price">
                                     </asp:Label>
                                </td>
                                
                            </tr>
                        </table>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <tr>
                           <td  style="color:#6f6e6e">
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("ProductTitle") %>'></asp:Label>
                         &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("MRP")%>'></asp:Label>
                          &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;   
                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                                <asp:Label ID="lbltotlPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label>
                            
                            </td> 
                            <td  style="color:#6f6e6e">
                                <asp:TextBox ID="txtQuantity" runat="server" Width="50px">
                   </asp:TextBox>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument='<%#Eval("ProductId") %>' CommandName="UpdateColumn" Text="Update">
               </asp:LinkButton>
                            </td>
                            <td  style="color:#6f6e6e">
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("ProductId") %>' CommandName="DeleteColumn" Text="X">  
                </asp:LinkButton>
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                            </td>
                            <td >
                  <%--<asp:Image ID="Image1" runat="server"   
                        ImageUrl='<%#"Handler1.ashx?id="+ Eval("ProductId")%>'
                        Height="125px" Width="125px" />--%>
                                <asp:Image ID="itemimg" runat="server" Height="125px" Width="125px" ImageUrl='<%#Eval("imgurl") %>' />
                        <%--<asp:Image ID="Image1" runat="server"  
                        ImageUrl='<%#"Eval("imgurl")%>'
                        Height="125px" Width="125px" />--%>
                            </td>
                        </tr>
                         
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                  
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCartNotselected" runat="server"></asp:Label>
            Total:
            <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        
    </tr>
    <tr>
        <td>
            <asp:Button ID="btn_pay" runat="server" onclick="btn_pay_Click" Text="Procced To Pay" />
            <asp:Button ID="btn_shop" runat="server" onclick="btn_shop_Click" Text="Continuee Shoping" />
        </td>
        <td>
            <p>
                *** Please check stock by going back before updating number of items in this page***
            </p>
        </td>
    </tr>
</table>
</asp:Content>
