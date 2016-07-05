<%@ Page StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="addImageBook.aspx.cs" Inherits="admin_addImageBook" %>
<%@ Register Assembly="Jiaen.Controls" Namespace="TW.Web.UI" TagPrefix="cc1" %>


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
		<script type="text/javascript">   
  
 
 function Button1_onclick() {
 var a= window.showModalDialog("Dialog.aspx?rif=Uploads/Images&cif=Uploads/Images");   
 if(a.length>0)
 {
 document.form1.DetailsView1$imageBox.value=a;
 }
}


		</script>
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
                  href="imageBook.aspx">广告图片列表</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addImageBook.aspx">添加广告图片</A></TD>
                  
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
                  &nbsp; &nbsp;&nbsp; &nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1"
                      SkinID="orange" OnItemInserted="DetailsView1_ItemInserted" DefaultMode="Edit" DataKeyNames="ImageID" OnItemUpdated="DetailsView1_ItemUpdated" EnableViewState="False">
                      <Fields>
                          <asp:TemplateField HeaderText="图片上传" SortExpression="ImageURL">
                              <EditItemTemplate>
                                  <asp:TextBox ID="imageBox" runat="server" Text='<%# Bind("ImageURL") %>' Width="251px"></asp:TextBox>
                                  <asp:Button ID="Button1" runat="server" Text="上传" OnClientClick="return Button1_onclick()" />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="imageBox"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="251px" ID="imageBox" runat="server" Text='<%# Bind("ImageURL") %>'></asp:TextBox>
                                  <asp:Button ID="Button1" runat="server" Text="上传" OnClientClick="return Button1_onclick()" />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="imageBox"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="图片链接地址" SortExpression="LinkURL">
                              <EditItemTemplate>
                                  <asp:TextBox Width="251px" ID="TextBox2" runat="server" Text='<%# Bind("LinkURL") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="251px" ID="TextBox2" runat="server" Text='<%# Bind("LinkURL") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="显示位置" SortExpression="ImageStation">
                              <EditItemTemplate>
                                  <asp:DropDownList ID="stationList" runat="server" SelectedValue='<%# Bind("ImageStation") %>'>
                                      <asp:ListItem Value="0">顶部</asp:ListItem>
                                      <asp:ListItem Value="1">底部</asp:ListItem>
                                  </asp:DropDownList>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:DropDownList ID="stationList" runat="server" SelectedValue='<%# Bind("ImageStation") %>'>
                                      <asp:ListItem Value="0">顶部</asp:ListItem>
                                      <asp:ListItem Value="1">底部</asp:ListItem>
                                  </asp:DropDownList>
                              </InsertItemTemplate>
                             
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="显示在首页" SortExpression="IsMain">
                              <EditItemTemplate>
                                  <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsMain") %>' />
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsMain") %>' />
                              </InsertItemTemplate>
                              
                          </asp:TemplateField>
                          <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ShowCancelButton="False" />
                      </Fields>
                  </asp:DetailsView>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.ImageBookInfo"
            InsertMethod="InsertImageBook" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetImageBookByID" TypeName="Jiaen.BLL.ImageBook" UpdateMethod="UpdateImageBook">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="imageID" QueryStringField="edit"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

