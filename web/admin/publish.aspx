<%@ Page EnableViewState="false" StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="publish.aspx.cs" Inherits="admin_publish" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>出版社管理</title>
    <link href="../images/cssothers.css"
        type="text/css" rel="stylesheet" />
    <style type="text/css">
        <!--
        body {
            background-color: #ffffff;
        }
        -->
    </style>

    <script language="javascript" type="text/javascript" src="../JScript/common.js"></script>

</head>
<body>
    <form id="TableForm" runat="server">

        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0">
            <tbody>
                <tr>
                    <td class="Left_03" valign="top" width="8">
                        <img height="7"
                            src="../images/Admin_2.gif" width="8"></td>
                    <td class="Left_01">&nbsp;</td>
                    <td class="Left_04" valign="top" width="8">
                        <img height="7"
                            src="../images/Admin_5.gif" width="8"></td>
                </tr>
                <tr>
                    <td class="Left_03">&nbsp;</td>
                    <td>
                        <table class="SubMenu_Item" cellspacing="0" cellpadding="0" width="100%"
                            border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="Current_Item" id="TD1"><a
                                                        href="publish.aspx">出版社管理</a></td>
                                                    <td class="Default_Item" id="TD2"><a
                                                        href="addpublish.aspx">添加出版社</a></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="C_order_state" cellspacing="0" cellpadding="0" width="100%"
                            border="0">
                            <tbody>
                                <tr>
                                    <td style="font-size: 12px">&nbsp;<asp:Button ID="DeleteBtn" OnClientClick='return confirm("确定要删除吗?")' runat="server" Text="删除" OnClick="DeleteBtn_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <td>&nbsp;
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                      DataKeyNames="PublishID" SkinID="orange" EnableViewState="False" AllowPaging="True">
                      <Columns>
                          <asp:BoundField DataField="PublishName" HeaderText="出版社名称" />
                          <asp:BoundField DataField="PublishDec" HeaderText="说明" />
                          <asp:CheckBoxField DataField="IsMain" HeaderText="显示首页" SortExpression="IsMain" />
                          <asp:BoundField DataField="AddDate" DataFormatString="{0:yyyy年MM月dd日}" HeaderText="添加日期"
                              SortExpression="AddDate" />
                          <asp:HyperLinkField Text="修改" DataNavigateUrlFields="publishid" DataNavigateUrlFormatString="addPublish.aspx?edit={0}" HeaderText="修改" />
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" runat="server"
                                      type="checkbox" />
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <asp:CheckBox ID="chk" runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                  </asp:GridView>
                                            </td>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="Left_04">&nbsp;</td>
                </tr>
                <tr>
                    <td class="Left_03" valign="bottom" width="8" style="height: 19px">
                        <img height="8"
                            src="../images/Admin_8.gif" width="8"></td>
                    <td class="Left_02" style="height: 19px">&nbsp;</td>
                    <td class="Left_04" valign="bottom" width="8" style="height: 19px">
                        <img height="8"
                            src="../images/Admin_1.gif" width="8"></td>
                </tr>
            </tbody>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeletePublish"
            SelectMethod="GetPublishs" TypeName="Jiaen.BLL.Publish" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="publishID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

