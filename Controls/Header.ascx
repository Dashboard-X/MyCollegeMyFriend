<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
<table>
    <tr>
        <td>
            <asp:ImageButton ID="ImgLogo" ImageUrl="~/images/home-page_26.gif" runat="server" ToolTip="HOME" OnClick="ImgLogo_Click" />
        </td>
        <td valign="top" style="border: solid 1px #00AEEF;">&nbsp;
            <asp:Label ID="LabelUserLoginID" runat="server" Text="UserID" Visible="false" Width="70px" CssClass="BoldGreenText"></asp:Label>
            <asp:TextBox ID="TextBoxUserId" runat="server" Visible="false" Width="60px"></asp:TextBox>
            <br />&nbsp;    
            <asp:Label ID="LabelPassword" runat="server" Text="Password" Visible="false" Width="50px" CssClass="BoldGreenText"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" Visible="false" Width="60px"></asp:TextBox>
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"
                Visible="false" />
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" Visible="false" />
                <asp:Button ID="ButtonAdmin" runat="server" Text="Admin" Visible="false" OnClick="ButtonAdmin_Click" />
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click"
                Visible="false" />&nbsp;
            <br />
            <asp:Label ID="LabelLoginError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </td>
    </tr>
</table>
