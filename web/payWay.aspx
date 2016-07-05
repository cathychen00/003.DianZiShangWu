<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payWay.aspx.cs" Inherits="payWay" %>

<%@ Register Src="Control/cartHelp.ascx" TagName="cartHelp" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>支付方式</title>
    <link href="images/cssothers.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="shopwhole">
            <uc2:cartHelp ID="CartHelp1" runat="server"></uc2:cartHelp>
            <div class="shop-banner">
                <img height="41" src="images/goulog.jpg" width="128" /><img height="36" alt="1" src="images/1.jpg"
                    width="122" /><img height="36" src="images/one.jpg" width="12" /><img height="36"
                        alt="2" src="images/2_1.jpg" width="113" /><img height="36" src="images/one.jpg"
                            width="12" /><img height="36" alt="3" src="images/3_1.jpg" width="114" /><img height="36"
                                src="images/one.jpg" width="12" /><img height="36" src="images/4.jpg" width="109" /><img
                                    height="36" src="images/one.jpg" width="12" /><img height="36" src="images/5.jpg"
                                        width="122" /></div>
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
                            <td width="729" align="middle" valign="baseline">
                                <p align="left">
                                    <font size="3"><b><font color="#ff6600">请选择支付方式：</font></b></font></p>
                            </td>
                        </tr>
                        <tr>
                            <td height="223" valign="top">
                                <jiaen:PayRadioButtonList Width="100%" BorderWidth="1" CellPadding="5" BorderColor="#f8d8b1"
                                    ID="PayRadioButtonList1" runat="server">
                                </jiaen:PayRadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PayRadioButtonList1"
                                    ErrorMessage="请选择支付方式"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="shopcon">
                    <p>
                        <a href="shoppingorder.aspx">
                            <img src="images/return.jpg" alt="contine" width="111" height="27" /></a>
                        <asp:ImageButton ImageUrl="images/next.jpg" ID="ImageButton1" runat="server"
                            OnClick="ImageButton1_Click" />
                    </p>
                </div>
            </div>
            <!-----------shop-main--------------------------->
            <jiaen:footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
