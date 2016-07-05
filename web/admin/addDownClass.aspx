<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addDownClass.aspx.cs" Inherits="admin_addDownClass" %>

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
                 <TD class=Default_Item id=TD1><A 
                  href="downList.aspx">资源列表</A></TD>
                  <TD class=Default_Item id=TD5><A 
                  href="contribution.aspx">投稿信息</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addDownLoad.aspx">添加资源</A></TD>
                  <TD class=Default_Item id=TD3><A 
                  href="downClassList.aspx">下载类别</A></TD>
                    <TD class=Current_Item id=TD4><A 
                  href="addDownClass.aspx">添加类别</A></TD>
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
                  &nbsp; &nbsp;&nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1"
                      DefaultMode="Insert" SkinID="orange" OnItemInserted="DetailsView1_ItemInserted">
                      <Fields>
                          <asp:TemplateField HeaderText="类别名称" SortExpression="ClassName">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ClassName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ClassName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <HeaderStyle Width="100px" />
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("ClassName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" />
                      </Fields>
                  </asp:DetailsView>
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDownClass" TypeName="Jiaen.BLL.DownClass" DataObjectTypeName="Jiaen.Components.DownClassInfo" InsertMethod="InsertDownClass">
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

