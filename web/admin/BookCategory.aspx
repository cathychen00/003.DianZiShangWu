<%@ Page EnableViewState="true" Language="C#" AutoEventWireup="true" CodeFile="BookCategory.aspx.cs" Inherits="admin_BookCategory" %>

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
                  href="BookCategory.aspx">图书分类管理</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addBookCategory.aspx">添加图书分类</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="CategoryID" Visible="False" />
                <asp:TemplateField HeaderText="编号">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CategoryName" HeaderText="分类名称" SortExpression="CategoryName">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="isMain" HeaderText="首页" />
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "addBookCategory.aspx?edit="+Eval("CategoryID")%>'>修改</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                  &nbsp; &nbsp;&nbsp;&nbsp;
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

    </form>
</body>
</html>

