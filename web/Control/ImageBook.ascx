<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageBook.ascx.cs" Inherits="Control_ImageBook" %>
<asp:Repeater EnableViewState="false" ID="imageRepeater" runat="server">
    <ItemTemplate>
  
        <a runat="server" href='<%# Page.ResolveUrl((string)Eval("linkURL")) %>'>
            <img runat="server" src='<%# Eval("ImageURL") %>' width="170" height="87" /></a>
    </ItemTemplate>
</asp:Repeater>
