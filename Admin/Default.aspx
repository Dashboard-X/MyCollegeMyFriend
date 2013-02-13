<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <asp:LinkButton ID="lnkAddUniversity" runat="server" Text="Add University" OnClick="lnkAddUniversity_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkAddCollege" runat="server" Text="Add College" OnClick="lnkAddCollege_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
