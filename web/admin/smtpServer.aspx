<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smtpServer.aspx.cs" Inherits="admin_smtpServer" %>

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
                  href="smtpServer.aspx">邮件配置</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="EmailList.aspx">邮件列表</A></TD>
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
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <table cellspacing="0" cellpadding="4" rules="all" border="1" id="Table1" style="color:#333333;font-size:8pt;width:50%;border-collapse:collapse;">
		<tr class="Gridviewcss" style="background-color:#F9F8DD;border-color:#FF9000;border-width:1px;border-style:Solid;">
			<td width=80>Smtp服务器</td><td>
                &nbsp;<asp:TextBox ID="host" runat="server" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="host"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
		</tr><tr class="Gridviewcss" style="background-color:#F9F8DD;border-color:#FF9000;border-width:1px;border-style:Solid;">
			<td>Smtp账号</td><td>
                &nbsp;<asp:TextBox ID="userName" runat="server" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="userName"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
		</tr><tr class="Gridviewcss" style="background-color:#F9F8DD;border-color:#FF9000;border-width:1px;border-style:Solid;">
			<td>Smtp密码</td><td>
                &nbsp;<asp:TextBox ID="password" runat="server" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
		</tr><tr class="Gridviewcss" style="background-color:#F9F8DD;border-color:#FF9000;border-width:1px;border-style:Solid;">
			<td>邮件发送者</td><td>
                &nbsp;<asp:TextBox ID="from" runat="server" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="from"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="from"
                    ErrorMessage="格式不对" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
		</tr>
                      <tr class="Gridviewcss" style="border-right: #ff9000 1px solid; border-top: #ff9000 1px solid;
                          border-left: #ff9000 1px solid; border-bottom: #ff9000 1px solid; background-color: #f9f8dd">
                          <td>
                          </td>
                          <td>
                              <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">更新</asp:LinkButton></td>
                      </tr>
	</table>
                  &nbsp; &nbsp;
                  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
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

