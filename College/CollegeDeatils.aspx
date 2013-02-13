<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="CollegeDeatils.aspx.cs" Inherits="College_CollegeDeatils" Title="MyCollegeMyFriend :: College Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" width="100%" align="center">
        <tr>
            <td colspan="6">
                <table border="0" cellpadding="2" cellspacing="2" width="100%" align="center" style="border: solid 1px #00AEEF;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" Text="College Detail:" ForeColor="Green" Font-Bold="true"
                                Font-Size="14pt"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" valign="top">
                            <asp:Image ID="CollegeImages" runat="server" />
                        </td>
                        <td width="15%">
                            &nbsp;</td>
                        <td valign="top" width="60%" align="left">
                            <table>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="LabelUnivName" runat="server" Text="Name" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelName" runat="server" CssClass="BoldGreenText"></asp:Label>
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
                                        <asp:Label ID="Label1" runat="server" Text="College University" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelUniversity" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label2" runat="server" Text="Course In College" Width="200px" CssClass="LightGreenText"></asp:Label>
                                        <asp:Label ID="LabelCollegeCourse" runat="server" CssClass="BoldGreenText"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
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
                            <asp:Label ID="LabelImages" runat="server" Text="College Images:" ForeColor="Green"
                                Font-Bold="true" Font-Size="14pt"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:DataList ID="DataListCollegeImage" runat="server" RepeatColumns="6" Width="100%">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="middle" align="center" height="110px" width="110px" class="imageborder">
                                                <%-- <a class="whitetext" href='<%#getHREF(Container.DataItem)%>'>--%>
                                                <img id="imgmodel" align="middle" class="imageborder" runat="server" src='<%#getSRC(Container.DataItem)%>'
                                                    border="0" title="Click Here To View Profile"><%--</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
