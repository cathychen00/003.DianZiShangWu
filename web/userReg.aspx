<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="userReg.aspx.cs" Inherits="userReg" Title="会员注册" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div class="reginfo">
                <img src="images/usercenter.jpg" width="160" height="50" /><span class="ff9clolor">您必须同意遵守以下的条款才能进行注册，请仔细阅读下列条款：</span>
            </div>
            <div class="reg-main">
                <label>
                    <div align="center">
                        <textarea name="ServiceTxt" cols="100" rows="30" id="ServiceTxt" runat="server" enableviewstate="false"></textarea>
                    </div>
                </label>
                <br>
                <div class="reg-button" align="center">
                    <input id="agree" style="width: 80px; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; height: 29px; border-bottom-style: ridge"
                        type="submit"
                        value="我同意" name="agree" onserverclick="agree_ServerClick" runat="server" />
                    <input id="unagree" style="width: 80px; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; height: 29px; border-bottom-style: ridge"
                        type="submit"
                        value="我不同意" name="unagree" runat="server" onserverclick="unagree_ServerClick" />
                </div>
            </div>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <div class="register-01">
                <img src="images/Reg_02.jpg" width="121" height="50" />（带为<font color="red">☆</font>必填项）
            </div>
            <div class="register-02">
                <p>
                    <br>
                    &nbsp;&nbsp;&nbsp;用户名：<font color="red">☆</font>
                    <input type="text" name="userTxt" id="userTxt" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="userTxt"
                        ErrorMessage="*"></asp:RequiredFieldValidator>6-16个字符( 包括小写字母、数字)&nbsp;<br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="userTxt"
                        ErrorMessage="*" ValidationExpression="^[a-zA-Z][a-zA-Z0-9_]{4,15}$"></asp:RegularExpressionValidator><br />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" value="检查会员名是否可用" name="check_username" id="btnCheckName" runat="server"
                        onserverclick="btnCheckName_ServerClick" />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
                    <br />
                    <br />
                    <div id="Div7" inherits="HintMsg">
                    </div>
                    </p>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <br>
            <div class="reginfo">
                <img src="images/Reg_03.jpg" width="102" height="52" />（带为<font color="red">☆</font>必填项）
            </div>
            <div>
                <p>
                    <br>
                    <table id="table6" cellspacing="0" cellpadding="5" width="700" border="0">
                        <tbody>
                            <tr height="28">
                                <td align="right" width="140" style="height: 28px">密码：<font color="red">☆</font></td>
                                <td width="230" style="height: 28px">
                                    <input id="password" tabindex="2" type="password" maxlength="16" name="password"
                                        runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="password"
                                        ErrorMessage="*" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator></td>
                                <td width="330" style="height: 28px">
                                    <div id="password_info">
                                        <div id="div" inherits="HintMsg">
                                            密码由6-16个英文字母、数字或符号组成。
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr height="28">
                                <td align="right">再次输入密码：<font color="red">☆</font></td>
                                <td width="200">
                                    <input id="confirm_password" tabindex="3" type="password" maxlength="16" name="confirm_password"
                                        vlaue="" runat="server">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="confirm_password"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="confirm_password"
                                        ErrorMessage="*" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="confirm_password"
                                        ControlToValidate="password" ErrorMessage="两次密码输入必须相同"></asp:CompareValidator></td>
                                <td>
                                    <div id="confirm_password_info">
                                        <div id="div2" inherits="HintMsg">
                                            请再输入一遍您上面输入的密码。
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr height="28">
                                <td align="right">提示问题：<font color="red">☆</font></td>
                                <td>
                                    <select id="question" style="font-size: 9pt; width: 172px; font-face: simsun" tabindex="4"
                                        name="question" runat="server">
                                        <option value="母亲的名字">母亲的名字</option>
                                        <option value="爷爷的名字">爷爷的名字</option>
                                        <option value="父亲出生的城市">父亲出生的城市</option>
                                        <option value="您其中一位老师的名字">您其中一位老师的名字</option>
                                        <option value="您个人计算机的型号">您个人计算机的型号</option>
                                        <option value="您最喜欢的餐馆名称">您最喜欢的餐馆名称</option>
                                        <option value="驾驶执照的最后四位数字">驾驶执照的最后四位数字</option>
                                    </select>
                                    <span id="question_mark"></span>
                                </td>
                                <td>
                                    <div id="question_info">
                                        <div id="div3" inherits="HintMsg">
                                            您可以选择一个问题作为找回密码的提示。
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr height="55">
                                <td align="right">答案：<font color="red">☆</font></td>
                                <td>
                                    <input id="answer" style="width: 172px" tabindex="5" maxlength="20" name="answer"
                                        runat="server">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="answer"
                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td>
                                    <div id="answer_info">
                                        <div id="div4" inherits="HintMsg">
                                            请输入提示问题答案，在密码丢失之后您可以通过[找回密码]
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr height="40">
                                <td align="right">电子邮件地址：<font color="red">☆</font></td>
                                <td>
                                    <input id="email" tabindex="9" maxlength="50" name="email" vlaue="" runat="server">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="email"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:Label ID="DuplicateEmailTxt" runat="server" ForeColor="Red"></asp:Label>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
                                        ErrorMessage="请注意emial地址格式" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                <td>
                                    <div id="email_info">
                                        请正确的输入您常用的电子邮件地址。
                                    </div>
                                </td>
                            </tr>
                            <tr height="28">
                                <td align="right">验证码：<font color="red">☆</font></td>
                                <td>
                                    <table cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="height: 22px">
                                                    <input id="validateNum" tabindex="10" name="validateNum" runat="server"></td>
                                                <td width="5" style="height: 22px">
                                                    <td style="height: 22px">
                                                        <img src="MarkCode.aspx" width="63" height="22" /></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="validateNum"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:Label ID="validateNumTxt" runat="server" ForeColor="Red"></asp:Label></td>
                                <td>
                                    <div id="validateNum_info">
                                        <div id="div6" inherits="HintMsg">
                                            请输入验证码。
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div id="Div1" inherits="HintMsg">
                        <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1"></b></b>
                    </div>
            </div>
            <br />
            <center>
                <input id="change" style="width: 80px; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; height: 29px; border-bottom-style: ridge"
                    type="submit"
                    value="下一步" name="AddToCart" onserverclick="change_ServerClick" runat="server" />&nbsp;
                <input id="Submit1" style="width: 80px; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; height: 29px; border-bottom-style: ridge"
                    type="reset"
                    value="重新填写" name="AddToCart" onserverclick="change_ServerClick" runat="server" /></center>
            <br />
        </asp:View>
        <asp:View ID="View3" runat="server">
            <br>
            <div class="register-01">
                <img src="images/reg-04.jpg" width="160" height="50" />
            </div>
            <div class="RoundedCorner">
                <p>
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
                    <br>
                    <table id="table1" cellspacing="0" cellpadding="5" width="700" border="0">
                        <!--DWLayoutTable-->
                        <tbody>
                            <tr height="28">
                                <td width="68" height="34">&nbsp;</td>
                                <td colspan="3" align="center" valign="top" class="ff9clolor">恭喜您已经成为迦恩网络书店会员</td>
                                <td width="212">&nbsp;</td>
                            </tr>
                            <tr height="29">
                                <td height="35" colspan="2" align="right"></td>
                                <td width="257">[<a href="default.aspx">返回首页</a>]</td>
                                <td colspan="2">
                                    <!--DWLayoutEmptyCell-->
                                    &nbsp;</td>
                            </tr>
                            <tr height="28">
                                <td height="34" colspan="2" align="right">
                                    <!--DWLayoutEmptyCell-->
                                    &nbsp;</td>
                                <td></td>
                                <td colspan="2">
                                    <!--DWLayoutEmptyCell-->
                                    &nbsp;</td>
                            </tr>
                            <tr height="28">
                                <td height="34">&nbsp;</td>
                                <td width="61">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td width="52">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                    <div id="Div5" inherits="HintMsg">
                        <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1"></b></b>
                    </div>
            </div>
            <br />
            <div align="center">
                <input id="returnIndex" style="width: 80px; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; height: 29px; border-bottom-style: ridge"
                    type="submit"
                    value="返回" name="returnIndex" onserverclick="returnIndex_ServerClick" runat="server" />
            </div>
            <br />
            <br />
        </asp:View>
    </asp:MultiView><br />
</asp:Content>

