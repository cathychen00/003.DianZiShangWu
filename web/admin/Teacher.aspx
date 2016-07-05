<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="admin_Teacher" %>

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
                                                    <td class="Current_Item" id="TD1">
                                                        <a href="Teacher.aspx">教师列表</a></td>
                                                    <td class="Default_Item" id="TD2">
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
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <td>
                                                &nbsp;
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                                    DataKeyNames="TeacherID" SkinID="orange" AllowPaging="True" PageSize="5">
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="名字" SortExpression="CatenaName" />
                                                        <asp:ImageField DataImageUrlField="Image" HeaderText="照片">
                                                        </asp:ImageField>
                                                        <asp:CheckBoxField DataField="IsMain" HeaderText="推荐" SortExpression="IsMain" />
                                                        <asp:TemplateField HeaderText="管理">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("teacherID", "addTeacher.aspx?edit={0}") %>'
                                                                    Text="修改"></asp:HyperLink>
                                                                <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    Text="删除"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.TeacherInfo"
            DeleteMethod="DeleteTeacher" SelectMethod="GetTeacher" TypeName="Jiaen.BLL.Teacher">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="type" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

