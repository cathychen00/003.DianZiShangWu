<%@ Control Language="C#" AutoEventWireup="true" CodeFile="downClass.ascx.cs" Inherits="Control_downClass" %>
    <div class="leftbanner_1">
    <fieldset>
        <legend>
            <div align="center">
                <img height="40" src="images/download.jpg" width="150" />
            </div>
        </legend>
        <div class="paihang">
            <div class="infopai">
                <ul>
                   <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                   <ItemTemplate>
                   
                   </ItemTemplate>
    <ItemTemplate>
        <li><a class="bookfont" href='downLoad.aspx?catID=<%# Eval("ID")%>' title='<%# Eval("ClassName")%>'>
            <%# Eval("ClassName")%>
            </a></li>
    </ItemTemplate>
</asp:Repeater>
                </ul>
            </div>
        </div>
    </fieldset>
<fieldset>
        <legend>
            <div align="center">
                <img height="40" src="images/33.jpg" width="150" />
            </div>
        </legend>
        <div class="paihang">
            <div class="infopai">
                <ul>
                   <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource2">
    <ItemTemplate>
        <li><a class="bookfont" title='<%# Eval("DownName")%>' href='downLoadInfo.aspx?ID=<%# Eval("downId")%>' target="_blank"><%# Eval("DownName")%></a></li>
    </ItemTemplate>
</asp:Repeater>
                </ul>
            </div>
        </div>
    </fieldset>
    </div>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetDownClass" TypeName="Jiaen.BLL.DownClass"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetTopDownLoad" TypeName="Jiaen.BLL.DownLoad"></asp:ObjectDataSource>
