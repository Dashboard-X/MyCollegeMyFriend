<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/DefaultMasterPage.master"
    CodeFile="Join.aspx.cs" Inherits="Member_Join" Title="Member Registration" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="2" cellspacing="2" width="98%" align="center" style="border: solid 1px #00AEEF;">
        <tr>
            <td>
                <asp:Label ID="LabelUserLoginID" runat="server" Text="User LogiID" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxUserLoginID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelPassword" runat="server" Text="Password" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelEmail" runat="server" Text="Email" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelFirstName" runat="server" Text="First Name" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelLastName" runat="server" Text="Last Name" Width="150px"></asp:Label>
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelCountry" runat="server" Text="Country" Width="150px"></asp:Label>
                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
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
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Join" /></td>
        </tr>
    </table>
</asp:Content>
