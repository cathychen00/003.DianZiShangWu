<%@ Page EnableViewState="false" StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="memberList.aspx.cs" Inherits="admin_memberList" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                <TD runat="server" class=Default_Item id=navi0><A 
                  href="memberList.aspx">用户管理</A></TD>
                   <TD runat="server" class=Default_Item id=navi1><A 
                  href="memberList.aspx?roleName=SendMember">配送员</A></TD>
                  <TD runat="server" class=Default_Item id=navi2><A 
                  href="memberList.aspx?roleName=MessageMember">信息录入员</A></TD>
                   <TD runat="server" class=Default_Item id=navi3><A 
                  href="memberList.aspx?roleName=Member">普通会员</A></TD>
                     <TD runat="server" class=Default_Item id=navi4><A 
                  href="memberList.aspx?roleName=Admin">超级管理员</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="../userReg.aspx" target="_blank">添加用户</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp; 按用户名搜索:<asp:TextBox
                                        ID="searchKey" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
          </TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;
                                    <asp:GridView ID="GridViewMemberUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    HorizontalAlign="Center" DataKeyNames="UserName" DataSourceID="ObjectDataSource1"
                    AllowSorting="True" SkinID="orange" OnRowDataBound="GridViewMemberUser_RowDataBound">
                    <PagerSettings FirstPageText="第一页" LastPageText="最后页" NextPageText="下一页"
                        PreviousPageText="上一页" />
                    <Columns>
                        <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="userName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" ReadOnly="True"
                            SortExpression="PasswordQuestion" Visible="False" />
                        <asp:BoundField DataField="CreationDate" HeaderText="创建时间" ReadOnly="True" SortExpression="CreationDate" />
                        <asp:BoundField DataField="LastLoginDate" HeaderText="最后登陆时间" SortExpression="LastLoginDate" />
                        <asp:CheckBoxField DataField="IsApproved" HeaderText="许可" SortExpression="IsApproved" />
                        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="锁定" ReadOnly="True" SortExpression="IsLockedOut" />
                        <asp:BoundField DataField="LastLockoutDate" Visible="False" HeaderText="LastLockoutDate"
                            ReadOnly="True" SortExpression="LastLockoutDate" />
                        <asp:CheckBoxField DataField="IsOnline" Visible="False" HeaderText="IsOnline" ReadOnly="True"
                            SortExpression="IsOnline" />
                        <asp:BoundField DataField="LastActivityDate" HeaderText="最后活动时间" SortExpression="LastActivityDate"
                            Visible="False" />
                        <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="最后改变密码时间" Visible="False"
                            ReadOnly="True" SortExpression="LastPasswordChangedDate" />
                        <asp:BoundField DataField="ProviderName" HeaderText="ProviderName" ReadOnly="True"
                            Visible="False" SortExpression="ProviderName" />
                        <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:HyperLink ID="hyl_Roles" runat="server" NavigateUrl='<%# @"UserRoles.aspx?id=" + Eval("UserName")  %>'>角色</asp:HyperLink>
                                <!--<asp:HyperLink ID="hyl_Finance" runat="server" NavigateUrl='<%# @"~/ControlPanel/Finance/Default.aspx?id=" + Eval("UserName")  %>'>财务</asp:HyperLink>-->
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <br />
                        <font color="red" size="2">没有此用户！！</font>
                        <br />
                    </EmptyDataTemplate>
                </asp:GridView>
                                    &nbsp;&nbsp;&nbsp;
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllUsers" TypeName="System.Web.Security.Membership" DeleteMethod="DeleteUser">
        <DeleteParameters>
            <asp:Parameter Name="username" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource> 
             
</body>
</html>
