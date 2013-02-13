<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="My College My Friend :: The world largest college friend network site" %>

<%@ Register Src="~/Controls/RecentMembers.ascx" TagName="RecentMembers" TagPrefix="Uc1" %>
<%@ Register Src="~/Controls/RecentUniversity.ascx" TagName="University" TagPrefix="Uc2" %>
<%@ Register Src="~/Controls/RecentCollege.ascx" TagName="College" TagPrefix="Uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="2" cellspacing="2" width="98%" align="center">
        <tr>
            <td>
                <Uc1:RecentMembers ID="RecentMembers" runat="server" />
            </td>
        </tr>
         
        <tr>
            <td>
                <Uc2:University ID="University" runat="server" />
            </td>
        </tr>
         
        <tr>
            <td> 
              <Uc3:College ID="college" runat="server" />
            </td>
        </tr>
        <tr>
            <td height="10px">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
