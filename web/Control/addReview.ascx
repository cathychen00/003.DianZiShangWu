<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addReview.ascx.cs" Inherits="Control_addReview" %>
<div class="infotwo">
    <table width="560" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="2" width="25">
                <img src="images/postreviws1.gif" alt="fabu" width="280" height="21" /></td>
        </tr>
        <tr>
            <span>
                <td colspan="2" style="background-color: #EAEBF9">
                    发表评论： <a href="login.aspx" id="loginUrl" runat="server">登录评论</a>
                </td>
            </span>
        </tr>
        <tr>
            <td>
                <div align="right">
                    身份：</div>
            </td>
            <td>
                <asp:RadioButtonList ID="statusList" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="0">读者</asp:ListItem>
                    <asp:ListItem Value="1">译者</asp:ListItem>
                    <asp:ListItem Value="2">作者</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    姓名：</div>
            </td>
            <td>
                <label>
                    &nbsp;<asp:TextBox ID="reviewName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="reviewName"
                        ErrorMessage="*"></asp:RequiredFieldValidator></label></td>
        </tr>
        <tr>
            <td style="height: 18px">
                <div align="right">
                    星级：</div>
            </td>
            <td style="height: 18px">
                &nbsp;<asp:RadioButtonList ID="rateList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
    <asp:ListItem Selected="True" Value="5">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                    <asp:ListItem Value="4">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                    <asp:ListItem Value="3">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                    <asp:ListItem Value="2">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
                    <asp:ListItem Value="1">&lt;img src=&quot;images/art.gif&quot; width=&quot;13&quot; height=&quot;12&quot; /&gt;</asp:ListItem>
</asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="contentTxt" runat="server" Height="91px" TextMode="MultiLine" Width="346px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="contentTxt"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2">
                <label>
                    &nbsp;<asp:Button ID="addBtn" runat="server" Text="提交" OnClick="addBtn_Click" />&nbsp;<asp:TextBox
                        ID="validateNum" runat="server"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/MarkCode.aspx" />
                    <asp:Label ID="validateNumTxt" runat="server"></asp:Label></label></td>
        </tr>
    </table>
</div>
