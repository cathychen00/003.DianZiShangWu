<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tgshoppingorder.aspx.cs" Inherits="tgshoppingorder" %>
<%@ Register Src="Control/cartHelp.ascx" TagName="cartHelp" TagPrefix="uc2" %>
<%@ Register Src="Control/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单确认</title>
    <link href="images/cssothers.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="shopwhole">
          <uc2:cartHelp id="CartHelp1" runat="server"></uc2:cartHelp>
            <DIV class="shop-banner">　<IMG height=41 
src="images/goulog.jpg" width=128 /><IMG 
height=36 alt="1" src="images/1.jpg" width=122 /><IMG height=36 src="images/one.jpg" 
width=12 /><IMG height=36 alt="2" 
src="images/2_1.jpg" width=113 /><IMG 
height=36 src="images/one.jpg" width=12 
/><IMG height=36 alt="3" src="images/3.jpg" width=114 /><IMG height=36 src="images/one.jpg" 
width=12 /><IMG height=36 src="images\41.jpg" 
width=109 /><IMG height=36 
src="images/one.jpg" width=12 /><IMG 
height=36 src="images/5.jpg" width=122 
/></DIV>
            <!-----------shop-bananer--------------------------->
            <div class="shop-tit">
                <img src="images/litter.gif" alt="heng" width="15" height="12" />用户名:<asp:LoginName
                    ID="LoginName1" runat="server" />
            </div>
            <div class="shop-main">
                <table cellspacing="2" cellpadding="2" width="96%" align="center" border="0">
                    <!--DWLayoutTable-->
                    <tbody>
                        <tr>
                            <td width="729" height="333" valign="top">
                                <table cellspacing="0" cellpadding="3" width="80%" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td align=center>
                                                <b>收货地址</b>&nbsp;&nbsp;&nbsp;&nbsp;<a href="shoppingdetail.aspx"><u><font color="#000099">修改收货地址</font></u></a></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:FormView ID="FormView2" Width="100%" runat="server" DataSourceID="ObjectDataSource1">
                                                    <ItemTemplate>
                                                    
                                                <table cellspacing="0" cellpadding="3" width="100%" align="center" bgcolor="#ececff"
                                                    border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="25%">
                                                                
                                                                姓名：<asp:Label ID="AddressName" runat="server" Text='<%# Eval("AddressName") %>' /></td>
                                                            
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                地址：<asp:Label ID="Label1" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                                                <asp:Label ID="Address" runat="server" Text='<%# Eval("Address") %>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                邮编：<asp:Label ID="Post" runat="server" Text='<%# Eval("Post") %>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td width="25%" style="height: 25px">
                                                                电话：<asp:Label ID="Telephone" runat="server" Text='<%# Eval("Telephone") %>' /></td>
                                                            <td width="51%" style="height: 25px">
                                                            </td>
                                                            <td width="24%" style="height: 25px">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                </ItemTemplate>
                                                </asp:FormView>
                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetAddressByID" TypeName="Jiaen.BLL.Address"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#000000" height="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="middle">
                                                <b>发货方式</b>&nbsp;&nbsp;&nbsp;&nbsp;<u><a href="shoppingway.aspx"><font color="#000099">修改发货方式</font></a></u></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                
                                                <asp:FormView width="100%" ID="FormView1" runat="server" DataSourceID="ObjectDataSource1">
                                                <ItemTemplate>
                                                <table cellspacing="0" cellpadding="3" width="100%" align="center" bgcolor="#ececff"
                                                    border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="18%">
                                                                送货方式:</td>
                                                            <td width="82%">
                                                                <asp:Label ID="sendName" runat="server" Text='<%# Eval("Name") %>' /></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                </ItemTemplate>
                                                </asp:FormView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 8px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#000000" height="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="middle">
                                                <b>付款方式</b>&nbsp;&nbsp;&nbsp;&nbsp;<a href="payWay.aspx"><u><font color="#000099">修改付款方式</font></u></a></td>
                                        </tr>
                                        <tr>
                                            <td>
         
                                           <table cellspacing="0" cellpadding="0" width="100%" bgcolor="#ececff" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="18%">
                                                                付款方式：</td>
                                                            <td width="83%">
                                                                <asp:Label ID="payName" runat="server" />
                                                                
                                                                </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="middle">
                                                <b><font color="#cc6600">您是否要开具发票？</font></b></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" bgcolor="#ececff" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="InvoiceList" runat="server">
                                                                    <asp:ListItem Selected="True" Value="True">不开发票</asp:ListItem>
                                                                    <asp:ListItem Value="False">开发票（办理退货时，请将发票随货寄回。）</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#000000" height="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <b>您所要购买商品的购物清单</b>&nbsp;&nbsp;&nbsp;&nbsp;<a runat=server href="TgShoppingCart.aspx" id="cart"><u><font color="#000099">修改购物清单</font></u></a></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 88px">
                                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource2">
                                                    <ItemTemplate>
                                                        <table cellspacing="0" cellpadding="0" bgcolor="#ececff" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td width="4%">
                                                                        <font color="#ff6600" size="3">·</font></td>
                                                                    <td width="63%">
                                                                        <a href='bookinfo.aspx?bookID=<%# Eval("BookID") %>' target="_blank"><u><font color="#000099">
                                                                            <%# Eval("BookName") %>
                                                                        </font></u></a>
                                                                    </td>
                                                                    <td width="33%">
                                                                        优惠价：<asp:Label ID="Price" runat="server" Text='<%# Bind("VipPrice","{0:c}") %>'></asp:Label>&nbsp;&nbsp;&nbsp;数量：<%# Eval("Quantity") %><asp:Label
                                                                            Visible="false" ID="quantityTxt" Text='<%# Bind("Quantity") %>' Width="40" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"  SelectMethod="SelectTgCart" TypeName="Jiaen.BLL.ShoppingCart" DeleteMethod="DeleteCart" OldValuesParameterFormatString="original_{0}">
                    <DeleteParameters>
                        <asp:Parameter Name="bookID" Type="Int32" />
                    </DeleteParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#000000" style="height: 1px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="middle">
                                                <b>订单金额</b></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="3" width="100%" bgcolor="#ececff" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 25px">
                                                                商品金额：<asp:Label ID="orderPriceTxt" runat="server" /></td>
                                                        </tr>
                                                         <tr>
                                                            <td style="height: 25px">
                                                                送货费用：<asp:Label ID="sendPrice" runat="server" />元</td>
                                                        </tr> 
                                                        <tr>
                                                            <td>
                                                                <b><font color="#cc3300">总计应付金额：<asp:Label ID="sumPrice" runat="server" Text="Label"></asp:Label>元</font></b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 25px">
                                                               <b> <font color="#cc3300">帐户余额：<asp:Label ID="balanceTxt" runat="server" />元</font></b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 47px">
                                                                <asp:Panel ID="Panel1" runat="server" Width="400px">
                                                                    您可以使用帐户余额支付
                                                                    <asp:TextBox ID="balancePayTxt" runat="server">0</asp:TextBox>
                                                                    <asp:Button ID="Button1" runat="server" Text="支付" OnClick="Button1_Click" /><br />
                                                                    <asp:Label ID="failTxt" runat="server" ForeColor="Brown"></asp:Label>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="balancePayTxt"
                                                                        ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator></asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong><span style="color: #cc3300">帐户余额已支付：</span></strong><asp:Label ID="balancePay"
                                                                    runat="server">0</asp:Label>元</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong><span style="color: #cc3300">还需支付：</span></strong><asp:Label ID="needBalancePay"
                                                                    runat="server"></asp:Label>元</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#000000" height="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="3" width="100%" bgcolor="#ececff" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td valign="top" align="right" width="12%">
                                                                购物留言：</td>
                                                            <td width="88%">
                                                                &nbsp;<asp:TextBox ID="messageTxt" runat="server" Height="56px" TextMode="MultiLine"
                                                                    Width="381px"></asp:TextBox><font color="#ff6600">（不超过1000字）</font>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="shopcon">
                    <p>
                        <a href="ShoppingCart.aspx">
                            <img src="images/return.jpg" alt="contine" width="111" height="27" /></a>
                        
                        <asp:ImageButton ImageUrl="images/next.jpg" ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" CausesValidation="False" />
                        </p>
                </div>
            </div>
            <!-----------shop-main--------------------------->
            <uc1:footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>

