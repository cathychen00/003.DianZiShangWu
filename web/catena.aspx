<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true" CodeFile="catena.aspx.cs" Inherits="catena" Title="规划教材" %>

<%@ Register Src="Control/catena.ascx" TagName="catena" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
        <!--主要部分分左右-->
    
    
        <div class="main-left">
            <uc2:catena ID="Catena1" runat="server" />
            <jiaen:newAndGood ID="NewAndGood1" runat="server" />
            <!----------leftbanner_1-------------------------->
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <jiaen:bookList Type=Catena ID="BookList1" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
</asp:Content>


