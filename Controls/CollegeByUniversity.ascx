<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CollegeByUniversity.ascx.cs"
    Inherits="Controls_CollegeByUniversity" %>
<table border="0" cellpadding="2" cellspacing="2" width="100%" align="center">
    <tr>
        <td align="left" valign="top">
            <asp:DataList ID="CollegeByUniversityList" runat="server" RepeatColumns="3" Width="100%">
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
