<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderModify.aspx.cs" Inherits="admin_OrderModify" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单详细信息</title>
    <LINK href="../images/cssothers.css" 
type=text/css rel=stylesheet />
</head>
<body>
    <form id="form1" runat="server">
    

  <!--header-->
  <!------------------------------------------------------------------------------------->

  <!-----orderInfodetail----------------------->
  <div class="whole">
  <br />
  <br />
  <br />
  <div align=center>
      <strong>
  订单详细信息 </strong>
  </div>
  <br />
  <br />
  <asp:FormView ID="FormView2" runat="server" DataSourceID="ObjectDataSource1" HorizontalAlign="Center">
           <ItemTemplate>
           <TABLE cellSpacing="1" width="600"  cellpadding="0"border=0 bgcolor="#ff900">
  <!--DWLayoutTable-->
  <TBODY>
  <TR bgcolor="#ffffff">
    <TD colspan="5" valign="middle" style="height: 24px">订单号:
        <%# Eval("orderID") %><%# DataFormat.isTg((bool)Eval("isTg"))%></TD>
    <TD colspan="5" valign="middle" style="height: 24px">收货人:<%# Eval("addressName")%></TD>
    <TD colspan="4"valign="middle" style="height: 24px">联系电话:<%# Eval("Telephone")%></TD>
    </TR>
  
  <TR bgColor="#f9f8dd">
    <TD height="24" colspan="11" valign="middle">发货方式:<%# DataFormat.getSend((int)Eval("SendType"))%></TD>
	 <TD colspan="3"valign="middle">邮编:<%# Eval("post")%></TD>
  </TR>
  <TR bgcolor="#ffffff">
    <TD height="24" colspan="14">送货地址:<%# Eval("address")%></TD>
    
    </TR>
	<!---------------------->
	<TR bgColor="#f9f8dd">
	<asp:Repeater runat=server ID="bookList" DataSourceID="ObjectDataSource2">
	<HeaderTemplate>
	    <TD width="75"height="48"align="center" valign="middle">
        &nbsp;编号</TD>
	 <TD width="68" align="center" valign="middle"><div align="center">货品号</div></TD>
	 <TD colspan="8"align="center" valign="middle">商品名称</TD>
	 <TD width=80 colspan="2"align="center" valign="middle">市场价</TD>
	 
	 <TD width="80" align="center" valign="middle">迦恩价</TD>
	 <TD width="70"align="center" valign="middle">订购数量</TD>
	 </TR>
	</HeaderTemplate>
	<ItemTemplate>
	<TR bgColor=#FFFFFF>
    <TD height="24"align="center" valign="middle"><%# Container.ItemIndex+1 %></TD>
	 <TD align="center" valign="middle"><%# Eval("BookID") %></TD>
	 <TD colspan="8" valign="middle"><%# Eval("BookName") %></TD>
	 <TD colspan="2" align="center" valign="middle"><%# Eval("Price","{0:c}") %>元</TD>
	 
	 <TD align="center" valign="middle"><%# Eval("MemberPrice","{0:c}") %>元</TD>
	 <TD align="center" valign="middle"><%# Eval("Quantity") %></TD>
	 </TR>
	</ItemTemplate>
	<AlternatingItemTemplate>
	<TR bgColor=#F9F8DD>
    <TD height="24"align="center" valign="middle"><%# Container.ItemIndex %></TD>
	 <TD align="center" valign="middle"><%# Eval("BookID") %></TD>
	 <TD colspan="8" valign="middle"><%# Eval("BookName") %></TD>
	 <TD colspan="2" align="center" valign="middle"><%# Eval("Price","{0:c}") %>元</TD>
	
	 <TD align="center" valign="middle"><%# Eval("MemberPrice", "{0:c}")%>元</TD>
	 <TD align="center" valign="middle"><%# Eval("Quantity") %></TD>
	 </TR>
	</AlternatingItemTemplate>
	</asp:Repeater>
  
  <!---------------------->
  	 <TR bgColor="#f9f8dd">
    <TD height="24" colspan="3" valign="middle">订购货款:<%# Eval("BookPrice", "{0:c}")%>元</TD>
	 <TD colspan="6" rowspan="1"valign="middle">发送费:<%# Eval("SendPrice", "{0:c}")%>元</TD>
	 <TD colspan="5"valign="middle">订购总计:<%# Eval("SumPrice", "{0:c}")%>元</TD>
	 </TR>
	 <!------------------------>
	 <TR bgColor="#ffffff">
    <TD height="24" colspan="5"  valign="middle">订购日期:<%# Eval("addDate") %></TD>
	 <TD colspan="9">付款方式:<%# DataFormat.getPay((int)Eval("payType")) %></TD>
	 </TR>
	  <TR bgColor="#f9f8dd">
    <TD colspan="5"  valign="middle" style="height: 24px">已付款:<%#  DataFormat.getSumPay((decimal)Eval("balancePrice"), (decimal)Eval("otherPayPrice"))%><br /><%# DataFormat.getNeedPay((decimal)Eval("needPayPrice"))%></TD>
	 <TD colspan="9" style="height: 24px">发货状态:<%# DataFormat.isSend((DateTime)Eval("addDate"), (DateTime)Eval("sendDate"))%>
     </TD>
	 </TR>
	 <TR bgColor="#ffffff">
    <TD height="24" colspan="14"  valign="middle" id="TD1" runat="server">
        &nbsp;<strong>修改订单状态</strong></TD>
	 </TR>
	 <!---------------------------------------------->
   <tr bgcolor="#ffffff">
          <td runat="server" colspan="14" height="24" valign="middle">
      <jiaen:ordertypecheckboxlist id="OrderTypeCheckBoxList1" runat="server"></jiaen:ordertypecheckboxlist>
          </td>
      </tr>
  <tr>
    <td height="0"></td>
    <td></td>
    <td width="29"></td>
    <td width="68"></td>
    <td width="69"></td>
    <td width="22"></td>
    <td width="28"></td>
    <td width="11"></td>
    <td width="36"></td>
    <td width="6"></td>
    <td width="30"></td>
    <td width="21"></td>
    <td></td>
    <td></td>
    </tr>
  </TBODY></TABLE>
  </ItemTemplate>
  </asp:FormView>
  <br/>　&nbsp;
  <div align=center>  
  <input id=saveOrder style="WIDTH: 80px; BORDER-TOP-STYLE: ridge; BORDER-RIGHT-STYLE: ridge; BORDER-LEFT-STYLE: ridge; HEIGHT: 29px; BORDER-BOTTOM-STYLE: ridge" type=submit value=保存 name=saveOrder runat="server" onserverclick="saveOrder_ServerClick" />&nbsp;
  </div>
<br/>
  <!-------------------------------orderInfodetail--------------------------------------------------------->
  
  <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDerailByID" TypeName="Jiaen.BLL.Orders">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="orderID" QueryStringField="orderID"
                    Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;<!--main的结尾------------------------------>
        &nbsp;
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetOrdersByID" TypeName="Jiaen.BLL.Orders">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="orderID" QueryStringField="orderID"
                    Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
      &nbsp;
</div>

    </form>
</body>
</html>

