<%@ Control Language="C#" AutoEventWireup="true" CodeFile="help.ascx.cs" Inherits="Control_help" %>
<div class="help-left">
    <!-------------------------------------------------------------------------->
    
    <!--DWLayoutTable-->
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <HeaderTemplate>
            
        </HeaderTemplate>
        <ItemTemplate>
        <div class="help-first">
            <h1>
                <%# Eval("ClassName") %>
            </h1>
            <ul>
                <asp:Repeater ID="Repeater2" DataSource='<%# getHelp((int)Eval("ClassID")) %>' runat="server">
                    <ItemTemplate>
                        <li><a runat="server" href='<%# "~/help.aspx?classID=" + Eval("ClassID")+"#"+Eval("HelpID") %>'><%# Eval("HelpTitle") %></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <!-------------------------------------------------------------------------->
</div>
<!-----showInfo-main-right----------------------->
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetHelpClass" TypeName="Jiaen.BLL.HelpClass"></asp:ObjectDataSource>
