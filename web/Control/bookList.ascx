<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="bookList.ascx.cs" Inherits="Control_bookList" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="SiteUtils" TagPrefix="cc1" %>
 <div class="right-first">
                <b><asp:SiteMapPath
                    ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
                </b></div>
<div class="third">
<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
<ItemTemplate>
    <div class="third-1">
        <div class="third-001">
            <div align="center">
                <img runat="server" src='<%# Eval("BookSmallImage") %>' width="80" height="110" /></div>
        </div>
        <div class="third-002">
            <a href='bookInfo.aspx?bookID=<%# Eval("bookID") %>' target="_blank"><strong><%# Eval("bookName") %></strong></a><br />
            <%# Eval("bookPublish") %><br>
            <span class="halfContentRight">
                <br />
                市场价：<%# Eval("Price", "{0:c}")%>元 <span class="ff9clolor">
                    <br />
                    迦恩价：</span></span><span class="halfContentRight"><span class="ff9clolor"><%# Eval("MemberPrice","{0:c}")%>元</span><br />
                        <a href='shoppingCart.aspx?bookID=<%# Eval("bookID") %>'>【购买】</a><a
                             href='user/favBookInfo.aspx?bookID=<%# Eval("bookID") %>'>【收藏】</a><br />
        </div>
    </div>
</ItemTemplate>
</asp:DataList><%-- <div class="third-0">
        <div class="third-01">
            <div align="center">
                <img src="image/TS00122919__.jpg" width="80" height="134" /></div>
        </div>
        <div class="third-02">
            <p>
                <a href=" " target="_blank"></a><strong>NET compact FrameWork移动开发指南</strong><br>
                清华大学出版社<br>
                <span class="halfContentRight">
                    <br />
                    市场价：63元 <span class="ff9clolor">
                        <br>
                        迦恩价:</span></span><span class="halfContentRight"><span class="ff9clolor">49.14元</span><br />
                            <a onclick="window.open('/addtocart.aspx?pno=TS00122919','dd','')" href=" ">【购买】【收藏</a></span><a
                                onclick="window.open('/addtocart.aspx?pno=TS00122919','dd','')" href=" ">】</a></p>
        </div>
    </div>
    <!-------------third-0---------->
    <div class="third-1">
        <div class="third-001">
            <div align="center">
                <img src="image/TS00122919__.jpg" width="80" height="134" /></div>
        </div>
        <div class="third-002">
            <a href=" " target="_blank">.<strong>NET compact FrameWork移动开发指南</strong></a><br />
            清华大学出版社<br>
            <span class="halfContentRight">
                <br />
                市场价：63元 <span class="ff9clolor">
                    <br />
                    迦恩价:</span></span><span class="halfContentRight"><span class="ff9clolor">49.14元</span><br />
                        <a onclick="window.open('/addtocart.aspx?pno=TS00122919','dd','')" href=" ">【购买】【收藏</a></span><a
                            onclick="window.open('/addtocart.aspx?pno=TS00122919','dd','')" href=" ">】</a><br />
        </div>
    </div>--%><!--------third-1----------><%--<div class="dotted">--%>
        <div class="right-second">
        <cc1:collectionpager id="CollectionPager1" runat="server" resultslocation="None" PageSize="10" BackNextLinkSeparator="|" BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-" ShowFirstLast="False" backnextlocation="Right" pagenumbersdisplay="Numbers"></cc1:collectionpager>
        <br />
        
    </div>
    <!----------------------------------------------------------------------------------->
    <!-------------third-0---------->
    <!--------third-1---------->
    <!------------------------------------->
    <!-------------third-0---------->
    <!--------third-1---------->
    <!---------------------------------------------------->
</div>

