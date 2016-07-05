<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addSendArea.aspx.cs" Inherits="admin_addSendArea" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>

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
                <TD class=Current_Item id=TD1><A 
                  href="friendLink.aspx">配送区域</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addFriendLink.aspx">添加配送区域</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px; height: 14px;">
              &nbsp; </TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;&nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1"
                      Height="50px" DataKeyNames="AreaID" OnItemInserted="DetailsView1_ItemInserted" DefaultMode="Edit" OnItemUpdated="DetailsView1_ItemUpdated">
                      <Fields>
                          <asp:TemplateField HeaderText="所属分类" SortExpression="ParentID">
                              <EditItemTemplate>
                                  <jiaen:SendAreaDropDownList id="SendAreaDropDownList1" SelectedValue='<%# Bind("ParentID") %>' runat="server">
                                  </jiaen:SendAreaDropDownList>
                                 
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                 <jiaen:SendAreaDropDownList id="SendAreaDropDownList1" SelectedValue='<%# Bind("ParentID") %>' runat="server">
                                  </jiaen:SendAreaDropDownList>
                              </InsertItemTemplate>
                              
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="分类名称" SortExpression="Name">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="Required1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="代号" SortExpression="Code">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="Required2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="Dec" HeaderText="描述" SortExpression="Dec" />
                          <asp:CheckBoxField DataField="isSended" HeaderText="送货上门" SortExpression="isSended" />
                          <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                      </Fields>
                  </asp:DetailsView>
                  &nbsp;&nbsp;
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.SendAreaInfo"
            InsertMethod="InsertSendArea" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSendAreaByID"
            TypeName="Jiaen.BLL.SendArea" UpdateMethod="UpdateSendArea">
            <SelectParameters>
                <asp:QueryStringParameter Name="sendID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

