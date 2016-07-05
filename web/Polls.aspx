<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Polls.aspx.cs" Inherits="admin_Polls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="voteRepeater" DataSourceID="ObjectDataSource1" runat="server">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="98%" align="center">
                        <tr>
                            <td height="30" style="padding: 5px;">
                                <span style="font-weight: bold;">
                                    <%# Eval("title")%>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                </form>
                                <form name="voteForm<%# Eval("pollid")%>" action="Vote.aspx?action=result&id=<%# Eval("pollid")%>"
                                    method="post">

                                    <script language="javascript">
			<!--
			function vote<%# Eval("pollid")%>()
			{
				var oForm = document.voteForm<%# Eval("pollid")%>;
				
				window.open("about:blank", "Vote","width=500,height=400,left=0,top=0,scrollbars=1,status=1,resizable=0");
				oForm.target = "Vote";
				oForm.submit();
			}
			//-->
                                    </script>

                                    <%# GetVoteItem((int)Eval("pollid"), Eval("items").ToString(), Eval("ismultiple").ToString())%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="30">
                                <input type="button" name="vote" value="投票" onclick="javascript:vote<%# Eval("pollid")%>();return false;" />
                                &nbsp;&nbsp;
                                <input type="button" visible='<%# Eval("CanView")%>' name="view" value="查看" onclick="window.open(this.url);return false;"
                                    url="Vote.aspx?action=view&id=<%# Eval("pollid")%>" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetPoll" TypeName="Jiaen.BLL.Poll"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>

