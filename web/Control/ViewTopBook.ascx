<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTopBook.ascx.cs" Inherits="Control_ViewTopBook" %>
<%@ Import Namespace="Jiaen.Components.Utility" %>
    <div class="leftbanner_1">
        <!--畅销排行-->
        <fieldset>
            <legend>
                <img src="images/changxiao.jpg" />
            </legend>
             <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                            <ItemTemplate>
                                <tr>
                                    <td width="9">
                                    <td width="9">
                                        <div align="center">
                                            <img height="9" src="images/senior.gif" width="9"></div>
                                    </td>
                                    <td>
                                        <a class="bookfont" title='<%# Eval("bookName")%>' href='bookinfo.aspx?bookID=<%# Eval("bookID")%>' target="_blank">
                                            <%# StringHelper.subStr(20,(string)Eval("bookName"))%>
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
    SelectMethod="GetIndexBook" TypeName="Jiaen.BLL.Book">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="type" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>