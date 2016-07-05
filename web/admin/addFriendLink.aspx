<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addFriendLink.aspx.cs" Inherits="admin_addFriendLink"
    Title="Untitled Page" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>荒野新闻系统</title>
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
    <form id="LinkAddForm" runat="server">
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
                <TD class=Default_Item id=TD1><A 
                  href="friendLink.aspx">友情链接</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addFriendLink.aspx">添加友情链接</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;<table width="80%">
                                        <tr>
                                            <td>
                                                网站名称：</td>
                                            <td style="color: #666666">
                                                <asp:TextBox ID="LinkNameTxt" runat="server" Columns="30"
                                                    MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ControlToValidate="LinkNameTxt" ID="LinkNameValR"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                <asp:CheckBox ID="LinkIndexChk" runat="server" Text="作为首页链接" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                网站地址：</td>
                                            <td>
                                                <asp:TextBox ID="LinkUrlTxt" runat="server" Columns="40"
                                                    MaxLength="255">http://</asp:TextBox>
                                                <asp:RegularExpressionValidator ControlToValidate="LinkUrlTxt" ID="LinkUrlValRE"
                                                    runat="server" ErrorMessage="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                网站图标：</td>
                                            <td>
                                                <asp:TextBox ID="LinkLogoTxt" runat="server" Columns="50"
                                                    MaxLength="255"></asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                        <tr style="height: 30px">
                                            <td align="center" colspan="2" style="height: 30px">
                                                <asp:Button ID="LinkAddBtn" runat="server" Text="编辑" OnClick="LinkAddBtn_Click" /></td>
                                        </tr>
                                    </table>
                                </TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
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
        &nbsp;
    </form>
</body>
</html>

