<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Review.ascx.cs" Inherits="Control_Review" %>
<%@ Register Src="addReview.ascx" TagName="addReview" TagPrefix="uc1" %>
<%@ Register Assembly="Jiaen.Controls" Namespace="SiteUtils" TagPrefix="cc1" %>
<div class="ew-main">
    <table width="750" cellspacing="1" cellpadding="0" align="center">
        <tr>
            <td height="30" colspan="3">
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator="|"
                    BackNextLocation="Right" BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页"
                    NextText="下一页" PageNumbersDisplay="Numbers" PageNumbersSeparator="-" PageSize="10"
                    ResultsLocation="None" ShowFirstLast="False">
                </cc1:CollectionPager>
            </td>
        </tr>
        
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td height="24">
                        <div align="center">
                            <a href="#addreview">
                                <img src="images/spot.jpg" width="9" height="9" />发表评论</a></div>
                    </td>
                    <td colspan="2" height="24">
                        </td>
                </tr>
                <tr>
                    <td height="24" align="center" width="150">
                        <%# getStatus((int)Eval("StatusID"))%>
                        ：<%# Eval("userName")%></td>
                    <td width="155">
                        评价等级：
                        <%# getRate((int)Eval("RateID"))%></td>
                    <td valign="top">
                        最新评论：<%# Eval("PostTime")%></td>
                </tr>
                <tr>
                    <td height="72" colspan="3" valign="top">
                        <%# Eval("Content")%>
                        <br />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <a name="addreview"></a>
    <uc1:addReview ID="AddReview1" runat="server" />
</div>
