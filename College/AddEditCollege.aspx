<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="AddEditCollege.aspx.cs" Inherits="College_AddEditCollege" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" width="98%" align="center" style="border: solid 1px #00AEEF;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Select University" Width="200px"></asp:Label>
                <asp:DropDownList ID="ddlUniversity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelCollegeName" runat="server" Text="College Name" Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxCollegeName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelCountry" runat="server" Text="Country" Width="150px"></asp:Label>
                <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelState" runat="server" Text="State" Width="150px"></asp:Label>
                <asp:DropDownList ID="ddlState" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="txtState" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="StateErrorLabel" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelCity" runat="server" Text="City" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelZip" runat="server" Text="Zip" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxZip" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" /></td>
        </tr>
    </table>
</asp:Content>
