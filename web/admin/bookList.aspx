<%@ Page EnableViewState="true" Language="C#" AutoEventWireup="true" CodeFile="bookList.aspx.cs" Inherits="admin_bookList" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
                  href="bookList.aspx">图书列表</A></TD>
                <TD class=Default_Item id=TD2><A 
                  href="addBook.aspx">添加图书</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD  style="FONT-SIZE: 12px">
              &nbsp;<asp:Button OnClientClick='return confirm("确定要删除吗?")' ID="Button3" runat="server" Text="删除图书" OnClick="Button3_Click" />
                                    <asp:Button ID="Button2" runat="server" Text="修改价格" OnClick="Button2_Click" />搜索:<asp:TextBox
                                        ID="searchKey" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" />
                                        &nbsp;&nbsp;&nbsp;
              <Jiaen:AllCategoryDropDownList AutoPostBack=true ID="AllCategoryDropDownList1" OnTextChanged="DropDownList1_TextChanged"
                                            runat="server">
                                        </Jiaen:AllCategoryDropDownList></TD>
                                <td class="mr">
                                </td>
                            </TR>
                            <tr>
                                <td class="bl">
                                </td>
                                <td class="bm">
                                    &nbsp;</td>
                                <td class="br">
                                </td>
                            </tr>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp;&nbsp;
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        DataKeyNames="bookID" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="图书名称">
                                                <ItemTemplate>
                                                  <a runat="server" target="_blank" href='<%# "~/bookinfo.aspx?bookID="+Eval("bookID") %>' ><%# Eval("bookName") %></a> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="价格">
                                                <ItemTemplate>
                                                    <asp:TextBox Width="60" ID="Price" runat="server" Text='<%# Bind("Price","{0:n}") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="会员价格">
                                                <ItemTemplate>
                                                    <asp:TextBox Width="60" ID="MemberPrice" runat="server" Text='<%# Bind("MemberPrice","{0:n}") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="库存量">
                                                <ItemTemplate>
                                                   <%# getStock((int)Eval("stock"))%>
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
                                            <asp:HyperLinkField Text="修改" DataNavigateUrlFields="bookID" DataNavigateUrlFormatString="addBook.aspx?edit={0}" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp; &nbsp;
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteHelp"
            SelectMethod="GetHelp" TypeName="Jiaen.BLL.Help" >
            <DeleteParameters>
                <asp:Parameter Name="HelpID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
    </form>
</body>
</html>

