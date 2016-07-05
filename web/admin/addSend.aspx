<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addSend.aspx.cs" Inherits="admin_addSend" %>

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
                  href="Send.aspx">配送方式管理</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addSend.aspx">添加配送方式</A></TD>
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
                  &nbsp;&nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" DataKeyNames="SendID" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" DefaultMode="Edit">
                      <Fields>
                          <asp:TemplateField HeaderText="配送方式" SortExpression="Name">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="配送价格" SortExpression="Price">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Price", "{0:N}") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$"></asp:RegularExpressionValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$"></asp:RegularExpressionValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="描述" SortExpression="Dec">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" TextMode=MultiLine runat="server" Text='<%# Bind("Dec") %>' Height="75px" Width="233px"></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  &nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="75px" Text='<%# Bind("Dec") %>'
                                      TextMode="MultiLine" Width="233px"></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("Dec") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowCancelButton="False" ShowEditButton="True" ShowInsertButton="True" />
                      </Fields>
                  </asp:DetailsView>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.SendInfo"
            InsertMethod="InsertSend" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSendByID"
            TypeName="Jiaen.BLL.Send" UpdateMethod="UpdateSend">
            <SelectParameters>
                <asp:QueryStringParameter Name="sendID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

