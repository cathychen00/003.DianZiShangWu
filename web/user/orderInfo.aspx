<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="orderInfo.aspx.cs" Inherits="user_orderInfo" Title="订单信息" %>

<%@ Register Src="../Control/userLeftMenu.ascx" TagName="userLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="showInfo-main">
        <uc1:userLeftMenu ID="UserLeftMenu2" runat="server" />
        <div class="loginInfo-main-right">
            <br />
            <div class="ff9clolor">
                <img src="../images/usercenter.jpg" width="160" height="50" />欢迎来到迦恩计算机网站中心!</div>
            <table cellspacing="0" cellpadding="0" width="502" border="0" align="left">
                <!--DWLayoutTable-->
                <tbody>
                    <tr>
                        <td width="500" height="27" valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/firstlog.jpg">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="154" height="5">
                                    </td>
                                    <td width="163">
                                    </td>
                                    <td style="width: 183px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 21px">
                                    </td>
                                    <td valign="top" class="ff9clolor" style="height: 21px">
                                        <strong>订 单 查 询</strong></td>
                                    <td style="width: 183px; height: 21px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3">
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 183px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="205" valign="top" style="border-left: #c2c2c2 1px solid; border-right: #c2c2c2 1px solid;">
                            <table height="142" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
                                <!--DWLayoutTable-->
                                
                                    <tbody>
                                        <tr>
                                            <td width="488" height="181" valign="top">
                                                <table cellspacing="0" cellpadding="3">
                                                    <!--DWLayoutTable-->
                                                    <tbody>
                                                        <tr bgcolor="#F9F8DD">
                                                            <td width="156" height="39" valign="top" class="s">
                                                                <span class="ff9clolor">&nbsp;○&nbsp;正在关注的订单记录1条</span></td>
                                                            <td width="320" align="right" valign="top" bgcolor="#F9F8DD" class="s">
                                                                <span class="style6"></span><span class="ff9clolor"> </span>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:GridView Width="100%" ID="GridView1" runat="server" PageSize="5" DataKeyNames="OrderID"
                                                    AllowPaging="True" DataSourceID="ObjectDataSource1" BackColor="#FFCC99" CellPadding="1"
                                                    CellSpacing="1" AutoGenerateColumns="False" EnableViewState="False" GridLines="None">
                                                    <Columns>
                                                        <asp:BoundField DataField="OrderID" HeaderText="订单号" SortExpression="OrderID" >
                                                            <ItemStyle Width="80px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AddDate" HeaderText="订单时间" SortExpression="AddDate" >
                                                            <ItemStyle Width="80px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AddressName" HeaderText="收货人" SortExpression="AddressName" >
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="订购金额">
                                                            <ItemTemplate>
                                                                <%# Eval("SumPrice","{0:c}") %>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="40px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="订单状态">
                                                            <ItemTemplate>
                                                             <%# DataFormat.OrderFormat((int)Eval("OrderStatus"))%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="操作">
                                                            <ItemTemplate>
                                                             <a href=OrderModify.aspx?orderid=<%# Eval("orderID") %> ><font color="#000099">详细</font></a> 
                                                            </ItemTemplate>
                                                            <ItemStyle Width="25px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="ff9clolor" BackColor="#F9F8DD" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F9F8DD" />
                                                    <PagerStyle BackColor="#FFCC99" />
                                                </asp:GridView>
                                                <br />
                                                
                                                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <!--<font color=red>注：
                  <li>修改订单状态请点击订单号，进入订单详细页面修改！</li>
                  <li>关注订单及过期订单只是前台会员查看订单时显示与否的设置，对订单实际状态不产生任何影响。</li>
                  </font>-->
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="58" valign="top">
                            <table width="500" border="0" background="../images/bg_bottom.gif" cellpadding="0"
                                cellspacing="0">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="500" style="height: 65px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 100px">
                            &nbsp;</td>
                        <td style="height: 100px">
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-----showInfo-main-right----------------------->
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetUserOrders" TypeName="Jiaen.BLL.Orders"></asp:ObjectDataSource>
</asp:Content>

