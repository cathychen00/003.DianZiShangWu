<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addPoll.aspx.cs" Inherits="admin_addPoll" %>
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
	<link href="../Styles/Admin_Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form runat=server>
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
                  href="polls.aspx">投票管理</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addPoll.aspx">添加投票</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;
          </TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" OnItemInserted="DetailsView1_ItemInserted" DataKeyNames="PollID" OnDataBound="DetailsView1_DataBound" OnItemUpdated="DetailsView1_ItemUpdated">
        <Fields>
            <asp:TemplateField HeaderText="投票内容" SortExpression="Title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="投票设置" SortExpression="InIndex">
                <EditItemTemplate>
                    <asp:CheckBox ID="MultipleChk" runat="server" Text="多选" Checked='<%# Bind("IsMultiple") %>' /><asp:CheckBox ID="InIndexChk" runat="server" Text="在首页显示" Checked='<%# Bind("InIndex") %>' /><asp:CheckBox ID="CanViewChk" runat="server" Text="公开投票结果" Checked='<%# Bind("CanView") %>' />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:CheckBox ID="MultipleChk" runat="server" Text="多选" Checked='<%# Bind("IsMultiple") %>' /><asp:CheckBox ID="InIndexChk" runat="server" Text="在首页显示" Checked='<%# Bind("InIndex") %>' /><asp:CheckBox ID="CanViewChk" runat="server" Text="公开投票结果" Checked='<%# Bind("CanView") %>' />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="MultipleChk" runat="server" Text="多选" Checked='<%# Bind("IsMultiple") %>' /><asp:CheckBox ID="InIndexChk" runat="server" Text="在首页显示" Checked='<%# Bind("InIndex") %>' /><asp:CheckBox ID="CanViewChk" runat="server" Text="公开投票结果" Checked='<%# Bind("CanView") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    投票项目（每行为一项，最大255字）
                </EditItemTemplate>
                <InsertItemTemplate>
                    投票项目（每行为一项，最大255字）
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("InIndex") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="投票项目" SortExpression="Items">
                <EditItemTemplate>
                    <asp:TextBox ID="VoteItemsTxt" runat="server" Columns="50" Rows="5" Text='<%# Bind("Items") %>'
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="VoteItemsTxt"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="VoteItemsTxt" runat="server" Columns="50" Rows="5" Text='<%# Bind("Items") %>'
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="VoteItemsTxt"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Items") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField InsertVisible="False" SortExpression="Title">
                <EditItemTemplate>
                    注意：修改投票内容将初始化投票数
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ShowCancelButton="False" />
            <asp:TemplateField InsertVisible="False" SortExpression="Title">
                <EditItemTemplate>
                    注意：修改投票内容将初始化投票数
                </EditItemTemplate>

                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
                  
                  <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource1">
                      <ItemTemplate>
                          <table cellpadding="0" cellspacing="0" width="50%">
                              <tr>
                                  <td class="tl">
                                  </td>
                                  <td class="tm">
                                      <span class="tt">查看调查结果</span>
                                  </td>
                                  <td class="tr">
                                  </td>
                              </tr>
                          </table>
                          <table cellpadding="0" cellspacing="0" width="50%">
                              <tr>
                                  <td class="ml">
                                  </td>
                                  <td class="mm">
                                      
                                      <%# writeChart(Eval("items").ToString(), Eval("Num").ToString())%>
                                  </td>
                                  <td class="mr">
                                  </td>
                              </tr>
                          </table>
                          <table cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                                  <td class="bl">
                                  </td>
                                  <td class="bm">
                                      &nbsp;</td>
                                  <td class="br">
                                  </td>
                              </tr>
                          </table>
                      </ItemTemplate>
                  </asp:Repeater>
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
												
											
										
						
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.PollInfo"
        InsertMethod="InsertPoll" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPollByID"
        TypeName="Jiaen.BLL.Poll" UpdateMethod="UpdatePoll" OnInserting="ObjectDataSource1_Inserting" OnUpdating="ObjectDataSource1_Updating">
        <SelectParameters>
            <asp:QueryStringParameter Name="pollID" QueryStringField="edit" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;
    </form>
</body>
</html>
