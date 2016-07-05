<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="bookclass.aspx.cs" Inherits="bookclass" Title="图书分类" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="OutBox">      
    <div class="fenlei"><b><a href="#" target="_blank"></a>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </b>&nbsp;</div> 
        <div class="ContentBlocksContainer">
            <table id="Table1" cellspacing="0" cellpadding="0" width="95%" border="0">
                <tbody>
                    <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
                        <ItemTemplate>
                            <tr class="firsttd">
                                <td  colspan="4">
                                <img src="images/bule.jpg" alt="bule" width="21" height="24" />
                                    <b><a href='catBook.aspx?catID=<%# Eval("CategoryID") %>' target="_blank">
                                        <%# Eval("CategoryName") %>
                                        ：</a></b></td>
                            </tr>
                            </a></b>
                            <asp:Repeater DataSource='<%# dataCategory((int)Eval("CategoryID")) %>' ID="Repeater2"
                                runat="server">
                                <ItemTemplate>
                                    <td class="ali lightmenu2">
                                        <a href='catBook.aspx?catID=<%# Eval("CategoryID") %>' target="_blank">
                                            <%# Eval("CategoryName") %>
                                        </a>
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCategory" TypeName="Jiaen.BLL.Category">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="categoryType" Type="Object" />
            <asp:Parameter DefaultValue="0" Name="categoryID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

