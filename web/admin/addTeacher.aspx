<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addTeacher.aspx.cs" Inherits="admin_addTeacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../images/cssothers.css" type="text/css" rel="stylesheet" />
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
        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0">
            <tbody>
                <tr>
                    <td class="Left_03" valign="top" width="8">
                        <img height="7" src="../images/Admin_2.gif" width="8"></td>
                    <td class="Left_01">
                        &nbsp;</td>
                    <td class="Left_04" valign="top" width="8">
                        <img height="7" src="../images/Admin_5.gif" width="8"></td>
                </tr>
                <tr>
                    <td class="Left_03">
                        &nbsp;</td>
                    <td>
                        <table class="SubMenu_Item" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="Default_Item" id="TD1">
                                                        <a href="Teacher.aspx">教师列表</a></td>
                                                    <td class="Current_Item" id="TD2">
                                                        <a href="addTeacher.aspx">添加教师</a></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="C_order_state" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="font-size: 12px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <td>
                                                &nbsp; &nbsp;&nbsp;
                                                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1"
                                                    DefaultMode="Insert" SkinID="orange" OnItemInserted="DetailsView1_ItemInserted"
                                                    OnItemUpdated="DetailsView1_ItemUpdated" DataKeyNames="TeacherID">
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="名字" SortExpression="Name">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="TextBox1" ID="RequiredFieldValidator1"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="TextBox1" ID="RequiredFieldValidator1"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图片上传" SortExpression="Image">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="imageBox" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                                                                <asp:Button ID="Button1" runat="server" OnClientClick="return Button1_onclick()"
                                                                    Text="上传" />
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="imageBox" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                                                                <asp:Button ID="Button1" runat="server" OnClientClick="return Button1_onclick()"
                                                                    Text="上传" />
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="是否推荐" SortExpression="IsMain">
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsMain") %>' Text=" " />
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsMain") %>' Text=" " />
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("IsMain") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="自我介绍" SortExpression="SmallDec">
                                                            <EditItemTemplate>
                                                                <FTB:FreeTextBox ID="FreeTextBox1" Text='<%# Bind("smallDec") %>' runat="server"
                                                                    Height="200px" Width="500px">
                                                                </FTB:FreeTextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="FreeTextBox1" ID="RequiredFieldValidator2"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <FTB:FreeTextBox ID="FreeTextBox1" Text='<%# Bind("smallDec") %>' runat="server"
                                                                    Height="200px" Width="500px">
                                                                </FTB:FreeTextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="FreeTextBox1" ID="RequiredFieldValidator2"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("SmallDec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="简介" SortExpression="Dec">
                                                            <EditItemTemplate>
                                                                <FTB:FreeTextBox ID="FreeTextBox2" Text='<%# Bind("Dec") %>' runat="server" Height="200px"
                                                                    Width="500px">
                                                                </FTB:FreeTextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="FreeTextBox2" ID="RequiredFieldValidator3"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <FTB:FreeTextBox ID="FreeTextBox2" Text='<%# Bind("Dec") %>' runat="server" Height="200px"
                                                                    Width="500px">
                                                                </FTB:FreeTextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="FreeTextBox2" ID="RequiredFieldValidator3"
                                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Dec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" ShowEditButton="True" />
                                                    </Fields>
                                                </asp:DetailsView>
                                                &nbsp;
                                            </td>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="Left_04">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Left_03" valign="bottom" width="8" style="height: 19px">
                        <img height="8" src="../images/Admin_8.gif" width="8"></td>
                    <td class="Left_02" style="height: 19px">
                        &nbsp;</td>
                    <td class="Left_04" valign="bottom" width="8" style="height: 19px">
                        <img height="8" src="../images/Admin_1.gif" width="8"></td>
                </tr>
            </tbody>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetTeacherByID" TypeName="Jiaen.BLL.Teacher" DataObjectTypeName="Jiaen.Components.TeacherInfo"
            InsertMethod="InsertTeacher" UpdateMethod="UpdateTeacher">
            <SelectParameters>
                <asp:QueryStringParameter Name="teacherID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

