<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="SearchCollegeByCountry.aspx.cs" Inherits="SearchResult_SearchCollegeByCountry"
    Title="MyCollegeMyFriend :: Search College" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="labelOnlineMembers" runat="server" Text="College By Country" SkinID="lblRedText"
                    Font-Size="14pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:DataList ID="CollegeListByCountry" runat="server" RepeatColumns="6" Width="100%">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="middle" align="center" height="110px" width="110px" class="imageborder">
                                    <a class="whitetext" href='<%#getHREF(Container.DataItem)%>'>
                                        <img id="imgmodel" align="middle" class="imageborder" runat="server" src='<%#getSRC(Container.DataItem)%>'
                                            border="0" title="Click Here To View Profile"></a>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
