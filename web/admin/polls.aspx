<%@ Page Language="C#" AutoEventWireup="true" CodeFile="polls.aspx.cs" Inherits="admin_polls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
                  href="polls.aspx">投票管理</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addPoll.aspx">添加投票</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;
          </TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                        AllowPaging="True" SkinID="orange" DataKeyNames="PollID">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="投票内容" SortExpression="Title" />
            <asp:BoundField DataField="Items" HeaderText="选项" SortExpression="Items" />
            <asp:BoundField DataField="Num" HeaderText="投票数" SortExpression="Num" />
            <asp:CheckBoxField DataField="InIndex" HeaderText="首页" SortExpression="InIndex" />
            <asp:CheckBoxField DataField="CanView" HeaderText="公开" SortExpression="CanView" />
            <asp:HyperLinkField DataNavigateUrlFields="pollID" DataNavigateUrlFormatString="addPoll.aspx?edit={0}"
                HeaderText="修改" Text="修改" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="删除"></asp:LinkButton>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeletePoll"
 SelectMethod="GetPoll" TypeName="Jiaen.BLL.Poll" >
            <DeleteParameters>
                <asp:Parameter Name="pollID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

