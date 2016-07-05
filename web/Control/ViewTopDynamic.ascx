<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="ViewTopDynamic.ascx.cs"
    Inherits="Control_ViewTopDynamic" %>
<div class="leftbanner_1">
    <!--站内资讯-->
    <fieldset>
        <legend>
            <img src="images/in.jpg" />
        </legend>
        <table cellspacing="0" cellpadding="3" width="100%" border="0">
            <tbody>
                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
                    <ItemTemplate>
                        <tr>
                            <td width="9">
                            <td width="9">
                                <div align="center">
                                    <img height="9" src="images/senior.gif" width="9"></div>
                            </td>
                            <td>
                                <a class="bookfont" title='<%# Eval("DynamicTitle")%>' href='dynamicInfo.aspx?dyID=<%# Eval("DynamicID")%>' target="_blank">
                                    <%# Eval("DynamicTitle")%>
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </fieldset>
</div>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetSiteDynamic" TypeName="Jiaen.BLL.SiteDynamic">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
