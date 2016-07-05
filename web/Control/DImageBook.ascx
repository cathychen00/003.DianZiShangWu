<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DImageBook.ascx.cs" Inherits="Control_DImageBook" %>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <a id="A1" runat="server" href='<%# Page.ResolveUrl((string)Eval("linkURL")) %>'>
            <img id="Img1" runat="server" src='<%# Eval("ImageURL") %>' width="166" height="71" />
        </a>
    </ItemTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetImageBook" TypeName="Jiaen.BLL.ImageBook">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
