<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="downLoadInfo.aspx.cs" Inherits="downLoadInfo" Title="具体下载" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <jiaen:downClass ID="DownClass1" runat="server" />
            <!----------leftbanner_1-------------------------->
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <div class="right-first">
                <div class="right-first">
                    <p>
                        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                        </asp:SiteMapPath>
                        &nbsp;</p>
                </div>
                
    <asp:FormView ID="FormView2" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
                <div class="download_right">
                    <h3 id="softwarename">
                        <img src="images/dot1.gif" width="20" height="20" /><span class="style2"><%# Eval("DownName")%>
                        </span>
                    </h3>
                    <ul>
                        <li>软件评价：<%# DataFormat.getRate((int)Eval("rate")) %>
                        </li>
                        <li class="grid">更新日期：<%# Eval("AddDate") %> </li>
                       
                        <li class="grid">软件大小：<%# DataFormat.getSize((int)Eval("size"))%> </li>
                        <li>下载次数：<%# Eval("DownCount") %> </li>
                       
                        <li class="grid">作者：<%# Eval("Author") %> </li>
                    </ul>
                </div>
            </div>
            <div class="download_right1">
                <h4>
                    <a href='<%# "?downID="+Eval("DownID") %>' target="_blank">下载地址</a>
                    <br>
                </h4>
            </div>
            
            <div class="right-first">
	  <p>&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/description.gif" width="16" height="16" />软件简介:<b>&nbsp;</b><br />
<%# Eval("Dec") %></p>
	  </div>
	  </ItemTemplate>
    </asp:FormView>
        </div>
    </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDownLoadByID" TypeName="Jiaen.BLL.DownLoad">
        <SelectParameters>
            <asp:QueryStringParameter Name="downLoadID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

