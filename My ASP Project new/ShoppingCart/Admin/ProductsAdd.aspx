<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="ProductsAdd.aspx.cs" Inherits="ShoppingCart.Admin.WebForm3" %>
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
            <td class="auto-style2"><strong>Add Products</strong></td>
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
            <td>Select Category</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="300px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue ="Select.." ControlToValidate="DropDownList1" ErrorMessage="Select Category" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Title</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Enter Title" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Details</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Enter Details" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Description</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Description" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Cost</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Cost" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Number only" ForeColor="#CC3300" ValidationExpression="^[0-9]*\.?[0-9]*$"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
          <tr>
            <td>Stock</td>
            <td>
                <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStock" ErrorMessage="Enter Stock" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStock" ErrorMessage="Enter Number only" ForeColor="#CC3300" ValidationExpression="^[0-9]*\.?[0-9]*$"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Image</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Image ID="Image1" runat="server" Width="100px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Cancel" ValidationGroup="cancel" OnClick="Button2_Click" />
            </td>
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
                                                                <asp:Literal ID="litcname" runat="server" Text='<%# Bind("category") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Image">
                                                            <ItemTemplate>
                                                                <asp:Image ID ="img" runat ="server" Width ="65" Height ="65" ImageUrl ='<% # Bind("Main_Img") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText=" Name">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litname" runat="server" Text='<%# Bind("Name") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText=" Details">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litdetails" runat="server" Text='<%# Bind("Details") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litdescription" runat="server" Text='<%# Bind("Description") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Cost">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litcost" runat="server" Text='<%# Bind("Cost") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Total Stock">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litStock" runat="server" Text='<%# Bind("Stock") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                                                                           
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
