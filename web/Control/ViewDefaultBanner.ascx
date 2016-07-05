<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="ViewDefaultBanner.ascx.cs"
    Inherits="Control_View_DefaultBanner" %>
    
<%@ Register Src="Search.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>
<!--header-->
<div class="top">
    <span class="ff9clolor">欢迎来到中国迦恩计算机资源网! </span>
    <img runat=server src="~/images/account.gif" width="16" height="17" /><a href="user/membership.aspx">会员中心</a>
    <img runat=server src="~/images/buycenter.gif" width="18" height="15" /><a href="ShoppingCart.aspx">购物车</a>
    <img runat=server src="~/images/shoucang.gif" width="12" height="12" /><asp:LoginStatus
        ID="LoginStatus1" runat="server" />
    <img runat=server src="~/images/server.gif" width="14" height="13" /><a href="help.aspx">帮助中心</a>
</div>
<div class="header">
    <div class="header-1">
        <div class="logo">
        <Jiaen:SiteImage ImageType="Logo" width="100" height="100" id="SiteImage1" runat="server"></Jiaen:SiteImage>
            <%--<img src="images/logo.jpg" width="100" height="100" />--%>
            </div>
        <div class="banner1">
      <Jiaen:SiteImage width="670" height="50"  ImageType="Ad" id="Ad" runat="server"></Jiaen:SiteImage>
            
            </div>
        <div id="tabsF">
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink20" NavigateUrl="~/default.aspx" runat="server"><span>首页</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink19" NavigateUrl="~/dynamic.aspx" runat="server"><span>店内动态</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink18" NavigateUrl="~/newbook.aspx" runat="server"><span>新书上架</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink17" NavigateUrl="~/topsale.aspx" runat="server"><span>销售排行</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink16" NavigateUrl="~/preview.aspx" runat="server"><span>在线投稿</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink14" NavigateUrl="~/cheapBook.aspx" runat="server"><span>特价图书</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink15" NavigateUrl="~/catena.aspx" runat="server"><span>规划教材</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink13" NavigateUrl="~/authorlist.aspx" runat="server"><span>教师之家</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink12" NavigateUrl="~/downLoad.aspx" runat="server"><span>下载</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink11" NavigateUrl="~/default.aspx" runat="server"><span>有问必答</span></asp:HyperLink></li>
            </ul>
        </div>
        <div class="sort">
            主要分类:<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
            
              |    <asp:HyperLink NavigateUrl='<%#  "~/catBook.aspx?catID="+Eval("categoryID")%>' ForeColor=white ID="HyperLink1" runat="server"><%# Eval("categoryName")%></asp:HyperLink>
         
            </ItemTemplate>
            </asp:Repeater>
            | <a href="http://www.51aspx.com" target="_blank">Asp.net源码下载</a>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LivePortalConnectionString %>"
                SelectCommand="SELECT Top 7 [categoryID], [parentID], [isMain], [categoryName] FROM [je_Category] WHERE (([parentID] = @parentID) AND ([isMain] = @isMain))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="parentID" Type="Int32" />
                    <asp:Parameter DefaultValue="true" Name="isMain" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="header-2">
        <div class="banner2">
            <Jiaen:SiteImage width="770" height="150"  ImageType="banner" id="SiteImage2" runat="server"></Jiaen:SiteImage></div>
        <uc1:Search ID="Search1" runat="server" />
    </div>
</div>
