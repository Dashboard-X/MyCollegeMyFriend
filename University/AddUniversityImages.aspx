<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="AddUniversityImages.aspx.cs" Inherits="University_AddUniversityImages" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" width="98%" align="center" style="border: solid 1px #00AEEF;">
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr style="background-color: White; height: 25px;">
            <td>
                &nbsp;
                <asp:Label ID="LabelJoinMessage" runat="server" SkinID="lblRedText" Text="Welcome"
                    Font-Bold="true" Font-Size="12pt"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="LabelJoinMessage1" runat="server" SkinID="lblGreenText" Text=" Upolad Images !"
                    Font-Bold="true" Font-Size="12pt"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="Label40" runat="server" SkinID="lblRedText" Text="Make your search best"
                    Font-Bold="true" Font-Size="12pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div class="RoundedBgBlue">
                    <b class="top"><b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
                    </b>
                    <div class="boxcontent">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblError1" runat="server"></asp:Label>
                                    <input id="BrowseImage0" contenteditable="false" runat="server" class="NormalTextBox"
                                        name="BrowseImage0" type="file" style="width: 400px" />
                                    <br />
                                    <asp:Button ID="btnUpload1" runat="server" CssClass="NormalButton" Text="Upload"
                                        OnClick="btnUpload1_Click" Font-Bold="True" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:DataList ID="ResultList" runat="server" RepeatColumns="7" Width="100%" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" height="130" width="120">
                                                <tr>
                                                    <td align="center" height="10">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="center" width="120" height="130" bgcolor="white" class="imageborder">
                                                        <img align="middle" src='<%#getSRC(Container.DataItem)%>' border="0">
                                                        <input type="hidden" id="hiddenId" value='<%# DataBinder.Eval(Container.DataItem, "ImageId") %>'
                                                            runat="server" name="hiddenId" />
                                                        <input type="hidden" id="hiddenImageName" value='<%# DataBinder.Eval(Container.DataItem, "ImageName") %>'
                                                            runat="server" name="Hidden1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" height="15">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnFinish" runat="server" Text="Finish" OnClick="btnFinish_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <b class="bottom"><b class="b4b"></b><b class="b3b"></b><b class="b2b"></b><b class="b1b">
                    </b></b>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


