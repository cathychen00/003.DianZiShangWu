<%@ Page StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="addDynamic.aspx.cs" Inherits="admin_addDynamic" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻动态操作</title>
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
                  href="Dynamic.aspx">新闻动态</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addDynamic.aspx">添加新闻动态</A></TD>
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
                  &nbsp; &nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" SkinID="orange" DataKeyNames="DynamicID" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" DefaultMode="Edit">
                      <Fields>
                          <asp:TemplateField HeaderText="新闻标题" SortExpression="DynamicTitle">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DynamicTitle") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                                  <jiaen:CssDropDownList SelectedValue='<%# Bind("DynamicCss") %>' id="CssDropDownList1" runat="server">
                                  </jiaen:CssDropDownList>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DynamicTitle") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                                  <jiaen:CssDropDownList SelectedValue='<%# Bind("DynamicCss") %>' id="CssDropDownList1" runat="server">
                                  </jiaen:CssDropDownList>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  &nbsp;
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="新闻内容" SortExpression="DynamicContent">
                              <EditItemTemplate>
                                  &nbsp;<CE:Editor ID="Editor1" runat="server" AutoConfigure="Simple" AutoParseClasses="True"
                                      CodeViewTemplateItemList="Save,Print,Cut,Copy,Paste,Find,ToFullPage,FromFullPage,SelectAll,SelectNone"
                                      EditorOnPaste="ConfirmWord" MaxHTMLLength="0" MaxTextLength="0" Text='<%# Bind("DynamicContent") %>'
                                      Width="500px">
                                      <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                          CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                  </CE:Editor>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  &nbsp;<CE:Editor ID="Editor1" runat="server" AutoConfigure="Simple" AutoParseClasses="True"
                                      CodeViewTemplateItemList="Save,Print,Cut,Copy,Paste,Find,ToFullPage,FromFullPage,SelectAll,SelectNone"
                                      EditorOnPaste="ConfirmWord" MaxHTMLLength="0" MaxTextLength="0" Text='<%# Bind("DynamicContent") %>'
                                      Width="500px">
                                      <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                          CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                  </CE:Editor>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("DynamicContent") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                      </Fields>
                  </asp:DetailsView>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSiteDynamicByID" TypeName="Jiaen.BLL.SiteDynamic" DataObjectTypeName="Jiaen.Components.SiteDynamicInfo"
            InsertMethod="InsertSiteDynamic" UpdateMethod="UpdateSiteDynamic">
            <SelectParameters>
                <asp:QueryStringParameter Name="siteDynamicID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp; &nbsp;
       
    </form>
</body>
</html>

