<%@ Page EnableViewState="false" StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="publish.aspx.cs" Inherits="admin_publish" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>出版社管理</title>
          <LINK href="../images/cssothers.css" 
type=text/css rel=stylesheet />
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
        
        <TABLE cellSpacing=0 cellPadding=0 width="99%" align=center border=0>
  <TBODY>
  <TR>
    <TD class=Left_03 vAlign=top width=8><IMG height=7 
      src="../images/Admin_2.gif" width=8></TD>
    <TD class=Left_01>&nbsp;</TD>
    <TD class=Left_04 vAlign=top width=8><IMG height=7 
      src="../images/Admin_5.gif" width=8></TD></TR>
  <TR>
    <TD class=Left_03>&nbsp;</TD>
    <TD>
      <TABLE class=SubMenu_Item cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD>
            <TABLE cellSpacing=0 cellPadding=0 border=0>
              <TBODY>
              <TR>
                <TD class=Current_Item id=TD1><A 
                  href="publish.aspx">出版社管理</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addpublish.aspx">添加出版社</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;<asp:Button ID="DeleteBtn" OnClientClick='return confirm("确定要删除吗?")' runat="server" Text="删除" OnClick="DeleteBtn_Click" /></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;
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
                                                    <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
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
			  </TBODY></TABLE></TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeletePublish"
            SelectMethod="GetPublishs" TypeName="Jiaen.BLL.Publish" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="publishID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

