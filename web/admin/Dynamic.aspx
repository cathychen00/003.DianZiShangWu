<%@ Page StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="Dynamic.aspx.cs" Inherits="admin_Dynamic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻动态管理</title>
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
    <form id="form1" runat="server">
        
        
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
                  href="Dynamic.aspx">新闻动态</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addDynamic.aspx">添加新闻动态</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;<asp:Button ID="DeleteBtn" runat="server" Text="删除" OnClick="DeleteBtn_Click" OnClientClick='return confirm("确定要删除吗?")' /></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                        DataKeyNames="DynamicID" AllowPaging="True" SkinID="orange">
                                        <Columns>
                                            <asp:BoundField DataField="DynamicTitle" HeaderText="新闻标题" />
                                            <asp:BoundField DataField="AddDate" DataFormatString="{0:yyyy年MM月dd日}" HeaderText="添加日期"
                                                SortExpression="AddDate" />
                                            <asp:HyperLinkField Text="修改" DataNavigateUrlFields="Dynamicid" DataNavigateUrlFormatString="addDynamic.aspx?edit={0}" />
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
                                    &nbsp;
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSiteDynamic"
            TypeName="Jiaen.BLL.SiteDynamic" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter DefaultValue="All" Name="type" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

