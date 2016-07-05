<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewDynamic.ascx.cs" Inherits="Control_ViewDynamic" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>

<%@ Register Src="Poll.ascx" TagName="Poll" TagPrefix="uc5" %>
<%@ Register Src="ViewTopAuthor.ascx" TagName="ViewTopAuthor" TagPrefix="uc4" %>
<%@ Register Src="ViewTopDynamic.ascx" TagName="ViewTopDynamic" TagPrefix="uc3" %>
<%@ Register Src="ViewTopDown.ascx" TagName="ViewTopDown" TagPrefix="uc2" %>
<%@ Register Src="ViewTopBook.ascx" TagName="ViewTopBook" TagPrefix="uc1" %>

<!--主要部分分左右-->
<div class="main-left">
<uc3:ViewTopDynamic ID="ViewTopDynamic1" runat="server" />
    <uc1:ViewTopBook ID="ViewTopBook1" runat="server" />
    <uc2:ViewTopDown ID="ViewTopDown1" runat="server" />
    <uc4:ViewTopAuthor ID="ViewTopAuthor1" runat="server" />

<uc5:Poll ID="Poll1" runat="server" />
</div>
<!-------------------------------------------------------------------------------------------------->





