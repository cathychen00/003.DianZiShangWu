<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reviewInfo.aspx.cs" Inherits="user_review" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <cc1:collectionpager id="CollectionPager1" runat="server" BackNextLinkSeparator="" PageSize="5" ResultsLocation="None" SliderSize="3"></cc1:collectionpager>
    <asp:DataList ID="DataList1" runat="server" CellPadding="4" 
        ForeColor="#333333" HorizontalAlign="Center">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <ItemTemplate>
            <br />
            ReviewID:
            <asp:Label ID="ReviewIDLabel" runat="server" Text='<%# Eval("ReviewID") %>'></asp:Label><br />
            Content:
            <asp:Label ID="ContentLabel" runat="server" Text='<%# Eval("Content") %>'></asp:Label><br />
            PostTime:
            <asp:Label ID="PostTimeLabel" runat="server" Text='<%# Eval("PostTime") %>'></asp:Label><br />
            BookID:
            <asp:Label ID="BookIDLabel" runat="server" Text='<%# Eval("BookID") %>'></asp:Label><br />
            <br />
        </ItemTemplate>
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetReview" TypeName="Jiaen.BLL.Review">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="rt" Type="Object" />
            <asp:SessionParameter DefaultValue="" Name="ID" SessionField="userid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

