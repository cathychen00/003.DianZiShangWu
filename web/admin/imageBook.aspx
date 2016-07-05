<%@ Page EnableViewState="false" StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="imageBook.aspx.cs" Inherits="admin_imageBook" %>

<html xmlns="http://www.w3.org/1999/xhtml">
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

    <script language="javascript" type="text/javascript" src="../JScript/common.js"></script>

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
                  href="imageBook.aspx">广告图片列表</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addImageBook.aspx">添加广告图片</A></TD>
                  
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              <asp:Button ID="Btn1"  CommandName="Main" runat="server"
                  Text="更新" OnCommand="Button1_Command" />
              <asp:Button ID="Button1"  CommandName="linkOrder" runat="server" 
                  Text="排序" OnCommand="Button1_Command" />
              <asp:Button ID="Button2" runat="server"  CommandName="Delete"  OnClientClick='return confirm("确定要删除吗?")'
                  Text="删除" OnCommand="Button1_Command" /></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp; &nbsp;&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                        DataKeyNames="ImageID" AllowPaging="True" SkinID="orange">
                                        <Columns>
                                            <asp:TemplateField HeaderText="图片">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ImageURL") %>' ToolTip='<%# Eval("ImageURL") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" AlternateText='<%# Eval("ImageURL") %>' ImageUrl='<%# Eval("ImageURL") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="链接">
                                                <ItemStyle Width="50px" />
                                                <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                <a href='<%# Eval("LinkURL") %>'><%# Eval("LinkURL") %></a>
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="首页" SortExpression="IsMain">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IsMain") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <%# (bool)Eval("IsMain") ? "<span style='color: Green'>YES</span>" : "<span tyle='color: Red'>NO</span>" %>
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="排序" SortExpression="ImageOrder">
                                                <ItemTemplate>
                                                    <asp:TextBox Width="20" ID="ImageOrder" runat="server" Text='<%# Bind("ImageOrder") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField  HeaderText="位置" SortExpression="ImageStation">
                                                <ItemTemplate>
                                                    <asp:DropDownList SelectedValue='<%# Bind("ImageStation") %>' ID="stationList" runat="server">
                                                    <asp:ListItem Value="0">顶部</asp:ListItem>
                                                    <asp:ListItem Value="1">底部</asp:ListItem>
                                                </asp:DropDownList>
                                                    
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                             <asp:HyperLinkField DataNavigateUrlFields="imageID" DataNavigateUrlFormatString="addImageBook.aspx?edit={0}"
                                                Text="修改" />
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Text="删除"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:GridView>
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE>
    </TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            SelectMethod="GetImageBook" TypeName="Jiaen.BLL.ImageBook" DeleteMethod="DeleteImageBookByID">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="type" Type="Object" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="imageID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

