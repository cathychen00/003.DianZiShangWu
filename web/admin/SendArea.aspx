<%@ Page EnableViewState="true" StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="SendArea.aspx.cs" Inherits="admin_SendArea" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>配送区域</title>
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
                  href="SendArea.aspx">配送区域</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addSendArea.aspx">添加配送区域</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px; height: 14px;">
              &nbsp; 快速导航:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                  DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="AreaID"
                  OnTextChanged="DropDownList1_TextChanged">
              </asp:DropDownList>
              <asp:Label ID="Label1" runat="server"></asp:Label></TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="orange" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="areaID">
                                        <Columns>
                                            <asp:BoundField DataField="areaID" Visible="False" />
                                            <asp:TemplateField HeaderText="编号">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="配送区域">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                <a name='<%# Eval("AreaID") %>'></a>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Code" HeaderText="代码" />
                                            <asp:BoundField DataField="Dec" HeaderText="描述" />
                                            <asp:CheckBoxField DataField="isSended" HeaderText="送货上门" />
                                         <asp:HyperLinkField Text="修改" DataNavigateUrlFields="AreaID" DataNavigateUrlFormatString="addSendArea.aspx?edit={0}" />
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSendArea" TypeName="Jiaen.BLL.SendArea" DeleteMethod="DeleteSendArea">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="type" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="areaID" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="AreaID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

