<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="downLoad.aspx.cs" Inherits="downLoad" Title="资源下载" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Src="Control/downClass.ascx" TagName="downClass" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <uc1:downClass ID="DownClass1" runat="server" />
            <!----------leftbanner_1-------------------------->
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <div class="right-first">
                <div class="right-first">
                    <div class="fenlei"><b>
                        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                        </asp:SiteMapPath>
                        </b></div> 
                    
                </div>
                <div class="right-second">
                </div>
            </div>
            <div class="bule">
                <div class="newdownload">
                    <h1>资源名称</h1>  <h1>更新时间</h1> <h1>资源大小</h1> 
                    <h1>下载人气</h1>  <h1>软件评价</h1></div>
            </div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="right-download">
                           <h3> <img height="16" src="images/dot.jpg" width="15" /><h1><a href='downLoadInfo.aspx?id=<%# Eval("DownID")%>'><span style="color:#3f87d7;"><span
                                style="font-size:14px;color:#ff9000;text-decoration: none"><%# Eval("DownName")%></span>
                                <span class="s2"></span></span></span></a></h1><h1><%# ((DateTime)Eval("addDate")).ToShortDateString()%></h1>
                          <h1> <%# DataFormat.getSize((int)Eval("size"))%>
                            </h1> 
                            <h1><%# Eval("DownCount")%></h1>
                           <h2> <img alt="" height="12" src="Images/art.gif" width="13" /></h2></h3>
                        <div>
                            <ul class="u1">
                                <%# Eval("Dec")%>
                            </ul>
                           <div class="dotted">
                    </div> 
                        </div>
                        <br />
                    </div>
                    
                </ItemTemplate>
            </asp:Repeater>
            <div class="right-first">
                <p>
                    <span class="foot_r">&nbsp; &nbsp;<cc1:CollectionPager ID="CollectionPager1" runat="server"
                        BackNextLinkSeparator="|" BackNextLocation="Right" BackText="上一页" FirstText="第一页"
                        LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersDisplay="Numbers" PageNumbersSeparator="-"
                        PageSize="10" ResultsLocation="None" ShowFirstLast="False">
                    </cc1:CollectionPager>
                    </span>
                </p>
            </div>
            
            
        </div>
    </div>
    &nbsp;
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    &nbsp;</asp:Content>

