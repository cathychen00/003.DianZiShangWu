<%@ Page Language="C#" AutoEventWireup="true" CodeFile="group.aspx.cs" Inherits="admin_group" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/Admin_Default.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../JScript/common.js"></script>

</head>
<body>
    <form id="TableForm" runat="server">
        <table cellpadding="0" cellspacing="0" class="twidth" width="576">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div class="mframe">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="tl">
                                </td>
                                <td class="tm">
                                    <span class="tt">
                                        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                                        </asp:SiteMapPath>
                                    </span>
                                </td>
                                <td class="tr">
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="ml">
                                </td>
                                <td class="mm">
                                    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="角色">
                                                <ItemTemplate>
                                                 <asp:Label runat="server" ID="roleName" Text='<%# Container.DataItem.ToString() %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField Text="修改" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp;
                                    <div style="margin-top: 10px; width: 100%; text-align: center">
                                        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                    </div>
                                    <asp:TextBox ID="roleName" runat="server"></asp:TextBox>
                                    <asp:Button ID="addBtn" runat="server" Text="创建角色" OnClick="addBtn_Click" />
                                    <asp:Label ID="Msg" runat="server" Text="Label"></asp:Label></td>
                                <td class="mr">
                                </td>
                            </tr>
                            <tr>
                                <td class="ml">
                                </td>
                                <td class="mm">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                    <asp:Button ID="deleteBtn" runat="server" Text="删除" OnClick="deleteBtn_Click" />
                                    <asp:Label ID="msg2" runat="server" Text="Label"></asp:Label></td>
                                <td class="mr">
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="bl">
                                </td>
                                <td class="bm">
                                    &nbsp;</td>
                                <td class="br">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

