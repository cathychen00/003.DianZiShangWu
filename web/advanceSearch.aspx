<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true" CodeFile="advanceSearch.aspx.cs" Inherits="advanceSearch" Title="高级搜索" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center">
        <tr>
            <td style="width: 100px">
                书名:</td>
            <td colspan="2">
                <asp:TextBox ID="bookName" runat="server" Width="198px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                作者:</td>
            <td colspan="2">
                <asp:TextBox ID="bookAuthor" runat="server" Width="199px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                出版社:</td>
            <td colspan="2">
                <asp:TextBox ID="bookPublish" runat="server" Width="199px"></asp:TextBox></td>
        </tr>
      <tr>
            <td style="width: 100px">
                图书分类:</td>
            <td colspan="2">
                <jiaen:AllCategoryDropDownList AppendDataBoundItems="true" ID="bookCategory" runat="server">
                
                </jiaen:AllCategoryDropDownList></td>
        </tr>
      <tr>
            <td style="width: 100px">
                出版日期:</td>
            <td colspan="2">
            
                <jiaen:AllYearDropDownList ID="publishYear" runat="server" AppendDataBoundItems="True">
                
                </jiaen:AllYearDropDownList>年
                <jiaen:MonthDropDownList ID="publishMonth" runat="server" AppendDataBoundItems="True">
               
                </jiaen:MonthDropDownList>月</td>
        </tr>
        <tr>
            <td style="width: 100px">
                ISBN:</td>
            <td colspan="2">
                <asp:TextBox ID="bookISBN" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                价格:</td>
            <td colspan="2">
                <asp:DropDownList ID="operatorList" runat="server">
                    <asp:ListItem Value="1">大于</asp:ListItem>
                    <asp:ListItem Value="2">等于</asp:ListItem>
                    <asp:ListItem Value="3">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="bookPrice" runat="server" Width="52px">0</asp:TextBox>元</td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="搜索" /></td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


