<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="AddEditUniversity.aspx.cs" Inherits="University_AddEditUniversity"
    Title="MyCollegeMyFriend :: Add University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" width="98%" align="center" style="border: solid 1px #00AEEF;">
        <tr>
            <td colspan="6" align="center">
                <table cellpadding="4" cellspacing="4" align="center">
                    <tr>
                        <td align="left">
                            <asp:Label ID="LabelUniversityName" runat="server" Text="University Name" Width="150px"></asp:Label>
                            <asp:TextBox ID="TextBoxUniversityName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LabelCountry" runat="server" Text="Country" Width="150px"></asp:Label>
                            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                       <td align="left">
                            <asp:Label ID="LabelState" runat="server" Text="State" Width="150px"></asp:Label>
                            <asp:DropDownList ID="ddlState" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtState" runat="server" Visible="false"></asp:TextBox>
                            <asp:Label ID="StateErrorLabel" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LabelCity" runat="server" Text="City" Width="150px"></asp:Label>
                            <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LabelZip" runat="server" Text="Zip" Width="150px"></asp:Label>
                            <asp:TextBox ID="TextBoxZip" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
