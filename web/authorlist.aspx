<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="authorlist.aspx.cs" Inherits="authorlist" Title="教师之家" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <jiaen:authorLeft ID="AuthorLeft1" runat="server" />
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <div class="right-first">
                <b>
                    <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                    </asp:SiteMapPath>
                </b>
            </div>
            <div class="bule">
                <img src="images/bule.jpg" alt="bule" width="21" height="24" />人物索引<span> |AUTHORLIST</span>
            </div>
            <!-------------------------------------------------------------------------------------->
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="right-auth">
                        <div class="authjpg">
                            <a href='authorlistinfo.aspx?id=<%# Eval("teacherId")%>'>
                                <%# Eval("Name")%>
                                <img id="Img1" runat="server" src='<%# Eval("Image")%>' width="80" height="80" /></a></div>
                        <div class="authword">
                            【作品】：
                            <asp:Repeater ID="Repeater2" DataSource='<%# getTop((int)Eval("teacherId"))%>' runat="server">
                                <ItemTemplate>
                                    《<a href='bookinfo.aspx?bookID=<%# Eval("bookID") %>' target="_blank"><%# Eval("bookName") %></a>》
                                </ItemTemplate>
                                <FooterTemplate>
                                    ...
                                </FooterTemplate>
                            </asp:Repeater>
                            <br>
                            【简介】:<%# Eval("smallDec") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="auth-second">
                <p>
                    <jiaen:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator="|"
                        BackNextLocation="Right" BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页"
                        NextText="下一页" PageNumbersDisplay="Numbers" PageNumbersSeparator="-" PageSize="5"
                        ResultsLocation="None" ShowFirstLast="False">
                    </jiaen:CollectionPager>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

