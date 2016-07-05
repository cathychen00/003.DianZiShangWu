<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="authorlistinfo.aspx.cs" Inherits="authorlistinfo" Title="教师介绍" %>
<%@ Register Src="Control/bookList.ascx" TagName="bookList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <!--主要部分分左右-->
        <!------------left------------------------>
        <div class="main-left">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
        
        <div class="leftbanner_2">
                <fieldset>
                    <legend>
                        <img src="images/zhj.jpg" alt="author" width="150" height="40" /></legend>
                    <div class="authorphoto">
                        <img runat=server src='<%# Eval("Image") %>' width="141" height="107" /></div>
                    <div class="sign">
                        <img src="images/sign.gif" alt="sign" width="4" height="20" />
                        专家自评</div>
                    <p>
                        <%# Eval("smallDec") %></p>
                    <div class="leftbanner_2">
                        <div class="sign">
                            <img src="images/sign.gif" alt="sign" width="4" height="20" />
                            专家简介</div>
                        <p>
                            <%# Eval("Dec") %>
                           </p>
                    </div>
                    <br>
                </fieldset>
            </div>
        </ItemTemplate>
        </asp:Repeater>
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
        <uc2:bookList ID="BookList1" runat="server" Type="Teacher" />
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetTeacherByID" TypeName="Jiaen.BLL.Teacher">
            <SelectParameters>
                <asp:QueryStringParameter Name="teacherID" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <!-------------------------right------------------------->
        
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

