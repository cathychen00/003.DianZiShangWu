<%@ Page EnableViewState="false" Language="C#" StylesheetTheme="default" AutoEventWireup="true" CodeFile="friendLink.aspx.cs"
    Inherits="admin_friendLink" %>
<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接管理</title>
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
                  href="friendLink.aspx">友情链接</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addFriendLink.aspx">添加友情链接</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;链接状态：<jiaen:LinkDropDownList id="LinkDropDownList1" runat="server" AutoPostBack="True">
                  <asp:ListItem Value="0">显示全部链接</asp:ListItem>
              </jiaen:LinkDropDownList>&nbsp;
            显示行数：<SELECT language=javascript id=SELECT1 
            onchange="__doPostBack('countList','')" name=countList> <OPTION 
              value=10>10</OPTION> <OPTION value=15 selected>15</OPTION> <OPTION 
              value=20>20</OPTION> <OPTION value=25>25</OPTION> <OPTION 
              value=30>30</OPTION> <OPTION value=35>35</OPTION> <OPTION 
              value=40>40</OPTION> <OPTION value=45>45</OPTION> <OPTION 
              value=50>50</OPTION></SELECT>
              <asp:Button ID="Button2" CommandName="linkOrder" runat="server" Text="更新排序" OnCommand="Button1_Command" />
              <asp:Button ID="Button1" CommandName="Main" runat="server" Text="显示首页" OnCommand="Button1_Command" />
              <asp:Button ID="LinkChkBtn" CommandName="Arrow" runat="server" Text="通过审核" OnCommand="Button1_Command" />
              <asp:Button OnClientClick='return confirm("确定要删除吗?")' ID="DeleteBtn" CommandName="Delete" runat="server" Text="删除" OnCommand="Button1_Command" /></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                        AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="LinkID" SkinID="orange" EnableViewState="False">
        <Columns>
            <asp:TemplateField HeaderText="网站名" SortExpression="LinkURL">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LinkURL") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a href='<%# Eval("LinkURL") %>'>
                        <%# Eval("LinkName") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ImageField HeaderText="网站Logo" NullDisplayText="文字链接" DataImageUrlField="LinkLogo">
            </asp:ImageField>
            <asp:TemplateField HeaderText="显示首页" SortExpression="IsMain">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("IsMain") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <%# (bool)Eval("IsMain") ? "<span style='color: Green'>YES</span>" : "<span tyle='color: Red'>NO</span>" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核" SortExpression="IsArrow">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsArrow") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <%# (bool)Eval("IsArrow") ? "<span style='color: Green'>YES</span>" : "<span tyle='color: Red'>NO</span>" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排序" SortExpression="LinkOrder">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("LinkOrder") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="linkOrder" runat="server" Text='<%# Bind("LinkOrder") %>' Width="20"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField Text="修改" DataNavigateUrlFields="linkid" DataNavigateUrlFormatString="addFriendLink.aspx?edit={0}" HeaderText="修改" />
            <asp:TemplateField>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteLink"
        SelectMethod="GetLinks" TypeName="Jiaen.BLL.FriendLink" OldValuesParameterFormatString="original_{0}">
        <DeleteParameters>
            <asp:Parameter Name="linkID" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="LinkDropDownList1" Name="linkType" PropertyName="SelectedValue"
                Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</body>
</html>

