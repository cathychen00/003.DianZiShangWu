<%@ Control Language="C#" AutoEventWireup="true" CodeFile="catena.ascx.cs" Inherits="Control_catena" %>
<div class="leftbanner_1">
    <fieldset>
        <legend>
            <div align="center">
                <img height="40" src="images/download.jpg" width="150" />
            </div>
        </legend>
        <div class="paihang">
            <div class="infopai">
                <ul>
                   <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                   <ItemTemplate>
                   
                   </ItemTemplate>
    <ItemTemplate>
        <li><a class="bookfont" href='Catena.aspx?ID=<%# Eval("CatenaID")%>' title='<%# Eval("CatenaName")%>'>
            <%# Eval("CatenaName")%>
            </a></li>
    </ItemTemplate>
</asp:Repeater>
                </ul>
            </div>
        </div>
    </fieldset>
    </div>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCatenas" TypeName="Jiaen.BLL.BookCatena"></asp:ObjectDataSource>