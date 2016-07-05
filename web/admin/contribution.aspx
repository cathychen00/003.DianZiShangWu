<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contribution.aspx.cs" Inherits="admin_contribution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
                  <TD class=Current_Item id=TD5><A 
                  href="contribution.aspx">投稿信息</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addDownLoad.aspx">添加资源</A></TD>
                  <TD class=Default_Item id=TD3><A 
                  href="downClassList.aspx">下载类别</A></TD>
                    <TD class=Default_Item id=TD4><A 
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
                  &nbsp;
                  <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                      DataKeyNames="DownID" DataSourceID="ObjectDataSource1" SkinID="orange">
                      <Columns>
                          <asp:BoundField DataField="DownName" HeaderText="名称" SortExpression="DownName" />
                          <asp:BoundField DataField="Size" HeaderText="大小" SortExpression="Size" />
                          <asp:BoundField DataField="ClassName" HeaderText="类别" SortExpression="ClassName" />
                          <asp:TemplateField HeaderText="下载地址" SortExpression="DownURL">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DownURL") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                               <a runat=server href='<%# Eval("DownURL") %>'>下载地址</a>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="AddDate" HeaderText="添加时间" ReadOnly="True" SortExpression="AddDate" />
                          <asp:TemplateField HeaderText="管理" ShowHeader="False">
                              
                              <ItemTemplate>
                                  <asp:HyperLink NavigateUrl='<%# "addDownLoad.aspx?id="+Eval("downID")%>' ID="HyperLink1" runat="server">查看</asp:HyperLink>

                                  <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
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
			  </TBODY></TABLE></TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.DownLoadInfo"
            DeleteMethod="DeleteDownLoad" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCBDownLoad"
            TypeName="Jiaen.BLL.DownLoad"></asp:ObjectDataSource>
        &nbsp;
    </form>
</body>
</html>

