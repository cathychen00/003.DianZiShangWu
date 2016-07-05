<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cheapTop.ascx.cs" Inherits="Control_cheapTop" %>
<%@ Import Namespace="Jiaen.Components.Utility" %>
<div class="leftbanner_2">
    <div align="center">
        <fieldset>
            <legend>
                <img src="images/tejia.jpg" width="150" height="40" />
            </legend>  
    
        <div class="paihang">
                <ul class="divDndt">
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource2">
                        <ItemTemplate>
                            <li><a class="bookfont" title='<%# Eval("bookName") %>' href="index.htm" target="_blank">
                                <%# StringHelper.subStr(20,(string)Eval("bookName"))%>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
        </div>
   </fieldset>
   </div>
</div>
<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCheapTopBook" TypeName="Jiaen.BLL.Book"></asp:ObjectDataSource>
