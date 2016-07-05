<%@ Page EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="OnLinePayment.aspx.cs" Inherits="admin_OnLinePayment" %>

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
                  href="Payment.aspx">支付方式</A></TD>
                <TD class=Current_Item id=TD2><A 
                  href="OnLinePayment.aspx">在线支付方式</A></TD>
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
                  &nbsp;
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" SkinID="orange" DataKeyNames="PaymentID">
                                        <Columns>
                                            <asp:BoundField DataField="PayName" HeaderText="在线支付名称" SortExpression="PayName" />
                                            <asp:BoundField DataField="UserName" HeaderText="帐户名称" />
                                            <asp:BoundField DataField="PrivateKey" HeaderText="帐户密钥" SortExpression="PrivateKey" />
                                            <asp:BoundField DataField="Status" HeaderText="状态" SortExpression="Status" />
                                            <asp:HyperLinkField DataNavigateUrlFields="PaymentID" DataNavigateUrlFormatString="?edit={0}"
                                                Text="修改" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp; &nbsp;&nbsp;&nbsp;
                  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="PaymentID"
                      DataSourceID="ObjectDataSource2" DefaultMode="Edit" Height="50px" OnItemUpdated="DetailsView1_ItemUpdated"
                      Visible="False">
                      <Fields>
                          <asp:TemplateField HeaderText="在线支付" SortExpression="PayName">
                              <EditItemTemplate>
                                 <asp:Label Width="200" ID="Label2" runat="server" Text='<%# Eval("PayName") %>'></asp:Label>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox1" runat="server" Text='<%# Bind("PayName") %>'></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("PayName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="帐户名称" SortExpression="UserName">
                              <EditItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox1" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="账户密钥" SortExpression="PrivateKey">
                              <EditItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox2" runat="server" Text='<%# Bind("PrivateKey") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox3" runat="server" Text='<%# Bind("PrivateKey") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label3" runat="server" Text='<%# Bind("PrivateKey") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="身份标识" SortExpression="PartnerID">
                              <EditItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox4" runat="server" Text='<%# Bind("PartnerID") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200" ID="TextBox5" runat="server" Text='<%# Bind("PartnerID") %>'></asp:TextBox>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label5" runat="server" Text='<%# Bind("PartnerID") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="描述" SortExpression="Dec">
                              <EditItemTemplate>
                                  <asp:TextBox Width="200" ID="dec" runat="server" Text='<%# Bind("Dec") %>'></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dec"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                              <InsertItemTemplate>
                                  <asp:TextBox Width="200" ID="dec" runat="server" Text='<%# Bind("Dec") %>'></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dec"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>
                              </InsertItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label4" runat="server" Text='<%# Bind("Dec") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowCancelButton="False" ShowEditButton="True" />
                      </Fields>
                  </asp:DetailsView>
              </td>
			  </table>
			  </td>
			  </tr>
			  </TBODY></TABLE></TD>
    <TD class=Left_04>&nbsp;</TD></TR>
  <TR>
    <TD class=Left_03 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_8.gif" width=8></TD>
    <TD class=Left_02 style="height: 19px">&nbsp;
    </TD>
    <TD class=Left_04 vAlign=bottom width=8 style="height: 19px"><IMG height=8 
      src="../images/Admin_1.gif" width=8></TD></TR></TBODY></TABLE>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.PaymentInfo"
            DeleteMethod="DeletePayment" InsertMethod="InsertPayment" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPayment" TypeName="Jiaen.BLL.Payment"
            UpdateMethod="UpdatePayment">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="payType" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Jiaen.Components.PaymentInfo"
            DeleteMethod="DeletePayment" InsertMethod="InsertPayment" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPaymentByID" TypeName="Jiaen.BLL.Payment"
            UpdateMethod="UpdatePayment">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="paymentID" QueryStringField="edit"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>

