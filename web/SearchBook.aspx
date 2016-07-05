<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true" CodeFile="SearchBook.aspx.cs" Inherits="SearchBook" Title="图书搜索" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="main">
     
        <div class="main-left">
            <jiaen:newAndGood ID="NewAndGood1" runat="server" />
            <jiaen:ViewTopDynamic ID="ViewTopDynamic1" runat="server" />
        </div>
        <div class="main-right">
            <jiaen:bookList ID="BookList1" runat="server" Type="Search" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


