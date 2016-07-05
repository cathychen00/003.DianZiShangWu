<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shoppingComplete.aspx.cs" Inherits="shoppingComplete" %>
<%@ Register Src="Control/cartHelp.ascx" TagName="cartHelp" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单完成</title>
    <link href="images/cssothers.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="shopwhole">
<uc2:cartHelp id="CartHelp1" runat="server"></uc2:cartHelp>

<div class="shop-banner">　<img src="images/goulog.jpg" width="128" height="41" /><img src="images/1.jpg" alt="1" width="122" height="36" /><img src="images/one.jpg" width="12" height="36" /><img src="images/2_1.jpg" alt="2" width="113" height="36" /><img src="images/one.jpg" width="12" height="36" /><img src="images/3.jpg" alt="3" width="114" height="36" /><img src="images/one.jpg" width="12" height="36" /><img src="images/4.jpg" width="109" height="36" /><img src="images/one.jpg" width="12" height="36" /><img src="images/5_1.jpg" width="122" height="36" /></div>
<!-----------shop-bananer--------------------------->　　　　　　<div class="shop-main"><TABLE cellSpacing=2 cellPadding=2 width="96%" align=center border=0>
   <!--DWLayoutTable-->
  <tr><td width="78" height="11">
    <td width="558">    
    <td width="81"></td>
    <tr>
    <td style="height: 127px">  
    <TD vAlign=top style="height: 127px">    <TABLE cellSpacing=0 cellPadding=3 width=450 align=center border=0>
          <!--DWLayoutTable-->
        <TBODY>
        <TR>
          <TD width="498" height=5></TD></TR>
        <TR>
          <TD height=48 valign="top"><p class="m style6"><FONT 
      color=#ff3300>感谢您光临迦恩计算机资源网，您的订单已经生效,编号为<asp:Label ID="orderID" runat="server"
          Text="Label"></asp:Label>,已送交处理中心,很快您会收到一份确认信.</FONT></p></TD>
          </TR>
        <TR>
          <TD height=1>
              您的付款方式为<asp:Label ID="payTypeTxt" runat="server" ForeColor="Red"></asp:Label><br />
              <asp:Label ID="payMessage" runat="server"></asp:Label>
              <asp:Panel ID="Panel1" runat="server" Height="50px" Visible="False" Width="200px">
              立即支付<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="支付宝支付" /></asp:Panel>
          </TD>
        </TR>
        </TBODY>
    </TABLE>
   
    <tr>
    <td style="height: 50px">  
    <TD valign="top" style="height: 199px">    
        <asp:FormView align=center ID="FormView1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
        <TABLE cellSpacing=1 cellPadding=2 width=450 align=center bgColor=#000099 
border=0>
    <TBODY>
    <TR>
      <TD class=s bgColor=#6666cc colSpan=2><FONT 
      color=#ffffff><B>以下为您此次订单的详细信息：</B></FONT></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#f0f0f0>您的订单号：</TD>
      <TD class=style2 width="76%" bgColor=#ffffff><FONT 
      color=#ff3300><B>
          <%# Eval("orderID")%></B></FONT><FONT class=s color=#000099>（<A 
      href="user/OrderModify.aspx?orderID=<%# Eval("orderID")%>" 
      target=_blank>查看订单详细信息</A>）</FONT></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#ffffff>收货人姓名：</TD>
      <TD class=s width="76%" bgColor=#ffffff>
          <%# Eval("AddressName")%></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#f0f0f0>收货人地址：</TD>
      <TD class=s width="76%" bgColor=#ffffff>
          <%# Eval("Address")%></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#ffffff>送货方式：
      
      </TD>
      <TD class=s width="76%" bgColor=#ffffff>
          <%# getSend((int)Eval("SendType"))%></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#f0f0f0>付款方式：
      
      </TD>
      <TD class=s width="76%" bgColor=#ffffff>
          <%# getPay((int)Eval("PayType"))%></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#ffffff>各项费用：</TD>
      <TD class=s width="76%" 
      bgColor=#ffffff>商品<%# Eval("BookPrice","{0:n}")%>元、配送费<%# Eval("SendPrice","{0:n}")%>元、已支付<%# Eval("BalancePrice", "{0:n}")%></TD></TR>
    <TR>
      <TD class=s width="24%" bgColor=#f0f0f0>应付金额：</TD>
      <TD class=style2 width="76%" bgColor=#ffffff><FONT 
      color=#ff3300><B><%# Eval("NeedPayPrice", "{0:n}")%>元</B></FONT></TD></TR>
    </TBODY>
    </TABLE>
        </ItemTemplate>
        </asp:FormView>
        
    <td style="height: 199px"></td>
    <tr>
    <td height="49">  
    <TD valign="top">    
  </TABLE>
    
    <td></td>
    <TBODY><TR>
    <TD height="1"></TD>
    <TD></TD>
    <TD></TD>
  </TR>
   <div class="shopcon">
	     <p align="center"> 　　 　 &nbsp;
             <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                 SelectMethod="GetOrdersByID" TypeName="Jiaen.BLL.Orders">
                 <SelectParameters>
                     <asp:CookieParameter CookieName="orderID" DefaultValue="0" Name="orderID" Type="Int64" />
                 </SelectParameters>
             </asp:ObjectDataSource>
         </p>
    </div>

</div><!-----------shop-main---------------------------><jiaen:footer ID="Footer1" runat="server" />
  
</div>
</form>
</body>
</html>

