<%@ Page EnableViewState="true" Language="C#" AutoEventWireup="true" CodeFile="UserRoles.aspx.cs" Inherits="admin_UserRoles" %>

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
                <TD class=Current_Item id=TD1 style="height: 18px"><A 
                  href="#">角色管理</A></TD>
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
                 <h3 style="text-align: center">
            用户：[<asp:Label ID="lbl_UserName" runat="server"></asp:Label>]的角色管理
        </h3>
        <br />
        
        <table align="center">
                    <tr>
                        <td style="width: 100px">
                            已有角色</td>
                        <td style="width: 25px">
                        </td>
                        <td style="width: 100px">
                            未选角色</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:ListBox ID="lst_UserRole" runat="server" Height="150px" Width="150px" SelectionMode="Multiple">
                            </asp:ListBox></td>
                        <td style="width: 25px">
                            <asp:Button ID="btn_UnSelectAll" runat="server" Text=">>" Width="40" OnClick="btn_UnSelectAll_Click" />
                            <asp:Button ID="btn_UnSelect" runat="server" Text=">" Width="40" OnClick="btn_UnSelect_Click" />
                            <asp:Button ID="btn_Select" runat="server" Text="<" Width="40" OnClick="btn_Select_Click" />
                            <asp:Button ID="btn_SelectAll" runat="server" Text="<<" Width="40" OnClick="btn_SelectAll_Click" />
                        </td>
                        <td style="width: 100px">
                            <asp:ListBox ID="lst_RestRole" runat="server" Height="150px" Width="150px" SelectionMode="Multiple">
                            </asp:ListBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input id="btn_ShowSuccess" type="button" runat="server" value="保存" onserverclick="btn_ShowSuccess_ServerClick" />&nbsp;
                            <input id="btn_Refresh" type="button" value="重置" onclick="location.href=location.href" /> &nbsp;&nbsp;
                            <asp:Button ID="btn_Return" runat="server" Text="返回" OnClick="btn_Return_Click" />
                        </td>
                    </tr>
                </table>
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

