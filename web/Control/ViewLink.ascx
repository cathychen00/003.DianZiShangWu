<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewLink.ascx.cs" Inherits="Control_ViewLink" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetLinks" TypeName="Jiaen.BLL.FriendLink">
    <SelectParameters>
        <asp:Parameter DefaultValue="5" Name="linkType" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetLinks" TypeName="Jiaen.BLL.FriendLink">
    <SelectParameters>
        <asp:Parameter DefaultValue="6" Name="linkType" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
<div class="footer_1">
  <TD height="67" colspan="10" valign="top">
  <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
                                        <ItemTemplate>
                                            &nbsp;&nbsp;<a href='<%# Eval("LinkURL")%>' target="_blank">
                                                <%# Eval("LinkName")%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:Repeater>
  
   </TD>
        <asp:DataList ID="DataList1" CellSpacing=0 CellPadding=0 runat="server" DataSourceID="ObjectDataSource2" RepeatColumns="7" HorizontalAlign="Center">
                                        <ItemTemplate>
                                                <a href='<%# Eval("LinkURL")%>' target="_blank">
                                                    <img height="31" src='<%# Eval("LinkLogo")%>' width="88" border="0"></a>
                                        </ItemTemplate>
                                        <ItemStyle Width="92px" />
                                    </asp:DataList>
    </div>
