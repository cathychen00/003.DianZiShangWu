﻿<%@ Page StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="addBookCatena.aspx.cs" Inherits="admin_addBookCatena"
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
                  href="BookCatena.aspx">图书系列列表</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addBookCatena.aspx">添加图书系列</A></TD>
                  
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
                  &nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" SkinID="orange" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" DataKeyNames="CatenaID">
                      <Fields>
                          <asp:TemplateField HeaderText="系列名称" SortExpression="CatenaName">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CatenaName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CatenaName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("CatenaName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="系列说明" SortExpression="CatenaDec">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Height="81px" Text='<%# Bind("CatenaDec") %>'
                                      TextMode="MultiLine" Width="259px"></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Height="91px" Text='<%# Bind("CatenaDec") %>'
                                      TextMode="MultiLine" Width="281px"></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("CatenaDec") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowCancelButton="False" ShowEditButton="True" ShowInsertButton="True" />
                      </Fields>
                  </asp:DetailsView>
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE>
        &nbsp;
    </TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.BookCatenaInfo"
            InsertMethod="InsertCatena" SelectMethod="GetCatenaByID" TypeName="Jiaen.BLL.BookCatena"
            UpdateMethod="UpdateCatena" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter Name="catenaID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;
    </form>
</body>
</html>

