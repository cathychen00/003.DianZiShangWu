<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="admin_Payment" %>

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
                                                        <a href="Payment.aspx">支付方式</a></td>
                                                    <td class="Default_Item" id="TD2">
                                                        <a href="OnLinePayment.aspx">在线支付方式</a></td>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                                    SkinID="orange" DataKeyNames="PaymentID" OnRowEditing="GridView1_RowEditing"
                                                    OnRowCancelingEdit="GridView1_RowCancelingEdit">
                                                    <Columns>
                                                        <asp:BoundField DataField="UserName" HeaderText="名称" />
                                                        <asp:TemplateField HeaderText="描述" SortExpression="AddDate">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Height="34px" Text='<%# Bind("Dec") %>'
                                                                    TextMode="MultiLine" Width="286px"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Dec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                    Text="更新"></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                    Text="取消"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Text="编辑"></asp:LinkButton>
                                                                <asp:LinkButton OnClientClick='return confirm("确定要删除吗?")' ID="LinkButton2" runat="server"
                                                                    CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                &nbsp; &nbsp;
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
                        &nbsp;<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
                            DataSourceID="ObjectDataSource1" DefaultMode="Insert">
                            <Fields>
                                <asp:TemplateField HeaderText="名称" SortExpression="UserName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="描述" SortExpression="Dec">
                                    <EditItemTemplate>
                                        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Dec") %>' Width="350px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Dec") %>' Width="350px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Dec") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" />
                            </Fields>
                        </asp:DetailsView>
                    </td>
                    <td class="Left_04" valign="bottom" width="8" style="height: 19px">
                        <img height="8" src="../images/Admin_1.gif" width="8"></td>
                </tr>
            </tbody>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.PaymentInfo"
            DeleteMethod="DeletePayment" InsertMethod="InsertPayment" SelectMethod="GetPayment"
            TypeName="Jiaen.BLL.Payment" UpdateMethod="UpdatePayment" OnUpdating="ObjectDataSource1_Updating"
            OldValuesParameterFormatString="original_{0}" OnUpdated="ObjectDataSource1_Updated">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="payType" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp; &nbsp; &nbsp;
    </form>
</body>
</html>

