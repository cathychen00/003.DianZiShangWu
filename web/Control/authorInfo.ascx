<%@ Control Language="C#" AutoEventWireup="true" CodeFile="authorInfo.ascx.cs" Inherits="Control_authorInfo" %>
<div class="leftbanner_2">
                <fieldset>
                    <legend>
                        <img src="images/zhj.jpg" alt="author" width="150" height="40" /></legend>
                    <div class="authorphoto">
                        <img src="images/houjie.gif" width="141" height="107" /></div>
                    <div class="sign">
                        <img src="images/sign.gif" alt="sign" width="4" height="20" />
                        专家介简</div>
                    <p>
                        1961.09.28 台湾 台南县 柳营乡 出生
                        <br />
                        1979.09~1983.06 交通大学土木工程系
                        <br />
                        2000.12 第一本亲涉之简体版着作?quot;深入浅出 MFC 2/e&quot;）
                        <br />
                        2000.12 第一篇大陆文章发表<br />
                        2001.05 第一本简体版译本<br />
                        2001.10 第一次赴大陆软件公司讲课<br />
                        2001.10 第一次赴大陆公开演讲<br />
                        讲题：&quot;程序人生&quot;</p>
                    <div class="leftbanner_2">
                        <div class="sign">
                            <img src="images/sign.gif" alt="sign" width="4" height="20" />
                            联络专家</div>
                        <p>
                            网页：http://jjhou.csdn.net/<br />
                            信箱：jjhou@jjhou.com</p>
                    </div>
                    <br>
                </fieldset>
            </div>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetTeacherByID" TypeName="Jiaen.BLL.Teacher">
    <SelectParameters>
        <asp:QueryStringParameter Name="teacherID" QueryStringField="ID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
<ItemTemplate>
<div class="leftbanner_2">
                <fieldset>
                    <legend>
                        <img src="images/zhj.jpg" alt="author" width="150" height="40" /></legend>
                    <div class="authorphoto">
                        <img src='<%# Eval("Image") %>' width="141" height="107" /></div>
                    <div class="sign">
                        <img src="images/sign.gif" alt="sign" width="4" height="20" />
                        教师自评</div>
                    <p><%# Eval("smallDec") %>
                        </p>
                    <div class="leftbanner_2">
                        <div class="sign">
                            <img src="images/sign.gif" alt="sign" width="4" height="20" />
                            教师简介</div>
                        <p>
                            <%# Eval("Dec") %></p>
                    </div>
                    <br>
                </fieldset>
            </div>
</ItemTemplate>
</asp:Repeater>
