<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="ViewDefaultBook.ascx.cs"
    Inherits="Control_ViewDefaultBook" %>
<%@ Register Src="ImageBook.ascx" TagName="ImageBook" TagPrefix="uc1" %>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategory" TypeName="Jiaen.BLL.Category">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="categoryType" Type="Object" />
        <asp:Parameter DefaultValue="0" Name="categoryID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<div class="main-right">
    <!--right-------------------------------------->
    <div class="first">
        <div class="first-01">
            <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
                <ItemTemplate>
                    <b><a href='catBook.aspx?catID=<%# Eval("CategoryID") %>'>■【<%# Eval("CategoryName") %>】
                    </a></b>
                    <asp:Repeater DataSource='<%# dataCategory((int)Eval("CategoryID")) %>' ID="Repeater2"
                        runat="server">
                        <ItemTemplate>
                            <a href='catBook.aspx?catID=<%# Eval("CategoryID") %>'>·<%# Eval("CategoryName") %>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater> &nbsp;&nbsp;<a href="bookclass.aspx">更多...</a>
        </div>
        <div class="first-02">
            <uc1:ImageBook ID="ImageBook1" runat="server" Type="Top" />
        </div>
    </div>
    <!----------------first结尾--------------------->
    <!-------------new开始------------------>
    <div class="wholekuang">
        <!-------------new开始------------------>
        <div class="bookbanner">
            <div class="more">
                <img src="images/more2.gif" width="44" height="13" />
            </div>
        </div>
        <div class="biankuang">
            <asp:Repeater EnableViewState="false" ID="Repeater1" runat="server" DataSourceID="ObjectDataSource2">
                <ItemTemplate>
                    <div class='book1'>
                        <div align="center">
                            <a href='bookinfo.aspx?bookID=<%# Eval("bookID") %>'>
                                <img id="Img1" runat="server" src='<%# Eval("bookSmallImage") %>' width="80" height="110" />
                            </a>
                            <br />
                            <a href='bookinfo.aspx?bookID=<%# Eval("bookID") %>'>
                                <%# Eval("bookName") %>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!-------------new结尾------------------>
    <div class="wholekuang">
        <!-------------精品教材开始------------------>
        <div class="importbanner">
            <div class="more">
                <img src="images/more2.gif" width="44" height="13" />
            </div>
        </div>
        <div class="importbiankuang">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                DataSourceID="ObjectDataSource3">
                <ItemTemplate>
                    <div class="third-1">
                        <div class="third-001">
                            <div align="center">
                                <img id="Img3" runat="server" src='<%# Eval("BookSmallImage") %>' width="80" height="110" /></div>
                        </div>
                        <div class="third-002">
                            <a href='bookInfo.aspx?bookID=<%# Eval("bookID") %>' target="_blank"><strong>
                                <%# Eval("bookName") %>
                            </strong></a>
                            <br />
                            <%# Eval("bookPublish") %>
                            <br>
                            <span class="halfContentRight">
                                <br />
                                市场价：<%# Eval("Price", "{0:c}")%>元 <span class="ff9clolor">
                                    <br />
                                    迦恩价：</span></span><span class="halfContentRight"><span class="ff9clolor"><%# Eval("MemberPrice","{0:c}")%>元</span><br />
                                        <a href='shoppingCart.aspx?bookID=<%# Eval("bookID") %>'>【购买】</a><a href='user/favBookInfo.aspx?bookID=<%# Eval("bookID") %>'>【收藏】</a><br />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <!--------third-1---------->
        
        <!-------------边框结尾------------------>
    </div>
    <!-------------精品教材结尾------------------>
    <!------second放图片-------->
    <div class="first-02">
        <uc1:ImageBook ID="ImageBook2" runat="server" Type="Bottom" />
    </div>
    <!------结束second-------->
    <div class="wholekuang">
        <!------特色教材--------->
        <div class="specialbanner">
            <div class="more">
                <img src="images/more2.gif" width="44" height="13" />
            </div>
        </div>
        <div class="biankuang">
            <asp:Repeater EnableViewState="False" ID="Repeater4" runat="server" DataSourceID="ObjectDataSource5">
                <ItemTemplate>
                    <div class='book1'>
                        <div align="center">
                            <a href='bookinfo.aspx?bookID=<%# Eval("bookID") %>'>
                                <img id="Img1" runat="server" src='<%# Eval("bookSmallImage") %>' width="80" height="110" />
                            </a>
                            <br />
                            <a href='bookinfo.aspx?bookID=<%# Eval("bookID") %>'>
                                <%# Eval("bookName") %>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!------特色教材结尾--------->
    
    
</div>
<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetIndexBook" TypeName="Jiaen.BLL.Book">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetBook" TypeName="Jiaen.BLL.Book">
    <SelectParameters>
        <asp:Parameter DefaultValue="8" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetIndexBook" TypeName="Jiaen.BLL.Book">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetMainPublishs" TypeName="Jiaen.BLL.Publish"></asp:ObjectDataSource>
