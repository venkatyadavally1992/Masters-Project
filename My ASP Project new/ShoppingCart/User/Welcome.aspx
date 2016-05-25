<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="ShoppingCart.User.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table cellpadding="10" cellspacing="10" class="auto-style1" id ="tblviewcart" runat ="server" >
        <tr>
            <td class="auto-style2"><strong>View Cart:</strong></td>
        </tr>
        <tr>
            <td>
                <asp:Repeater ID="rptProductList" runat="server" onitemcommand="rptProductList_ItemCommand" onitemdatabound="rptProductList_ItemDataBound">
                    <HeaderTemplate>
                            <table>
                                <tr style="background: #6f6e6e; height: 25px">
                                    <td class="tblTD"></td>
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
                                    <td class="tblTD"></td>
                                    <td class="tblTD"></td>
                                </tr>
                            </table>
                    </HeaderTemplate>
                    
                    <ItemTemplate>
                        <div>
                            <tr>
                                
                                <td class="tblTD" style="color:#6f6e6e">
                                 
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("ProductTitle") %>'></asp:Label>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("MRP")%>'></asp:Label>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                                    <asp:Label ID="lbltotlPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                                    <asp:TextBox ID="txtQuantity" runat="server" Width="50px">
                   </asp:TextBox>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument='<%#Eval("ProductId") %>' CommandName="UpdateColumn" Text="Update">
               </asp:LinkButton>
                                
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("ProductId") %>' CommandName="DeleteColumn" Text="X">  
                </asp:LinkButton>
                                    <asp:Label ID="lblID" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td align="right">
                <asp:Label ID="lblCartNotselected" runat="server"></asp:Label>
                <asp:HiddenField ID="hftotal" runat="server" />
                <asp:HiddenField ID="hfcount" runat="server" />
                Total:
                <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                 
                <br />
            </td>
        </tr>
             <tr >
            <td>Apply PromoCode : <asp:TextBox ID="txtvoucher" runat="server" Visible="true"></asp:TextBox> <asp:Button ID="Button1" runat="server" onclick="btn_pay_Click1" Text="Apply" /><asp:Label ID="lblerroe" runat="server" Text=""></asp:Label><br /></td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td align="right">
                <br />
                <asp:Button ID="btn_pay" runat="server" onclick="btn_pay_Click" Text="Procced To Pay" />
                
            </td>
            
        </tr>
        
    </table>
    <br />
    <br />
    <br />
    <br />
    <asp:Image ID="Image12345" runat="server" HorizontalAlign="Center" ImageUrl='../Images/coupon.png' />
</asp:Content>
