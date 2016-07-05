<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="cheapBook.aspx.cs"  Inherits="cheapBook" Title="特价图书" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <jiaen:cheapnum id="CheapNum1" runat="server"></jiaen:cheapnum>
            <jiaen:cheapTop ID="CheapTop1" runat="server" />
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <jiaen:bookList ID="BookList1" runat="server" Type="cheap" />
            <!---------third---------->
        </div>
        <!-------------------------right------------------------->
    </div>
   </asp:Content>

