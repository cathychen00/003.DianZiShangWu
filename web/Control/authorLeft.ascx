<%@ Control Language="C#" AutoEventWireup="true" CodeFile="authorLeft.ascx.cs" Inherits="Control_authorLeft" %>
<div class="leftbanner_2">
    <fieldset>
        <legend>
            <img src="images/zhj.gif" alt="author" width="150" height="40" /></legend>
        <div class="sign">
            <img src="images/sign.gif" alt="sign" width="4" height="20" />
            栏目介绍</div>
        <p>
            《专家顾问》是迦恩的特色栏目之一, “推荐名家”为您展示目前的权威热点名家的名篇及其新作.</p>
        <div class="leftbanner_2">
            <div class="sign">
                <img src="images/sign.gif" alt="sign" width="4" height="20" />
                推荐专家</div>
            
              
<asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="2"
    RepeatDirection="Horizontal">
    <ItemTemplate>
    <ul>
        <li><a target="_blank" href="authorlistinfo.aspx?id=<%# Eval("TeacherID") %>">◆<%# Eval("Name") %></a><br />
        </li>
        </ul>
    </ItemTemplate>
</asp:DataList>
        </div>
    </fieldset>
</div>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetTeacher" TypeName="Jiaen.BLL.Teacher">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>