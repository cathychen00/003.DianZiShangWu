<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTopDown.ascx.cs" Inherits="Control_ViewTopDown" %>
<div class="leftbanner_1">
        <!--资源下载-->
        <fieldset>
            <legend>
                <img src="images/33.jpg" />
            </legend>
             <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
                        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource1">
                            <ItemTemplate>
                                <tr>
                                    <td width="9">
                                    <td width="9">
                                        <div align="center">
                                            <img height="9" src="images/senior.gif" width="9"></div>
                                    </td>
                                    <td>
                                        <a class="bookfont" title='<%# Eval("DownName")%>' href='downLoadInfo.aspx?ID=<%# Eval("downId")%>' target="_blank">
                                            <%# Eval("DownName")%>
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
    SelectMethod="GetTopDownLoad" TypeName="Jiaen.BLL.DownLoad">
</asp:ObjectDataSource>
