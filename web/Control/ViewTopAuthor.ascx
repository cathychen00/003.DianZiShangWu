<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTopAuthor.ascx.cs" Inherits="Control_ViewTopAuthor" %>
<div class="leftbanner_1">
        <!--专家顾问-->
        <fieldset>
            <legend>
                <img src="images/zhj.jpg" />
            </legend>
             <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
                        <asp:Repeater ID="Repeater4" runat="server" DataSourceID="ObjectDataSource1">
                            <ItemTemplate>
                                <tr>
                                    <td width="9">
                                    <td width="9">
                                        <div align="center">
                                            <img height="9" src="images/senior.gif" width="9"></div>
                                    </td>
                                    <td>
                                        <a class="bookfont" title='<%# Eval("Name") %>' href="authorlistinfo.aspx?id=<%# Eval("TeacherID") %>" target="_blank">
                                            <%# Eval("Name") %>
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
    SelectMethod="GetTeacher" TypeName="Jiaen.BLL.Teacher">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>