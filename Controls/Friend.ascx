<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Friend.ascx.cs" Inherits="Controls_Friend" %>
<table border="0" cellpadding="2" cellspacing="2" width="100%" align="center" style="border: solid 1px #00AEEF;">
    <tr>
        <td align="left">
            &nbsp;
            <asp:Label ID="labelMembers" runat="server" Text="Members Friends" ForeColor="Green"
                Font-Bold="true" Font-Size="14pt"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <asp:DataList ID="FriendList" runat="server" RepeatColumns="3" Width="100%">
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
