<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="catBook.aspx.cs" Inherits="catBook" Title="图书分类" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <div class="leftbanner_1">
                <fieldset>
                    <legend>
                        <img src="images/list.gif" alt="list" width="150" height="40" /></legend>
                    <div class="sign">
                        <img src="images/sign.gif" alt="sign" width="4" height="20" />
                        排序方式</div>
                    <br>
                    ·<a href='?order=0&catID=<% =Request.QueryString["catID"] %>'>编辑推荐</a> ·<a href='?order=1&catID=<% =Request.QueryString["catID"] %>'>上架新书</a>
                    <br>
                    ·<a href='?order=2&catID=<% =Request.QueryString["catID"] %>'>销售排行</a> ·<a href='?order=3&catID=<% =Request.QueryString["catID"] %>'>热评图书</a>
                    <br>
                    ·<a href='?order=4&catID=<% =Request.QueryString["catID"] %>'>特价图书</a> ·<a href='?order=5&catID=<% =Request.QueryString["catID"] %>'>点击次数</a>
                    <br>
                    <div class="sign">
                        <img src="images/sign.gif" alt="sign" width="4" height="20" />
                        重点推荐</div>
                    <div class="Nav">
                        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource2">
                            <ItemTemplate>
                                <a href='bookInfo.aspx?bookID=<%# Eval("bookID") %>' target="_blank">
                                    <img runat="server" src='<%# Eval("bookSmallImage") %>' width="60" height="80" border="0"
                                        align="left"><%# Eval("bookName")%></a><br>
                                <%# Eval("memberprice", "{0:c}")%>
                                元<br>
                                <a href='shoppingCart.aspx?bookID=<%# Eval("bookID") %>'>
                                    <img src="image/add-to-cart.gif" width="80" height="14" border="0" /></a>
                                <div class="z">
                                </div>
                                <hr class="dashedline" size="1">
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="sign">
                            <img src="images/sign.gif" alt="sign" width="4" height="20" />
                            相关分类</div>
                        <br />
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                            <ItemTemplate>
                                ·<a href='<%# "?catID="+Eval("CategoryID") %>'><%# Eval("CategoryName")%></a>
                            </ItemTemplate>
                        </asp:Repeater>
                        <br>
                        &nbsp;<br>
                        <div class="z">
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <jiaen:bookList ID="BookList1" runat="server" Type="catID" />
            <!---------third---------->
        </div>
        <!-------------------------right------------------------->
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetSameCategory" TypeName="Jiaen.BLL.Category">
        <SelectParameters>
            <asp:QueryStringParameter Name="parentID" QueryStringField="catID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetIndexBook" TypeName="Jiaen.BLL.Book">
        <SelectParameters>
            <asp:Parameter DefaultValue="5" Name="type" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

