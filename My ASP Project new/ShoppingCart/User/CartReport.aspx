<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="CartReport.aspx.cs" Inherits="ShoppingCart.User.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .auto-style1 {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding ="10" cellspacing ="10" >
    <tr>
            <td colspan="5" style="text-align: center; color: #CC0000">
                <asp:Literal ID="lit_message" runat="server"></asp:Literal>
            </td>
            <%--<td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>--%>
        </tr>
        <tr>
            <td class="auto-style1"> By Transaction Id
                </td>
            <td align="left">
                <asp:RadioButton ID="rb_id" runat="server" GroupName="rbsearch" 
                     />
            </td>
            <td>
                Enter Trancation Id:<asp:TextBox ID="txtstudentid" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"> By Dates
               </td>
            <td>
                <asp:RadioButton ID="rb_name" runat="server" GroupName="rbsearch" Text ="" TextAlign ="Left"  />
            </td>
            <td>
                Enter Star Date:<asp:TextBox ID="txtfname" runat="server"></asp:TextBox></td>
            <td>
                 Enter End Date:<asp:TextBox ID="txtmname" runat="server"></asp:TextBox></td>
            <td>
                <%--Last Name:<asp:TextBox ID="txtlname" runat="server"></asp:TextBox>--%>
            </td>
            <td>
                &nbsp;</td>
        </tr>
       
        <tr>
            <td colspan ="5" style="text-align: center">
                <asp:Button ID="btnSubmit" runat="server" Text="Search" 
                    CssClass ="btn btn-primary" onclick="btnSubmit_Click" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                    onclick="btncancel_Click" />
            </td>
            <%--<td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>--%>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                
                <asp:GridView ID="GridView1" runat="server" CellPadding="10" CellSpacing="10">
                </asp:GridView>
                
            </td>
        </tr>
        
    </table>
</asp:Content>
