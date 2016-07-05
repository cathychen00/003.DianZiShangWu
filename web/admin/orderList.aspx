<%@ Page StylesheetTheme="default" Language="C#" AutoEventWireup="true" CodeFile="orderList.aspx.cs" Inherits="admin_orderList" %>
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
                <TD runat="server" class=Default_Item id=navi0><A 
                  href="orderList.aspx?state=1">未确认订单</A></TD>
                <TD runat="server" class=Default_Item id=navi1><A 
                  href="orderList.aspx?state=2">等待付款订单</A></TD>
                <TD runat="server" class=Default_Item id=navi2><A 
                  href="orderList.aspx?state=3">已付款订单</A></TD>
                <TD runat="server" class=Default_Item id=navi3><A 
                  href="orderList.aspx?state=4">已发货订单</A></TD>
                <TD runat="server" class=Default_Item id=navi4><A 
                  href="orderList.aspx?state=5">已取消订单</A></TD>
                <TD runat="server" class=Default_Item id=navi5><A 
                  href="orderList.aspx?state=0">全部订单</A></TD>
                  <TD runat="server" class=Default_Item id=navi6><A 
                  href="orderList.aspx?state=6">今日订单</A></TD>
               </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE class=C_order_state cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TBODY>
        <TR>
           <TD  style="FONT-SIZE: 12px">
              &nbsp; 订单号:<asp:TextBox
                                        ID="searchKey" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button4" runat="server" Text="查找" OnClick="Button1_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
          </TD></TR>
			  <tr>
			  <td><table  width="100%">
			  <td>
                  &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="emptyData" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        DataKeyNames="OrderID" DataSourceID="ObjectDataSource1" SkinID="orange">
                                        <Columns>
                                            <asp:TemplateField HeaderText="订单号">
                                                <ItemTemplate>
                                                  <a id="A1" runat="server" target="_blank" href='<%# "OrderModify.aspx?orderID="+Eval("orderID") %>' ><%# Eval("orderID")%></a> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AddDate" HeaderText="下订时间" SortExpression="AddDate" />
                                            <asp:TemplateField HeaderText="货品金额" SortExpression="BookPrice">

                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BookPrice", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="运费" SortExpression="SendPrice">

                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SendPrice", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="总金额" SortExpression="SumPrice">

                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SumPrice", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SendType" HeaderText="配送方式" SortExpression="SendType" />
                                            <asp:BoundField DataField="PayType" HeaderText="支付方式" SortExpression="PayType" />
                                            <asp:BoundField DataField="UserName" HeaderText="购物会员" SortExpression="UserName" />
                                            <asp:BoundField DataField="UserName" HeaderText="收货人" SortExpression="UserName" />
                                            <asp:BoundField DataField="Telephone" HeaderText="联系电话" SortExpression="Telephone" />
                                            <asp:TemplateField HeaderText="订单状态" SortExpression="OrderStatus">
                                                <ItemTemplate>
                                                    <font color=red>
                                                <%# orderStatus((bool)Eval("isPass"),"审核") %>
                                                <%# orderStatus((bool)Eval("isPay"), "付款")%><br />
                                                <%# orderStatus((bool)Eval("isSended"), "发货")%>
                                                <%# orderStatus((bool)Eval("IsFinished"), "归档")%></font>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                        <br />
                        <font color="red" size="2">未找到此订单！！</font>
                        <br />
                                        </EmptyDataTemplate>
                                    </asp:GridView>
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
    
   <table cellpadding="0" cellspacing="0" class="twidth" width="650">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div class="mframe">
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetStatusOrders" TypeName="Jiaen.BLL.Orders">
                                        <SelectParameters>
                                            <asp:QueryStringParameter DefaultValue="1" Name="state" QueryStringField="state"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

