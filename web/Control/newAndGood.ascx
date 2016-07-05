<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="newAndGood.ascx.cs" Inherits="Control_newAndGood" %>
<div class="leftbanner_1">
    <fieldset>
        <legend>
            <img src="images/key_new.jpg" /><!----------------------重点新书----->
        </legend>
        <div class="Nav">
 <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
<ItemTemplate>
<a href='bookInfo.aspx?bookID=<%# Eval("bookID") %>' target="_blank">
                <img runat="server" src='<%# Eval("bookSmallImage") %>' width="60" height="80" border="0" align="left"><%# Eval("bookName") %></a><br>
            <%# Eval("MemberPrice","{0:c}") %>元<br>
            <a href='shoppingCart.aspx?bookID=<%# Eval("bookID") %>'>
                <img src="image/add-to-cart.gif" width="80" height="14" border="0" /></a>
            <div class="z">
            </div>
            <hr class="dashedline" size="1">
</ItemTemplate>
</asp:Repeater>
            <div class="z">
            </div>
        </div>
    </fieldset>
</div>

<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetIndexBook" TypeName="Jiaen.BLL.Book">
    <SelectParameters>
        <asp:Parameter DefaultValue="5" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
