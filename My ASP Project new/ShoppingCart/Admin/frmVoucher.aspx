<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="frmVoucher.aspx.cs" Inherits="ShoppingCart.Admin.frmVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="10" cellspacing="10" class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2"><strong>Add Voucher</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Code</td>
            <td>
                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                 </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Value(%)</td>
            <td>
                <asp:TextBox ID="txtvalue" runat="server" ></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        
        
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" OnClientClick="if ( ! Uservalidation()) return false;"  />
                            <script>
                                function Uservalidation() {
                                    var flag = 0;
                                    if (document.getElementById('<%=txtCode.ClientID %>').value == "") {
                                        document.getElementById('<%=txtCode.ClientID %>').style.borderColor = "red";
                                        document.getElementById('<%=txtCode.ClientID %>').nextElementSibling.innerHTML = "Fill...";
                                        flag = 1;
                                    }
                                    else {
                                        document.getElementById('<%=txtCode.ClientID %>').style.borderColor = "#DDD";
                                        document.getElementById('<%=txtCode.ClientID %>').nextElementSibling.innerHTML = "";
                                    }
                                    if (document.getElementById('<%=txtvalue.ClientID %>').value == "") {
                                        document.getElementById('<%=txtvalue.ClientID %>').style.borderColor = "red";
                                        document.getElementById('<%=txtvalue.ClientID %>').nextElementSibling.innerHTML = "Fill...";
                                        flag = 1;
                                    }
                                    else {
                                        document.getElementById('<%=txtvalue.ClientID %>').style.borderColor = "#DDD";
                                        document.getElementById('<%=txtvalue.ClientID %>').nextElementSibling.innerHTML = "";
                                    }

                                    if (flag == 1) {
                                        return false;
                                    }
                                    else {
                                        return true;
                                    }
                                }

                            </script>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" CellSpacing="10" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand">
                                                    <Columns>
                                                        
                                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server"  class="btn btn-danger" CommandName="Del" CommandArgument='<%# Bind("id") %>' Font-Overline="false" Text="Delete"> Delete </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Srno" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litSrno" runat="server" Text='<%# Bind("id") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Code">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litcname" runat="server" Text='<%# Bind("Code") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Category Name">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litcvalue" runat="server" Text='<%# Bind("Value") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        

                                                    </Columns>
                                                </asp:GridView>
                                            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
