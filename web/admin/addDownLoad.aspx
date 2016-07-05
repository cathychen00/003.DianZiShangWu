<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addDownLoad.aspx.cs" Inherits="admin_addDownLoad" %>

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
    <TD class=Left_03 style="height: 486px">&nbsp;</TD>
    <TD style="height: 486px">
      <TABLE class=SubMenu_Item cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
          <TD>
            <TABLE cellSpacing=0 cellPadding=0 border=0>
              <TBODY>
              <TR>
                 <TD class=Default_Item id=TD1><A 
                  href="downList.aspx">资源列表</A></TD>
                   <TD class=Default_Item id=TD5><A 
                  href="contribution.aspx">投稿信息</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="addDownLoad.aspx">添加资源</A></TD>
                  <TD class=Default_Item id=TD3><A 
                  href="downClassList.aspx">下载类别</A></TD>
                    <TD class=Default_Item id=TD4><A 
                  href="addDownClass.aspx">添加类别</A></TD>
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
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" SkinID="orange" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" DataKeyNames="DownID" DefaultMode="Insert">
                      <Fields>
                          <asp:TemplateField HeaderText="标题" SortExpression="HelpTitle">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DownName") %>' Width="200px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DownName") %>' Width="200px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label3" runat="server" Text='<%# Bind("DownName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="类别" SortExpression="ClassName">
                              <EditItemTemplate>
                                  <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2" DataTextField="ClassName" DataValueField="ID" SelectedValue='<%# Bind("ID") %>'>
                                  </asp:DropDownList>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource2"
                                      DataTextField="ClassName" DataValueField="ID" SelectedValue='<%# Bind("ID") %>'>
                                  </asp:DropDownList>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("ClassName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="文件上传" SortExpression="Size">
                              <EditItemTemplate>
                                  <asp:TextBox Width="200px" ID="fileTxt1" runat="server" Text='<%# Bind("DownURL") %>'></asp:TextBox>
                             <asp:Label ID="flieSize" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                                  <br />
                                  <asp:FileUpload ID="FileUpload2" runat="server" />&nbsp;<asp:Button ID="Button1"
                                      runat="server" CausesValidation="False" OnClick="Button1_Click" Text="上传" />
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200px" ID="fileTxt" runat="server" Text='<%# Bind("DownURL") %>'></asp:TextBox><br />
                                  <asp:TextBox Enabled=false ID="flieSize" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                                  <br />
                                  <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Button ID="Button1"
                                      runat="server" CausesValidation="False" OnClick="Button1_Click" Text="上传" />
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label6" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="评价" SortExpression="Rate">
                              <EditItemTemplate>
                                  <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("Rate") %>'>
                                      <asp:ListItem Selected="True">1</asp:ListItem>
                                      <asp:ListItem>2</asp:ListItem>
                                      <asp:ListItem>3</asp:ListItem>
                                      <asp:ListItem>4</asp:ListItem>
                                      <asp:ListItem>5</asp:ListItem>
                                  </asp:DropDownList>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("Rate") %>'>
                                      <asp:ListItem>1</asp:ListItem>
                                      <asp:ListItem>2</asp:ListItem>
                                      <asp:ListItem>3</asp:ListItem>
                                      <asp:ListItem>4</asp:ListItem>
                                      <asp:ListItem>5</asp:ListItem>
                                  </asp:DropDownList>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label4" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="作者" SortExpression="Author">
                              <EditItemTemplate>
                                  <asp:TextBox Width="200px" ID="TextBox4" runat="server" Text='<%# Bind("Author") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ControlToValidate="TextBox4" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200px" ID="TextBox4" runat="server" Text='<%# Bind("Author") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="TextBox4" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label5" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="介绍" SortExpression="Dec">
                              <EditItemTemplate>
                                  <FTB:FreeTextBox ID="FreeTextBox2" runat="server" AllowHtmlMode="False" AssemblyResourceHandlerPath=""
                                      AutoConfigure="" AutoGenerateToolbarsFromString="True" AutoHideToolbar="True"
                                      AutoParseStyles="True" BackColor="158, 190, 245" BaseUrl="" BreakMode="Paragraph"
                                      ButtonDownImage="False" ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20"
                                      ButtonImagesLocation="InternalResource" ButtonOverImage="False" ButtonPath=""
                                      ButtonSet="Office2003" ButtonWidth="21" ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False"
                                      DesignModeBodyTagCssClass="" DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50"
                                      DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10" EditorBorderColorDark="Gray"
                                      EditorBorderColorLight="Gray" EnableHtmlMode="True" EnableSsl="False"
                                      EnableToolbars="True" Focus="False" FormatHtmlTagsToXhtml="True" GutterBackColor="129, 169, 226"
                                      GutterBorderColorDark="Gray" GutterBorderColorLight="White"
                                      Height="200px" HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" HtmlModeDefaultsToMonoSpaceFont="True"
                                      ImageGalleryPath="~/images/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}"
                                      InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                                      Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True"
                                      RemoveServerNameFromUrls="True" RenderMode="NotSet" ScriptMode="External" ShowTagPath="False"
                                      SslUrl="/." StartMode="DesignMode" StripAllScripting="False" SupportFolder="/aspnet_client/FreeTextBox/"
                                      TabIndex="-1" TabMode="InsertSpaces" Text='<%# Bind("Dec") %>' TextDirection="LeftToRight"
                                      ToolbarBackColor="Transparent" ToolbarBackgroundImage="True" ToolbarImagesLocation="InternalResource"
                                      ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                      ToolbarStyleConfiguration="Office2003" UpdateToolbar="True" UseToolbarBackGroundImage="True"
                                      Width="600px">
                                  </FTB:FreeTextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FreeTextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <FTB:FreeTextBox ID="FreeTextBox1" runat="server" AllowHtmlMode="False" AssemblyResourceHandlerPath=""
                                      AutoConfigure="" AutoGenerateToolbarsFromString="True" AutoHideToolbar="True"
                                      AutoParseStyles="True" BackColor="158, 190, 245" BaseUrl="" BreakMode="Paragraph"
                                      ButtonDownImage="False" ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20"
                                      ButtonImagesLocation="InternalResource" ButtonOverImage="False" ButtonPath=""
                                      ButtonSet="Office2003" ButtonWidth="21" ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False"
                                      DesignModeBodyTagCssClass="" DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50"
                                      DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10" EditorBorderColorDark="Gray"
                                      EditorBorderColorLight="Gray" EnableHtmlMode="True" EnableSsl="False"
                                      EnableToolbars="True" Focus="False" FormatHtmlTagsToXhtml="True" GutterBackColor="129, 169, 226"
                                      GutterBorderColorDark="Gray" GutterBorderColorLight="White"
                                      Height="200px" HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" HtmlModeDefaultsToMonoSpaceFont="True"
                                      ImageGalleryPath="~/images/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}"
                                      InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                                      Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True"
                                      RemoveServerNameFromUrls="True" RenderMode="NotSet" ScriptMode="External" ShowTagPath="False"
                                      SslUrl="/." StartMode="DesignMode" StripAllScripting="False" SupportFolder="/aspnet_client/FreeTextBox/"
                                      TabIndex="-1" TabMode="InsertSpaces" Text='<%# Bind("Dec") %>' TextDirection="LeftToRight"
                                      ToolbarBackColor="Transparent" ToolbarBackgroundImage="True" ToolbarImagesLocation="InternalResource"
                                      ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                      ToolbarStyleConfiguration="Office2003" UpdateToolbar="True" UseToolbarBackGroundImage="True"
                                      Width="600px">
                                  </FTB:FreeTextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FreeTextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("HelpContent") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowCancelButton="False" ShowEditButton="True" ShowInsertButton="True" />
                      </Fields>
                  </asp:DetailsView>
                  &nbsp; &nbsp; &nbsp;&nbsp;
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDownLoadByID" TypeName="Jiaen.BLL.DownLoad" DataObjectTypeName="Jiaen.Components.DownLoadInfo" InsertMethod="InsertDownLoad" UpdateMethod="UpdateDownLoad" OnInserting="ObjectDataSource1_Inserting">
            <SelectParameters>
                <asp:QueryStringParameter Name="downLoadID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDownClass" TypeName="Jiaen.BLL.DownClass"></asp:ObjectDataSource>
        &nbsp;
    </TD>
    <TD class=Left_04 style="height: 486px">&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;</TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
    </form>
</body>
</html>

