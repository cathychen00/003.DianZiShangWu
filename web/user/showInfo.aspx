<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="showInfo.aspx.cs" Inherits="user_showInfo" Title="修改资料" %>

<%@ Register Src="../Control/userLeftMenu.ascx" TagName="userLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="showInfo-main">
        <uc1:userLeftMenu ID="UserLeftMenu1" runat="server" />
        <div class="loginInfo-main-right">
            <br />
            <div class="ff9clolor">
                <img src="../images/usercenter.jpg" width="160" height="50" />欢迎来到迦恩计算机网站中心!</div>
            <table cellspacing="0" cellpadding="0" width="502" border="0" align="left">
                <!--DWLayoutTable-->
                <tbody>
                    <tr>
                        <td width="500" height="24" valign="top">
                            尊敬的<asp:Label ID="userTxt" runat="server" Text="Label"></asp:Label>,您好!欢迎访问迦恩计算机图书网!</td>
                        <td width="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="29" valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/firstlog.jpg">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="150" height="5">
                                    </td>
                                    <td width="163">
                                    </td>
                                    <td width="187">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 21px">
                                    </td>
                                    <td valign="top" style="height: 21px">
                                        <strong class="ff9clolor">修 改 资 料</strong></td>
                                    <td style="height: 21px">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="50" valign="top" style="border-left: #c2c2c2 1px solid; border-right: #c2c2c2 1px solid;">
                            <br />
                            <table id="table6" cellspacing="0" cellpadding="5" width="90%" border="0">
                                <!--DWLayoutTable-->
                                <tbody>
                                    <tr height="40">
                                        <td align="right">
                                            电子邮件地址：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="emailTxt" runat="server" Width="226px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="emailTxt"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr height="40">
                                        <td align="right">
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailTxt"
                                                ErrorMessage="请输入正确的Email格式" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <asp:Label ID="successTxt" runat="server" ForeColor="Red"></asp:Label></td>
                                        <td>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div align="center">
                                <img height="1" src="../images/line.gif" width="304"></div>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 77px">
                            <table width="500" border="0" background="../images/bg_bottom.gif" cellpadding="0"
                                cellspacing="0">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="119" height="29">
                                        &nbsp;</td>
                                    <td width="94" valign="top">
                                        <input id="change" style="width: 80px; border-top-style: ridge; border-right-style: ridge;
                                            border-left-style: ridge; height: 29px; border-bottom-style: ridge" type="submit"
                                            value="确定" name="AddToCart" onserverclick="change_ServerClick" runat="server" /></td>
                                    <td width="81" valign="top">
                                        <input id="Submit1" style="width: 80px; border-top-style: ridge; border-right-style: ridge;
                                            border-left-style: ridge; height: 29px; border-bottom-style: ridge" type="reset"
                                            value="取消" name="AddToCart" /></td>
                                    <td width="206">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="29">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                           
                        </td>
                        <td style="height: 77px">
                        </td>
                    </tr>
                    
                </tbody>
            </table>
             
        </div>
        <!-----showInfo-main-right----------------------->
    </div>
</asp:Content>

