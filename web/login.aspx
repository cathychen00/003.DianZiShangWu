<%@ Page MasterPageFile="~/Templete2.master" Language="C#" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="login" Title="用户登录" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Login ID="Login1" runat="server" CreateUserText="注册" CreateUserUrl="userReg.aspx"
        PasswordRecoveryText="忘记密码" FailureText="您的登录尝试不成功">
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="0" width="777" align="center" border="0">
                <tbody>
                    <tr>
                        <td align="center">
                            &nbsp;
                            <table cellspacing="0" cellpadding="0" width="40%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <img src="images/dl.gif" width="149" height="63" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 238px">
                                            <table width="100%" border="0" cellpadding="10" cellspacing="1" bgcolor="#d2d2d2">
                                                <tbody>
                                                    <tr>
                                                        <td align="middle" bgcolor="#ffffff">
                                                            <table cellspacing="5" cellpadding="0" width="90%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td width="56">
                                                                            <div align="right">
                                                                                用户名：</div>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right">
                                                                                密 码：</div>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right">
                                                                                Cookie：</div>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" />&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <font color=red><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></font></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            如果您在公共场所使用，建议不选择此项</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td width="76">
                                                                            <asp:ImageButton CommandName="Login" ID="ImageButton1" ImageUrl="images/bbslogin.gif"
                                                                                runat="server" />
                                                                        </td>
                                                                        <td width="108">
                                                                            <a href="userReg.aspx">
                                                                                <img src="images/bbsreg.gif" width="58" height="20" /></a></td>
                                                                    </tr>
                                                                    <tr valign="top">
                                                                        <td align="right" colspan="3" style="height: 19px">
                                                                            <div align="center">
                                                                                <a href="pwd.aspx" target="_blank">忘记密码</a>&nbsp;</div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br>
                            <br>
                        </td>
                    </tr>
                </tbody>
            </table>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>

