<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentUniversity.ascx.cs"
    Inherits="Controls_RecentUniversity" %>
<table border="0" cellpadding="2" cellspacing="2" width="100%" align="center" style="border: solid 1px #00AEEF;">
    <tr>
        <td align="left">
            &nbsp;
            <asp:Label ID="labelOnlineMembers" runat="server" Text="University" ForeColor="Green"
                Font-Bold="true" Font-Size="14pt"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <asp:DataList ID="RecentUniversityList" runat="server" RepeatColumns="5" Width="100%" CellPadding="2" CellSpacing="2">
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
