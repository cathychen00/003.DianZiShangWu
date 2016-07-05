<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addBookCategory.aspx.cs" Inherits="admin_addBookCategory" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图书分类操作</title>
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
                  href="BookCategory.aspx">图书分类管理</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addBookCategory.aspx">添加图书分类</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
                      DataSourceID="ObjectDataSource1" DataKeyNames="CategoryID" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated">
                      <Fields>
                          <asp:TemplateField HeaderText="所属分类" SortExpression="ParentID">
                              <EditItemTemplate>
                                  <Jiaen:AllCategoryDropDownList SelectedValue='<%# Bind("ParentID") %>' ID="AllCategoryDropDownList1" runat="server">
                                  </jiaen:AllCategoryDropDownList>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <Jiaen:AllCategoryDropDownList SelectedValue='<%# Bind("ParentID") %>' ID="AllCategoryDropDownList1" runat="server">
                                  </jiaen:AllCategoryDropDownList>
                                  
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("ParentID") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="分类名称" SortExpression="CategoryName">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CheckBoxField DataField="isMain" HeaderText="首页" />
                          <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ShowCancelButton="False" />
                      </Fields>
                  </asp:DetailsView>
                  &nbsp;
                  &nbsp; &nbsp;&nbsp;
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
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.CategoryInfo"
                        InsertMethod="InsertCategory" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategoryByID"
                        TypeName="Jiaen.BLL.Category" UpdateMethod="UpdateCategory">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="categoryID" QueryStringField="edit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
        &nbsp;
    </form>
</body>
</html>

