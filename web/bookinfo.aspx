<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="bookinfo.aspx.cs" Inherits="bookinfo" Title="图书浏览" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="TW.Web.UI" TagPrefix="cc1" %>
<%@ Register Src="Control/newAndGood.ascx" TagName="newAndGood" TagPrefix="uc3" %>
<%@ Register Src="Control/ViewTopBook.ascx" TagName="ViewTopBook" TagPrefix="uc2" %>
<%@ Register Src="Control/ViewTopDynamic.ascx" TagName="ViewTopDynamic" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <!--主要部分分左右-->
        &nbsp;<div class="main-left">
            <uc1:ViewTopDynamic ID="ViewTopDynamic1" runat="server" EnableViewState="false" />
            <uc2:ViewTopBook ID="ViewTopBook1" runat="server" EnableViewState="false" />
            <uc3:newAndGood ID="NewAndGood1" runat="server" EnableViewState="false" />
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <div class="right-first">
                <b><a href="#" target="_blank"></a></b>
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </div>
            <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" EnableViewState="False">
                <ItemTemplate>
                    <div class="bule">
                        <img src="images/bule.jpg" alt="bule" width="21" height="24" />
                        <%# Eval("BookName")%>
                    </div>
                    <!--topsale--->
                    <div class="right-info">
                        <div class="right-infojpt">
                            <img runat="server" src='<%# Eval("BookImage")%>' alt='<%# Eval("BookName")%>' width="136" height="177" /></div>
                        <div class="right-infoword">
                            【ISBN】<%# Eval("BookISBN") %><br />
                            【分类】<%# getCatName((int)Eval("Category"))%><br />
                            【出版社】<%# Eval("BookPublish") %><br />
                            【作者】<%# Eval("BookAuthor") %>
                            <br />
                            【阅读数】
                            <%# Eval("ReadCount") %>
                            <br />
                            【页数】
                            <%# Eval("BookPages") %>
                            <br />
                            【库存】 <%# getStock((int)Eval("Stock"))%>
                            <br />
                            【出版日期】
                            <%# ((DateTime)Eval("PublishTime")).ToShortDateString() %>
                            【版次】
                            <%# Eval("BookEditions")%>
                            <br />
                            【评价】<%# getRate(Convert.ToInt32(Eval("Rate")))%>
                            <a href="#addreview">参与评论</a> <a href="#allreview">查看书评</a> (共<%# Eval("ReviewCount") %>条)<br />
                        </div>
                    </div>
                    <!-----right-info-------->
                    <div class="right-infobuy">
                        市场价：<%# Eval("Price","{0:c}")%>
                        <span class="ff9clolor">迦恩价：<%# Eval("MemberPrice", "{0:c}")%> 
                            <asp:Label visible='<%# Eval("isRelease") %>' ForeColor="red" ID="Label1" runat="server" Text="此书可以参与,团购价格将更加优惠"></asp:Label><br>
                        </span>
                        <a href='ShoppingCart.aspx?bookID=<%# Eval("bookID") %>'><img src="images/add-to-cart.gif" width="85" height="14" /></a>
                         <a runat=server visible='<%# Eval("isRelease") %>' href='<%# "TgShoppingCart.aspx?bookID="+Eval("bookID") %>'><img src="images/group-buy.gif" width="85" height="14" /></a>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/user/favBookInfo.aspx?bookID="+Eval("bookID") %>'
                            runat="server"><img src="images/favorites.gif" width="85" height="14" /></asp:HyperLink></div>
                    <div class="infocontent">
                        【 内容简介】<br />
                        <%# Eval("BookDec") %>
                    </div>
                    <div class="resign">
                        <img src="images/sign.gif" width="4" height="20" />
                        相关图书</div>
                    <div>
                        <ul>
                            <asp:Repeater DataSource='<%# bookList((string)Eval("searchKey"))%>' ID="Repeater1"
                                runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href='<%# "?bookid="+Eval("bookID") %>' target="_blank"><%# Eval("bookName") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </ItemTemplate>
            </asp:FormView>
            <div class="resign">
                <img src="images/sign.gif" alt="resign" width="4" height="20" />
                读者评价</div>
            <div class="duping">
                <table width="570" cellspacing="0" cellpadding="0">
                    <tr style="background-color: #EAEBF9">
                        <td colspan="2">
                            本书共有评论<span class="sign"><asp:Label ID="reviewTxt" runat="server"></asp:Label></span>条</td>
                        <td width="284">
                            <a name="allreview" id="allreview" runat="server" target="_blank">查看全部评论</a></td>
                    </tr>
                    <asp:Repeater ID="Repeater2" DataSourceID="ObjectDataSource2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width="200" style="height: 24px">
                                    <%# getStatus((int)Eval("StatusID"))%>
                                    ：<%# Eval("UserName") %></td>
                                <td width="300" style="height: 24px">
                                    最新评论：<%# Eval("postTime") %></td>
                                <td style="height: 24px">
                                    评价等级：<%# getRate((int)Eval("RateID"))%>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <%# Eval("Content")%>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center">
                                        <a href="#addreview">
                                            <img src="images/spot.jpg" width="9" height="9" />发表评论</a></div>
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <a name="addreview"></a>
                <div class="infotwo">
                    <table width="560" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2" width="25">
                                <img src="images/postreviws1.gif" alt="fabu" width="280" height="21" /></td>
                        </tr>
                        <tr>
                            <span>
                                <td colspan="2" style="background-color: #EAEBF9">
                                    发表评论： <a href="login.aspx" id="loginUrl" runat="server" target="_blank">登录评论</a></td>
                            </span>
                        </tr>
                        <tr>
                            <td style="width: 69px">
                                <div align="right">
                                    身份：</div>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="statusList" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="0">读者</asp:ListItem>
                                    <asp:ListItem Value="1">译者</asp:ListItem>
                                    <asp:ListItem Value="2">作者</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="width: 69px; height: 24px;">
                                <div align="right">
                                    姓名：</div>
                            </td>
                            <td style="height: 24px">
                                <label>
                                    &nbsp;<asp:TextBox ID="reviewName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="reviewName"
                                        ErrorMessage="*"></asp:RequiredFieldValidator></label></td>
                        </tr>
                        <tr>
                            <td style="width: 69px; height: 27px;">
                                <div align="right">
                                    星级：</div>
                            </td>
                            <td style="height: 27px">
                                <asp:RadioButtonList ID="rateList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="5">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                                    <asp:ListItem Value="4">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                                    <asp:ListItem Value="3">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                                    <asp:ListItem Value="2">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                                    <asp:ListItem Value="1">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="contentTxt" runat="server" Height="82px" TextMode="MultiLine" Width="384px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="contentTxt"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <label>
                                    <asp:Button ID="addBtn" Style="width: 80px; border-top-style: groove; border-right-style: groove;
                                        border-left-style: groove; height: 24px; border-bottom-style: groove" runat="server"
                                        Text="提交" OnClick="addBtn_Click" />&nbsp;&nbsp; &nbsp;
                                    <asp:TextBox ID="validateNum" runat="server"></asp:TextBox><asp:Image ID="Image1"
                                        runat="server" ImageUrl="~/MarkCode.aspx" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="validateNum"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:Label ID="validateNumTxt" runat="server"></asp:Label></label></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!------------->
        </div>
    &nbsp;
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetBookByID" TypeName="Jiaen.BLL.Book" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="60" Name="bookID" QueryStringField="bookID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetReview" TypeName="Jiaen.BLL.Review">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="rt" Type="Object" />
            <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="bookID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

