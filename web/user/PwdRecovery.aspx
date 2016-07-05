<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true" CodeFile="PwdRecovery.aspx.cs" Inherits="user_PwdRecovery" Title="修改密码" %>

<%@ Register Src="../Control/userLeftMenu.ascx" TagName="userLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
                        <td width="500" height="48">&nbsp;</td>
                        <td width="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="29" valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/firstlog.jpg">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="127" height="1"></td>
                                    <td width="186"></td>
                                    <td width="187"></td>
                                </tr>
                                <tr>
                                    <td height="24"></td>
                                    <td valign="top" class="ff9clolor">
                                        <div align="center"><strong class="ff9clolor">修　改　密　码</strong></div>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td height="3"></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td height="1"></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <!--DWLayoutTable-->
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td height="1"></td>
                        <td></td>
                    </tr>


                    <tr>
                        <td height="192" valign="top" style="border-left: #c2c2c2 1px solid; border-right: #c2c2c2 1px solid;">
                            <br />
                            <table cellspacing="0" cellpadding="0" width="90%" align="center"
                                border="0">
                                <!--DWLayoutTable-->

                                <tbody>
                                    <tr>
                                        <td height="35" colspan="2" valign="top">旧密码:</td>
                                        <td colspan="2" valign="top">&nbsp;<asp:TextBox ID="oldPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldPasswordTxt"
                                                ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td height="38" colspan="2" valign="top">新密码:</td>
                                        <td colspan="2" valign="top">&nbsp;<asp:TextBox ID="newPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="newPasswordTxt"
                                                ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td height="26" colspan="2" valign="top">重新输入密码:</td>
                                        <td colspan="2" valign="top">&nbsp;<asp:TextBox ID="newPasswordTxt2" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="newPasswordTxt2"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newPasswordTxt"
                                                ControlToValidate="newPasswordTxt2" ErrorMessage="密码输入必须相同"></asp:CompareValidator></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="26" valign="top"></td>
                                        <td colspan="2" valign="top">
                                            <asp:Label ID="successTxt" runat="server" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="128" height="21">&nbsp;</td>
                                        <td width="4">&nbsp;</td>
                                        <td width="105"></td>
                                        <td width="211"></td>
                                    </tr>
                                    <tr>
                                        <td height="29">&nbsp;</td>
                                        <td colspan="2" valign="top">
                                            <div align="center">
                                                <input id="change" style="width: 80px; height: 29px; border-bottom-style: ridge" type="submit" value="确定" onserverclick="change_ServerClick" runat="server" />
                                            </div>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="21">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                            </table>
                            <div align="center">
                                <img height="1"
                                    src="../images/line.gif" width="304">
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>

                    <tr>
                        <td height="58" valign="top">
                            <table width="500" border="0" background="../images/bg_bottom.gif" cellpadding="0" cellspacing="0">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="496" style="height: 58px">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td height="11"></td>
                        <td></td>
                    </tr>
                </tbody>
            </table>

        </div>
        <!-----showInfo-main-right----------------------->
    </div>
</asp:Content>


