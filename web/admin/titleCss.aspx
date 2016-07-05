<%@ Page StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="titleCss.aspx.cs" Inherits="admin_titleCss" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>样式管理</title>
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
                  href="titleCss.aspx">标题样式管理</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addTitleCss.aspx">添加标题样式</A></TD>
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
                  &nbsp;
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                        DataKeyNames="TitleCssID" SkinID="orange">
                                        <Columns>
                                            <asp:BoundField DataField="TitleCssName" HeaderText="样式名称" SortExpression="TitleCssName" />
                                            <asp:TemplateField HeaderText="样式效果" SortExpression="TitleCssDec">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TitleCssDec") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Style='<%# Eval("titlecssdec") %>' Text="效果"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AddDate" HeaderText="加入时间" SortExpression="AddDate" />
                                            <asp:HyperLinkField DataNavigateUrlFields="titleCssID" DataNavigateUrlFormatString="addTitleCss.aspx?edit={0}"
                                                Text="编辑" HeaderText="编辑" />
                                            <asp:TemplateField HeaderText="全选">
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteTitleCss"
            SelectMethod="GetTitleCss" TypeName="Jiaen.BLL.TitleCss" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="titleCssID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

