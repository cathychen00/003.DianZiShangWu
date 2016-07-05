<%@ Page MasterPageFile="~/Templete2.master" Language="C#" AutoEventWireup="true"
 CodeFile="newbook.aspx.cs" Inherits="newbook" Title="新书上架" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <div class="main">
     
        <div class="main-left">
            <jiaen:newAndGood ID="NewAndGood1" runat="server" />
            <jiaen:ViewTopDynamic ID="ViewTopDynamic1" runat="server" />
        </div>
        <div class="main-right">
            <jiaen:bookList ID="BookList1" runat="server" Type="newBook" />
        </div>
    </div>
   </asp:Content>

