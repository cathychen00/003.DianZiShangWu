<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vote.aspx.cs" Inherits="Vote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>查看投票</title>
    <link href="images/cssothers.css" rel="stylesheet" type="text/css" />
</head>
<body>
<asp:Panel ID="allPolls" Runat="server">
<table width="460" align="center" cellpadding="0" cellspacing="0">
<tr>
<td>
	<table width="100%" cellspacing="0" cellpadding="0">
	<tr>
	<td class="tl"></td>
	<td class="tm">
		<span class="tt">所有调查</span>
	</td>
	<td class="tr"></td>
	</tr>
	</table>
	<table width="100%" cellspacing="0" cellpadding="0">
	<tr>
	<td class="ml"></td>
	<td class="mm">
		<table width="100%" cellspacing="1" cellpadding="1">
		<asp:Repeater DataSourceID="ObjectDataSource2" id="allRepeater" runat="server">
			<ItemTemplate>
			<tr>
			<td height="20" class="tdbg-dark">
				<%# Eval("title")%>
				(<a href="?action=view&id=<%# Eval("pollid")%>">查看</a> -
				<span class="time"><%# GetCount(Eval("Num").ToString())%></span> 票)
			</td>
			</tr>
			</ItemTemplate>
		</asp:Repeater>	
		</table>
	</td>
	<td class="mr"></td>
	</tr>
	</table>
	<table width="100%" cellspacing="0" cellpadding="0" >
	<tr>
	<td class="bl" style="height: 19px"></td>
	<td class="bm" style="height: 19px">&nbsp;</td>
	<td class="br" style="height: 19px"></td>
	</tr>
	</table>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="viewPanel" Runat="server">
<table width="460" align="center" cellpadding="0" cellspacing="0">
<tr>
<td>
	<asp:Repeater ID="Repeater2" Runat="server" DataSourceID="ObjectDataSource1">
	<ItemTemplate>
	<table width="100%" cellspacing="0" cellpadding="0">
	<tr>
	<td class="tl"></td>
	<td class="tm">
		<span class="tt">查看调查结果</span>
	</td>
	<td class="tr"></td>
	</tr>
	</table>
	<table width="100%" cellspacing="0" cellpadding="0">
	<tr>
	<td class="ml"></td>
	<td class="mm">
		<span class="summary-title" style="width: 100%;"><%# Eval("title")%></span>
		<%# writeChart(Eval("items").ToString(), Eval("Num").ToString())%>
	</td>
	<td class="mr"></td>
	</tr>
	</table>
	<table width="100%" cellspacing="0" cellpadding="0" >
	<tr>
	<td class="bl"></td>
	<td class="bm">&nbsp;</td>
	<td class="br"></td>
	</tr>
	</table>
	</ItemTemplate>
	</asp:Repeater>
	<div align="center"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
	<div align="center">[ <a href="javascript:window.close();">关闭窗口</a> | <a href="?action=all">所有调查</a> ]</div>
</td></tr>
</table>
</asp:Panel>

<asp:Panel ID="resultPanel" Runat="server">
<div align="center"><asp:Label ID="Label3" runat="server">投票成功,感谢你的参与</asp:Label></div>
	<div align="center">[ <a href="javascript:window.close();">关闭窗口</a> | <a href="?action=all">所有调查</a> ]</div>
</asp:Panel>

<asp:Panel ID="votePanel"  Runat="server">

	<div align="center"><asp:Label ID="Label2" runat="server">请返回首页参与投票</asp:Label></div>
	<div align="center">[ <a href="javascript:window.close();">关闭窗口</a> | <a href="?action=all">所有调查</a> ]</div>

</asp:Panel>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetPollByID" TypeName="Jiaen.BLL.Poll">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="7" Name="pollID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetTopPoll" TypeName="Jiaen.BLL.Poll">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</body>
</html>
