<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Controls_Search" %>
<table border="0" cellpadding="2" cellspacing="2" width="98%" align="center" style="border: solid 1px #00AEEF; background-color:#00AEEF;">
    <tr>
        <td colspan="2">
            <asp:Label ID="LabelSearch" runat="server" Text="Search College By:" ForeColor="Green"
                Font-Bold="true" Font-Size="14pt"></asp:Label>&nbsp;
        </td>
    </tr>
    <tr>
        <td height="5px">
        </td>
    </tr>
    <tr>
        <td width="50%" valign="top">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=" Country :" ForeColor="Green"
                            Font-Bold="true" Font-Size="12pt" Width="100px"></asp:Label>
                        &nbsp;
                        <asp:DropDownList ID="ddlCountry" runat="server" Width="180px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Button ID="ButtonCountrySearch" runat="server" Text="Go" OnClick="ButtonCountrySearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="University :" ForeColor="Green"
                            Font-Bold="true" Font-Size="12pt" Width="100px"></asp:Label>
                        &nbsp;
                        <asp:DropDownList ID="ddlUniversity" runat="server" Width="180px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Button ID="ButtonUniversitySearch" runat="server" Text="Go" OnClick="ButtonUniversitySearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text=" Course :" ForeColor="Green" Font-Bold="true"
                            Font-Size="12pt" Width="100px"></asp:Label>
                        &nbsp;
                        <asp:DropDownList ID="ddlCourse" runat="server" Width="180px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Button ID="ButtonCourseSearch" runat="server" Text="Go" OnClick="ButtonCourseSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="ButonHome" runat="server" Text="HOME" OnClick="ButonHome_Click" Width="100px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
