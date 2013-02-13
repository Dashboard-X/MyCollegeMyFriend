<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentCollege.ascx.cs"
    Inherits="Controls_RecentCollege" %>
<table border="0" cellpadding="2" cellspacing="2" width="100%" align="center" style="border: solid 1px #00AEEF;">
    <tr>
        <td align="left">
            &nbsp;
            <asp:Label ID="labelOnlineMembers" runat="server" Text="College" ForeColor="Green"
                Font-Bold="true" Font-Size="14pt"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <asp:DataList ID="RecentCollegeList" runat="server" RepeatColumns="5" Width="100%">
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
