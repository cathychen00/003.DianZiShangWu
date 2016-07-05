<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>
<%@ Register Src="Control/cartHelp.ascx" TagName="cartHelp" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>购物车</title>
    <link href="images/cssothers.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="shopwhole">
            <uc2:cartHelp id="CartHelp1" runat="server"></uc2:cartHelp>
            <DIV class="shop-banner">　<IMG height=41 
src="images/goulog.jpg" width=128 /><IMG 
height=36 alt="1" src="images/11.jpg" width=122 /><IMG height=36 src="images/one.jpg" 
width=12 /><IMG height=36 alt="2" 
src="images/2_1.jpg" width=113 /><IMG 
height=36 src="images/one.jpg" width=12 
/><IMG height=36 alt="3" src="images/3.jpg" width=114 /><IMG height=36 src="images/one.jpg" 
width=12 /><IMG height=36 src="images/4.jpg" 
width=109 /><IMG height=36 
src="images/one.jpg" width=12 /><IMG 
height=36 src="images/5.jpg" width=122 
/></DIV>
            <!-----------shop-bananer--------------------------->
            <div class="shop-tit">
                <img src="images/litter.gif" alt="heng" width="15" height="12" />
                <asp:LoginName ID="LoginName1" runat="server" FormatString="用户名: {0}" />

            </div>
            <div class="shop-main">
                <table cellspacing="2" cellpadding="2" width="96%" align="center" border="0">
                    <tbody>
                        <tr>
                            <td valign="baseline" align="middle">
                                我的购物车</td>
                        </tr>
                    </tbody>
                </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                    CellPadding="1" CellSpacing="1" HorizontalAlign="Center" Width="96%" BackColor="#FFCC00" DataKeyNames="BookID" OnRowDataBound="GridView1_RowDataBound" DataSourceID="ObjectDataSource1" ShowFooter="True" OnRowDeleted="GridView1_RowDeleted">
                    <Columns>
                        <asp:HyperLinkField HeaderText="商品名称" DataTextField="BookName" DataNavigateUrlFields="bookID" DataNavigateUrlFormatString="bookInfo.aspx?bookID={0}">
                            <HeaderStyle Width="40%" />
                            <ItemStyle HorizontalAlign="Left" BackColor="#FFF9EC" />
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="单价(会员)">
                            <ItemStyle BackColor="#FFF9EC" HorizontalAlign="Center" />
                            <HeaderStyle Width="18%" />
                            <ItemTemplate>
                              <font color=red>￥<asp:Label ID="Price" runat="server" Text='<%# Bind("MemberPrice") %>'></asp:Label></font>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数量">
                            <HeaderStyle Width="15%" />
                            <ItemTemplate>
                                <asp:TextBox ID="quantityTxt" Text='<%# Bind("Quantity") %>' Width="40" runat="server"></asp:TextBox>&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="quantityTxt"
                                    ErrorMessage="*" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ControlToValidate="quantityTxt" id="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                            <ItemStyle BackColor="#FFF9EC" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="总价">
                            <ItemStyle HorizontalAlign="Center" BackColor="#FFF9EC" />
                            <HeaderStyle Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="allPirceTxt" ForeColor="red" runat="server"></asp:Label>元
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/trash.gif" HeaderText="删除"
                            ShowDeleteButton="True">
                            <HeaderStyle Width="12%" />
                            <ItemStyle HorizontalAlign="Center" BackColor="#FFF9EC" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle ForeColor="#666666" HorizontalAlign="Center" BackColor="#FFE2A6" />
                </asp:GridView>
                <table cellspacing="1" cellpadding="1" width="96%" align="center" bgcolor="#ffcc00"
                    border="0">
                    <tbody>
                        <tr bgcolor="#ffffff">
                            <td colspan="6" height="25">
                                <div align="center">
                                    <asp:ImageButton ID="deleteBtn" runat="server" ImageUrl="images/cart02.gif" OnClick="deleteBtn_Click" />&nbsp;
                                    <asp:ImageButton ID="updateBtn" runat="server" ImageUrl="images/cart03.gif" OnClick="updateBtn_Click" />&nbsp;&nbsp;
                                    
                                    <asp:ImageButton ID="ImageButton1" ImageUrl="images/cart04.gif" runat="server" OnClick="ImageButton1_Click" />
                                    
                                    </div>
                            </td>
                        </tr>
                        <tr bgcolor="#fff9ec">
                            <td colspan="6" height="36">
                                <div align="center">
                                    购物车里有商品：<asp:Label ID="numTxt" runat="server"></asp:Label>件 总数：<asp:Label
                                        ID="allNumTxt" runat="server"></asp:Label>件 共计：<asp:Label ID="CartPriceTxt"
                                            runat="server" Font-Italic="True"></asp:Label>元 
                                    <br>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="shopcon">
                    <p>
                        <a href="default.aspx"><img alt="contine" height="27" src="images/go.jpg" width="111" /></a>&nbsp;<a href="shoppingOrder.aspx"></a></p>
                </div>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                    SelectMethod="SelectCart" TypeName="Jiaen.BLL.ShoppingCart" DeleteMethod="DeleteCart">
                    <DeleteParameters>
                        <asp:Parameter Name="bookID" Type="Int32" />
                        <asp:Parameter DefaultValue="False" Name="isTg" Type="Boolean" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <center>
                <asp:Label ID="Label1" ForeColor=red runat="server"></asp:Label>
                </center>
            </div>
            <!-----------shop-main--------------------------->
            <jiaen:footer ID="Footer1" runat="server" />
        </div>
        
    </form>
</body>
</html>

