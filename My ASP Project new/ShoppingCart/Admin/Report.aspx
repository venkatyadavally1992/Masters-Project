<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ShoppingCart.Admin.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .style1
        {
            width: 100%;
        }
    .auto-style1 {
        font-size: large;
        color: #003399;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table cellpadding ="10" cellspacing ="10" >
    <tr>
         
            <p>
                *** In this console use regualr local date format USA***
            </p>
        
            <td colspan="5" style="text-align: center; " class="auto-style1">
                <strong>Report</strong></td>
        </tr>
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
            <td> Select User</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td> By Transaction Id
                </td>
            <td>
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
            <td> By Dates
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
