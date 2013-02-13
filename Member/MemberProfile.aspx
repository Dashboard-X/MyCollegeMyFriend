<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="MemberProfile.aspx.cs" Inherits="Member_MemberProfile" Title="MyCollegeMyFriend :: Member Details" %>

<%@ Register Src="~/Controls/Friend.ascx" TagName="Friend" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" width="100%" align="center">
        <tr>
            <td colspan="6">
                <table border="0" cellpadding="2" cellspacing="2" width="100%" align="center" style="border: solid 1px #00AEEF;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" Text="Member Detail:" ForeColor="Green" Font-Bold="true"
                                Font-Size="14pt"></asp:Label>&nbsp;
                        </td>
                        <td align="right">
                            <asp:Button ID="ButtonFriend" runat="server" Text="Add Friend" ForeColor="Green"
                                Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" valign="top">
                            <asp:Image ID="MemberImages" runat="server" />
                        </td>
                        <td width="15%">
                            &nbsp;</td>
                        <td valign="top" width="60%" align="left">
                            <table>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="LabelName" runat="server" Text="First Name" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelFirstName" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label1" runat="server" Text="Last Name" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelLastName" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label2" runat="server" Text="Email" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelEmail" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label4" runat="server" Text="Country" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelCountry" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label3" runat="server" Text="State" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelState" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label6" runat="server" Text="City" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelCity" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label5" runat="server" Text="Zip" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelZip" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label8" runat="server" Text="Member Since :" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelJoinDate" runat="server" CssClass="LightGreenText"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table border="0" cellpadding="2" cellspacing="2" width="100%" align="center" style="border: solid 1px #00AEEF;">
                    <tr>
                        <td>
                            <asp:Label ID="LabelProfile" runat="server" Text="Images:" ForeColor="Green" Font-Bold="true"
                                Font-Size="14pt"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:DataList ID="DataListMemberImage" runat="server" RepeatColumns="6" Width="100%">
                                <ItemTemplate>
                                    <table border="0" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td valign="middle" align="center" height="155px" width="155px" class="imageborder">
                                                <%-- <a class="whitetext" href='<%#getHREF(Container.DataItem)%>'>--%>
                                                <img id="imgmodel" align="middle" class="imageborder" runat="server" src='<%#getSRC(Container.DataItem)%>'
                                                    border="0" title="Click Here To View Profile"><%--</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
            <td>
                <Uc1:Friend id="Friend" runat="server">
                </Uc1:Friend>
            </td>
        </tr>--%>
    </table>
</asp:Content>
