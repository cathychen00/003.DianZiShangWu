<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true" CodeFile="pwd.aspx.cs" Inherits="pwd" Title="找回密码" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        &nbsp;
    <asp:PasswordRecovery  ID="PasswordRecovery1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="12px" OnSendingMail="PasswordRecovery1_SendingMail">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <SuccessTextStyle Font-Bold="True" ForeColor="#5D7B9D" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        <SubmitButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <UserNameTemplate>
            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; font-size: 12px; color: white;
                                    background-color: #5d7b9d">
                                    是否忘记了您的密码?</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: black;font-size:12px">
                                    要接收您的密码，请输入您的用户名。</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="12px">用户名:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" Font-Size="12px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red;font-size: 12px">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="SubmitButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                        BorderStyle="Solid" BorderWidth="1px" CommandName="Submit" Font-Names="Verdana"
                                        ForeColor="#284775" Height="21px" Text="提交" ValidationGroup="PasswordRecovery1"
                                        Width="38px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </UserNameTemplate>
        <QuestionTemplate>
            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; font-size: 0.9em; color: white;
                                    background-color: #5d7b9d">
                                    标识确认</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: black; font-style: italic">
                                    要接收您的密码，请回答下列问题。</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    用户名:</td>
                                <td>
                                    <asp:Literal ID="UserName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    问题:</td>
                                <td>
                                    <asp:Literal ID="Question" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">答案:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server" Font-Size="0.8em"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="需要答案。" ToolTip="需要答案。" ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="SubmitButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                        BorderStyle="Solid" BorderWidth="1px" CommandName="Submit" Font-Names="Verdana"
                                        Font-Size="12px" ForeColor="#284775" Text="提交" ValidationGroup="PasswordRecovery1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </QuestionTemplate>
        <SuccessTemplate>
            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td style="color: #5D7B9D; font-weight: bold; height: 19px;">
                                    您的密码已发送给您。</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
        <MailDefinition BodyFileName="PasswordRecoveryMail.txt" IsBodyHtml="True">
        </MailDefinition>
    </asp:PasswordRecovery>
   </center>

</asp:Content>



