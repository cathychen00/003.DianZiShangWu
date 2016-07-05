<%@ Page EnableViewState="false" Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="dynamicInfo.aspx.cs" Inherits="dynamicInfo" Title="店内动态" %>

<%@ Register Src="Control/ViewDnamicInfo.ascx" TagName="ViewDnamicInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="whole">
        <!--header-->
        <!------------------------------------------------------------------------------------->
        <div class="main">
            <!--主要部分分左右-->
            <div class="main-left">
                <div class="leftbanner_1">
                    <fieldset>
                        <legend>
                            <img src="images/import.gif" width="150" height="40" />
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
                <uc1:ViewDnamicInfo ID="ViewDnamicInfo1" runat="server" />
                
             
            </div>
        </div>
    </div>
</asp:Content>

