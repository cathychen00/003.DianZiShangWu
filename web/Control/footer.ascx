<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="footer.ascx.cs"
    Inherits="Control_footer" %>
    <%@ OutputCache Duration="60" VaryByParam="none" %>
<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>

<div class="footer_2">
    <div class="db_f_i">
        <table cellspacing="0" cellpadding="0" width="757" border="0">
            <tbody>
                <tr>
                    <td class="toptd" colspan="5">
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <cite><a href='<%# "help.aspx?classID="+Eval("ClassID")%>'>
                                    <%# Eval("ClassName")%>
                                </a></cite>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
                        
                        <ItemTemplate>
                            <asp:Repeater ID="Repeater2" runat="server" DataSource='<%# getHelp((int)Eval("ClassID")) %>'>
                                <HeaderTemplate>
                            <td style="border-right: #ccc 1px dotted" width="153">
                        </HeaderTemplate>
                                <ItemTemplate>
                                    <p>
                                      <a id="A1" runat="server" href='<%# "~/help.aspx?classID=" + Eval("ClassID")+"#"+Eval("HelpID") %>'><%# Eval("HelpTitle") %></a>
                                    </p>
                                </ItemTemplate>
                           <FooterTemplate>
                            </td>
                        </FooterTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                        
                    </asp:Repeater>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<div class="footer_3">
    <jiaen:ServiceLabel id="ServiceLabel1" runat="server">
    </jiaen:ServiceLabel><a href="http://www.51aspx.com" target="_blank">download from 51aspx.com</a>
</div>
<div class="bottom">
</div>
<%--<div class="bottom">
</div>--%>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetMainHelpClass" TypeName="Jiaen.BLL.HelpClass"></asp:ObjectDataSource>