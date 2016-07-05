<%@ Page EnableViewState="false" Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="dynamic.aspx.cs" Inherits="dynamic" Title="站内资讯" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="whole">
    <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <div class="leftbanner_1">
                <fieldset>
                    <legend>
                        <img src="images/import.jpg" width="150" height="40" />
                    </legend>
                    <p>
                      <jiaen:DImageBook id="DImageBook1" runat="server"></jiaen:DImageBook>
                      </p>
                </fieldset>
            </div>
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <div class="right-first">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </div>
            <div class="bule">
                <img src="images/bule.jpg" alt="bule" width="21" height="24" />最新资讯<span> |NETINFORMATION</span>
            </div>
            <div class="right-zixun">
                <ul>
                <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                <li><div class="zixunleft"><a style='<%# Eval("DynamicCss")%>' href='dynamicInfo.aspx?dyID=<%# Eval("DynamicID")%>' title='<%# Eval("DynamicTitle")%>'><%# Eval("DynamicTitle")%></a></div><div class="zixunright">[<%# Eval("AddDate") %>]</div> </li>
                </ItemTemplate>
            </asp:Repeater>
                    &nbsp;
                    </ul>
                <ul>
                </ul>
                <ul>
                    <cc1:collectionpager id="CollectionPager1" runat="server" resultslocation="None" PageSize="10" BackNextLinkSeparator="|" BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-" ShowFirstLast="False" backnextlocation="Right" pagenumbersdisplay="Numbers"></cc1:collectionpager>
                   </ul>
            </div>
            <!--zixun--->
        </div>
    </div>
    </div>
</asp:Content>

