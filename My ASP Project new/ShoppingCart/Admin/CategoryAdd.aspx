<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryAdd.aspx.cs" Inherits="ShoppingCart.Admin.WebForm2" %>
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
   
                                    <table cellpadding="10" cellspacing="10" class="auto-style1">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td class="auto-style2"><strong>Add Category</strong></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#CC3300"></asp:Label>
							                </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>category</td>
                                            <td>
                              <asp:TextBox ID="txtTitle" runat="server" Height="21px" Width="500px"></asp:TextBox>
								            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Image</td>
                                            <td>
                              <asp:FileUpload ID="FileUpload1" runat="server"  class="input-file uniform_on" />
								                <asp:Image ID="Image1" runat="server" Width="50px" />
								            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                             <asp:Button ID="btn_Submit" runat="server" onclick="btn_Submit_Click" 
                                Text="Submit" class="btn" OnClientClick="return validatetext()"  />
                             <asp:Button ID="btn_cancel" runat="server" onclick="btn_cancel_Click" 
                                Text="Cancel" class="btn"  />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" CellSpacing="10" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Udate" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" class="btn btn-success" CommandName="Select" Font-Overline="false" Text="Edit"> Edit </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" class="btn btn-danger" CommandName="Delete" Font-Overline="false" Text="Delete"> Delete </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Srno" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litSrno" runat="server" Text='<%# Bind("id") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category Name">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litcname" runat="server" Text='<%# Bind("name") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Image">
                                                            <ItemTemplate>
                                                                <asp:Image ID ="img" runat ="server" Width ="65" Height ="65" ImageUrl ='<% # Bind("Main_Img") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
</asp:Content>
