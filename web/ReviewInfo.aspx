<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewInfo.aspx.cs" Inherits="ReviewInfo"
    Title="图书评论" %>

<%@ Register Src="Control/Review.ascx" TagName="Review" TagPrefix="uc2" %>
<%@ Register Src="Control/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>图书评论</title>
    <link href="images/cssothers.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="ewhole">
            <div class="ew-title">
                <b><a href="#" target="_blank"></a><span style="color: #3f87d7">&nbsp;&nbsp; </span>
                    <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                    </asp:SiteMapPath>
                </b></div>
            
            
            <div class="bookmain">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetBookByID" TypeName="Jiaen.BLL.Book">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="60" Name="bookID" QueryStringField="bookID"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" EnableViewState="False">
                    <ItemTemplate>
                        <div class="bule">
                            <img alt="bule" height="24" src="images/bule.jpg" width="21" />
                            <%# Eval("BookName")%>
                        </div>
                        <!--topsale--->
                        <div class="right-info">
                            <div class="right-infojpt">
                                <img runat="server" alt='<%# Eval("BookName")%>' height="177" src='<%# Eval("BookImage")%>'
                                    width="136" /></div>
                            <div class="right-infoword">
                                【ISBN】<%# Eval("BookISBN") %><br />
                                【分类】程序设计<br />
                                【出版社】<%# Eval("BookPublish") %><br />
                                【作者】<%# Eval("BookAuthor") %>
                                <br />
                                【阅读数】
                                <%# Eval("ReadCount") %>
                                <br />
                                【页数】
                                <%# Eval("BookPages") %>
                                <br />
                                【库存】
                                <%# getStock((int)Eval("Stock"))%>
                                <br />
                                【出版日期】
                                <%# ((DateTime)Eval("PublishTime")).ToShortDateString() %>
                                【版次】
                                <%# Eval("BookEditions")%>
                                <br />
                                【评价】<%# getRate(Convert.ToInt32(Eval("Rate")))%>
                            <a href="#addreview">参与评论</a> (共<%# Eval("ReviewCount") %>条)<br />
                            </div>
                        </div>
                        <!-----right-info-------->
                        <div>
                            市场价：<%# Eval("Price","{0:c}")%>
                            <span class="ff9clolor">迦恩价：<%# Eval("MemberPrice", "{0:c}")%><br>
                            </span><a href='ShoppingCart.aspx?bookID=<%# Eval("bookID") %>'>
                                <img alt="gou" height="14" src="images/add-to-cart.gif" width="85" /></a>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/user/favBookInfo.aspx?bookID="+Eval("bookID") %>'><img src="images/favorites.gif" alt="shou" width="85" height="14" /></asp:HyperLink></div>

                    </ItemTemplate>
                </asp:FormView>
            </div>
            <!---------------bookmain----------------------->
            <div class="ew-main">
                <uc2:Review ID="Review1" runat="server" />
            </div>
            <!-----------ew-main--------------------------->
            <uc1:footer ID="Footer1" runat="server"></uc1:footer>
        </div>
    </form>
</body>
</html>

