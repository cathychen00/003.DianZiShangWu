<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Poll.ascx.cs" Inherits="Control_Poll" %>
<div class="leftbanner_5">
    <fieldset>
        <legend>
            <img src="images/investigate.jpg" /></legend>
        <div class="investigate">
        <asp:Repeater ID="Repeater1" DataSourceID="ObjectDataSource1" runat="server">
        <ItemTemplate>
            <%# Eval("title")%><br>
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
                <br />
                <input type="button" name="vote" value="投票" onclick="javascript:vote<%# Eval("pollid")%>();return false;" />
                &nbsp;&nbsp;
                <input  type="button" runat="server" visible='<%# Eval("CanView")%>' name="view" value="查看" onclick="window.open(this.url, 'Vote','width=500,height=400,left=0,top=0,scrollbars=1,status=1,resizable=0');return false;"
                    url='<%# "Vote.aspx?action=view&id="+Eval("pollid")%>' />
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>
        </div>
    </fieldset>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetTopPoll" TypeName="Jiaen.BLL.Poll">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="type" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
