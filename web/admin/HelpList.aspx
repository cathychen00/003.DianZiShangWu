<%@ Page EnableViewState="false" StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="HelpList.aspx.cs" Inherits="admin_HelpList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
                  <LINK href="../images/cssothers.css" 
type=text/css rel=stylesheet />
<style type="text/css">
<!--
body {
	background-color: #ffffff;
}
-->
</style>
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
                  href="HelpList.aspx">帮助列表</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addHelp.aspx">添加帮助</A></TD>
                  <TD class=Default_Item id=TD3><A 
                  href="helpClassList.aspx">帮助类别</A></TD>
                    <TD class=Default_Item id=TD4><A 
                  href="addHelpClass.aspx">帮助类别</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;</TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;
                  <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                      DataKeyNames="HelpID" DataSourceID="ObjectDataSource1" SkinID="orange">
                      <Columns>
                          <asp:BoundField DataField="HelpTitle" HeaderText="标题" SortExpression="ClassName" />
                          <asp:BoundField DataField="AddDate" HeaderText="添加时间" ReadOnly="True" SortExpression="AddDate" />
                          <asp:TemplateField HeaderText="管理" ShowHeader="False">
                              <ItemTemplate>
                                      
                              <a href='addHelp.aspx?edit=<%# Eval("helpID") %>'>修改</a>
                                      
                                  <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                      Text="删除"></asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                  </asp:GridView>
                  &nbsp;
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteHelp"
            SelectMethod="GetHelp" TypeName="Jiaen.BLL.Help" >
            <DeleteParameters>
                <asp:Parameter Name="HelpID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
    </form>
</body>
</html>

