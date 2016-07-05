<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="addBook.aspx.cs"
    Inherits="admin_addBook" %>

<%@ Register Assembly="Jiaen.Controls" Namespace="TW.Web.UI" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="Jiaen.Controls" Namespace="Jiaen.Controls" TagPrefix="Jiaen" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图书操作</title>
    <link href="../images/cssothers.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
<!--
body {
	background-color: #ffffff;
}
-->
</style>
<script type="text/javascript">
//输入会员价，如果折扣不为空，就自动把计算的金额加入到会员价里边
function MarkPrice()
{
	
	var Goodsagio = parseFloat(document.form1.DetailsView1$Rebate.value);
	var VipRebate = parseFloat(document.form1.DetailsView1$VipRebate.value);
	var Price = parseFloat(document.form1.DetailsView1$Price.value);
	var MemberPrice;
	var VipPrice;

	
		if(Goodsagio.toString != '')
		{
			if(Goodsagio > 10)
			{
				Goodsagio = (Goodsagio + "").substring(0,2);
				Goodsagio = Goodsagio / 10;
			}
			MemberPrice = Math.round(((Goodsagio / 10) * Price) * 100) / 100;
			if(MemberPrice.toString() != 'NaN')
			{
				document.form1.DetailsView1$MemberPrice.value = MemberPrice;
			}
		}
		
		if(VipRebate.toString != '')
		{
			if(VipRebate > 10)
			{
				VipRebate = (VipRebate + "").substring(0,2);
				VipRebate = VipRebate / 10;
			}
			VipPrice = Math.round(((VipRebate / 10) * Price) * 100) / 100;
			if(VipPrice.toString() != 'NaN')
			{
				document.form1.DetailsView1$VipPrice.value = VipPrice;
			}
		}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0">
            <tbody>
                <tr>
                    <td class="Left_03" valign="top" width="8">
                        <img height="7" src="../images/Admin_2.gif" width="8"></td>
                    <td class="Left_01">
                        &nbsp;</td>
                    <td class="Left_04" valign="top" width="8">
                        <img height="7" src="../images/Admin_5.gif" width="8"></td>
                </tr>
                <tr>
                    <td class="Left_03">
                        &nbsp;</td>
                    <td>
                        <table class="SubMenu_Item" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="Default_Item" id="TD1">
                                                        <a href="bookList.aspx">图书列表</a></td>
                                                    <td class="Current_Item" id="TD2">
                                                        <a href="addBook.aspx">添加图书</a></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="C_order_state" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="font-size: 12px; height: 14px;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <td style="height: 148px">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
                                                    DataSourceID="ObjectDataSource1" DataKeyNames="BookID" OnItemInserted="DetailsView1_ItemInserted"
                                                    OnItemUpdated="DetailsView1_ItemUpdated" OnDataBound="DetailsView1_DataBound">
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="图书名称" SortExpression="BookName">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox1" runat="server" Text='<%# Bind("BookName") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox1" runat="server" Text='<%# Bind("BookName") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="所属分类" SortExpression="Category">
                                                            <EditItemTemplate>
                                                                <jiaen:AllCategoryDropDownList ID="AllCategoryDropDownList1" SelectedValue='<%# Bind("Category") %>'
                                                                    runat="server">
                                                                </jiaen:AllCategoryDropDownList>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <jiaen:AllCategoryDropDownList ID="AllCategoryDropDownList1" SelectedValue='<%# Bind("Category") %>'
                                                                    runat="server">
                                                                </jiaen:AllCategoryDropDownList>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="价格" SortExpression="Price">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="50px" ID="Price" runat="server" Text='<%# Bind("Price","{0:n}") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Price"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                                        runat="server" ControlToValidate="Price" ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="50px" ID="Price" runat="server" Text='<%# Bind("Price","{0:n}") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Price"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                                        runat="server" ControlToValidate="Price" ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Price","{0:n}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="会员价" SortExpression="MemberPrice">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="50px" ID="MemberPrice" runat="server" Text='<%# Bind("MemberPrice","{0:n}") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValiator3" runat="server" ControlToValidate="MemberPrice"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="MemberPrice"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator><br />
                                                                按折扣计价折扣:
                                                                <asp:TextBox onkeyup="MarkPrice()" ID="Rebate" runat="server" Text='<%# Bind("Rebate") %>' Width="46px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Rebate"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="50px" ID="MemberPrice" runat="server" Text='<%# Bind("MemberPrice","{0:n}") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValiator3" runat="server" ControlToValidate="MemberPrice"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="MemberPrice"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator><br />
                                                                按折扣计价折扣:
                                                                <asp:TextBox onkeyup="MarkPrice()" ID="Rebate" runat="server" Text='<%# Bind("Rebate") %>' Width="46px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Rebate"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("MemberPrice","{0:n}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="团购价" SortExpression="VipPrice">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="50px" ID="VipPrice" runat="server" Text='<%# Bind("VipPrice","{0:n}") %>'></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="VipPrice" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                        ID="vip4" runat="server" ControlToValidate="VipPrice" ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator><br />
                                                                按折扣计价折扣:
                                                                <asp:TextBox onkeyup="MarkPrice()" ID="VipRebate" runat="server" Text='<%# Bind("VipRebate") %>' Width="46px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="vip3" runat="server" ControlToValidate="VipRebate"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="50px" ID="VipPrice" runat="server" Text='<%# Bind("VipPrice","{0:n}") %>'></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="VipPrice" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                        ID="vip4" runat="server" ControlToValidate="VipPrice" ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator><br />
                                                                按折扣计价折扣:
                                                                <asp:TextBox onkeyup="MarkPrice()" ID="VipRebate" runat="server" Text='<%# Bind("VipRebate") %>' Width="46px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="vip3" runat="server" ControlToValidate="VipRebate"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"></asp:RegularExpressionValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("VipPrice","{0:n}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="库存" SortExpression="Stock">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="50px" ID="TextBox5" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="TextBox5"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox5"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="50px" ID="TextBox5" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="t5" runat="server" ControlToValidate="TextBox5"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox5"
                                                                    ErrorMessage="必须为数字" ValidationExpression="^[1-9]\d*|0$"></asp:RegularExpressionValidator>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书封面" SortExpression="BookImage">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="250px" ID="BookImage" runat="server" Text='<%# Bind("BookImage") %>'></asp:TextBox>
                                                                <asp:Label ID="successTxt" runat="server"></asp:Label>
                                                                <cc1:ImageUploader ID="ImageUploader1" runat="server" IsGenerateThumb="True" IsShowPreView="False"
                                                                    PicSavePath="~/Uploads/Images/" PicThumbSavePath="~/Uploads/Images/Thumb/"
                                                                    WatermarkTextColor="Transparent" WatermarkTextFont="Arial, 12px"
                                                                    OnUploaded="ImageUploader1_Uploaded" ThumbMaxHeight="200" ThumbMaxWidth="250" />
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="250px" ID="BookImage" runat="server" Text='<%# Bind("BookImage") %>'></asp:TextBox>
                                                                <asp:Label ID="successTxt" runat="server"></asp:Label>
                                                                <cc1:ImageUploader ID="ImageUploader1" runat="server" IsGenerateThumb="True" IsShowPreView="False"
                                                                    PicSavePath="~/Uploads/Images/" PicThumbSavePath="~/Uploads/Images/Thumb/"
                                                                    WatermarkTextColor="Transparent" WatermarkTextFont="Arial, 12px"
                                                                    OnUploaded="ImageUploader1_Uploaded" ThumbMaxHeight="200" ThumbMaxWidth="250" />
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("BookImage") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="缩略图" SortExpression="BookSmallImage">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="BookSmallImage" runat="server" Text='<%# Bind("BookSmallImage") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="BookSmallImage" runat="server" Text='<%# Bind("BookSmallImage") %>'></asp:TextBox>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("BookSmallImage") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书设置">
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="ReleaseChk" runat="server" Text="是否团购" Checked='<%# Bind("IsRelease") %>' />
                                                                <asp:CheckBox
                                                                    ID="GoodChk" runat="server" Text="是否推荐" Checked='<%# Bind("IsGood") %>' />
                                                                    <asp:CheckBox
                                                                        ID="CheapChk" runat="server" Text="是否特价" Checked='<%# Bind("IsCheap") %>' />
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:CheckBox ID="ReleaseChk" runat="server" Text="是否团购" Checked='<%# Bind("IsRelease") %>' />
                                                                <asp:CheckBox
                                                                    ID="GoodChk" runat="server" Text="是否推荐" Checked='<%# Bind("IsGood") %>' />
                                                                    <asp:CheckBox
                                                                        ID="CheapChk" runat="server" Text="是否特价" Checked='<%# Bind("IsCheap") %>' />
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("IsGood") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <InsertItemTemplate>
                                                                <asp:CheckBox ID="SaleGoodChk" runat="server" Text="是否热卖" Checked='<%# Bind("IsSaleGood") %>' /><asp:CheckBox
                                                                    ID="ExpectChk" runat="server" Text="是否为期书" />
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsMain") %>' Text="是否显示首页" />
                                                            </InsertItemTemplate>
                                                            <EditItemTemplate>
                                                            <asp:CheckBox ID="SaleGoodChk" runat="server" Text="是否热卖" Checked='<%# Bind("IsSaleGood") %>' />
                                                            <asp:CheckBox
                                                                    ID="ExpectChk" runat="server" Text="是否为期书" />
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsMain") %>' Text="是否显示首页" />
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书作者" SortExpression="BookAuthor">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox13" runat="server" Text='<%# Bind("BookAuthor") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox13"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox12" runat="server" Text='<%# Bind("BookAuthor") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox12"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                
                                                            </InsertItemTemplate>
                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="教师" SortExpression="TeacherID">
                                                            <EditItemTemplate>
                                                                选择此项，将图书与教师关联起来<br />
                                                                <br />
                                                                <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource3"
                                                                    DataTextField="Name" DataValueField="TeacherID" SelectedValue='<%# Bind("TeacherID") %>'>
                                                                    <asp:ListItem Value="0">暂无</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                选择此项，将图书与教师关联起来<br />
                                                                <br />
                                                                <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource3"
                                                                    DataTextField="Name" DataValueField="TeacherID" SelectedValue='<%# Bind("TeacherID") %>'>
                                                                    <asp:ListItem Value="0">暂无</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                            
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="出版社" SortExpression="BookPublish">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource2"
                                                                    DataTextField="PublishName" DataValueField="PublishName" SelectedValue='<%# Bind("BookPublish") %>'>
                                                                    <asp:ListItem>暂无</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource2"
                                                                    DataTextField="PublishName" DataValueField="PublishName" SelectedValue='<%# Bind("BookPublish") %>'>
                                                                    <asp:ListItem>暂无</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("BookPublish") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="出版时间" SortExpression="PublishTime">
                                                            <EditItemTemplate>
                                                                <jiaen:AdCalendar id="demo1" Runat="server" ValidationMessage="必须输入mm/dd/yyyy样式"
                                                                    ClientFilesUrl="..\JScript\ClientFiles\" SelectedDate='<%# Bind("PublishTime") %>'>
                                                                    <calendarstyle backcolor="Beige" bordercolor="Tan" borderstyle="Solid" borderwidth="1px"
                                                                        font-size="9pt" forecolor="DarkSlateBlue" height="200px" width="200px"></calendarstyle>
                                                                    <othermonthdaystyle forecolor="#CC9966" />
                                                                    <dayheaderstyle backcolor="Tan" font-bold="True" />
                                                                    <titlestyle backcolor="DarkRed" font-bold="True" forecolor="Beige" />
                                                                    <todaydaystyle backcolor="Red" />
                                                                    <selecteddaystyle backcolor="#CCCCFF" />
                                                                </jiaen:AdCalendar>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <jiaen:AdCalendar id="demo1" Runat="server" ValidationMessage="必须输入mm/dd/yyyy样式"
                                                                    ClientFilesUrl="..\JScript\ClientFiles\" SelectedDate='<%# Bind("PublishTime") %>'>
                                                                    <calendarstyle font-size="9pt" height="200px" borderwidth="1px" forecolor="DarkSlateBlue"
                                                                        borderstyle="Solid" bordercolor="Tan" width="200px" backcolor="Beige"></calendarstyle>
                                                                    <othermonthdaystyle forecolor="#CC9966"></othermonthdaystyle>
                                                                    <dayheaderstyle font-bold="True" backcolor="Tan"></dayheaderstyle>
                                                                    <titlestyle font-bold="True" forecolor="Beige" backcolor="DarkRed"></titlestyle>
                                                                    <todaydaystyle backcolor="Red"></todaydaystyle>
                                                                    <selecteddaystyle backcolor="#CCCCFF"></selecteddaystyle>
                                                                </jiaen:AdCalendar>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("PublishTime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书版次" SortExpression="BookEditions">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox12" runat="server" Text='<%# Bind("BookEditions") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox2" runat="server" Text='<%# Bind("BookEditions") %>'></asp:TextBox>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("BookEditions") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书系列">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource4"
                                                                    DataTextField="CatenaName" DataValueField="CatenaID" SelectedValue='<%# Bind("CatenaID") %>'>
                                                                    <asp:ListItem Value="0">暂无</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" DataSourceID="ObjectDataSource4"
                                                                    DataTextField="CatenaName" DataValueField="CatenaID" SelectedValue='<%# Bind("CatenaID") %>'>
                                                                    <asp:ListItem Value="0">暂无</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label16" runat="server" Text='<%# Bind("TeacherID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ISBN编号" SortExpression="BookISBN">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox10" runat="server" Text='<%# Bind("BookISBN") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="250px" ID="isbn" runat="server" Text='<%# Bind("BookISBN") %>'></asp:TextBox>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("BookISBN") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="BookPages" HeaderText="图书页数" SortExpression="BookPages" />
                                                        <asp:TemplateField HeaderText="相关搜索" SortExpression="SearchKey">
                                                            <EditItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox11" runat="server" Text='<%# Bind("SearchKey") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox Width="250px" ID="TextBox10" runat="server" Text='<%# Bind("SearchKey") %>'></asp:TextBox>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("SearchKey") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书简单介绍" SortExpression="SmallBookDec" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("SmallBookDec") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("SmallBookDec") %>'></asp:TextBox>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("SmallBookDec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="图书简介" SortExpression="BookDec">
                                                            <EditItemTemplate>
                                                            <asp:Label Visible=false ID="Label15" runat="server" Text='<%# Bind("SmallBookDec") %>'></asp:Label>
                                                                <FTB:FreeTextBox ID="ClassSummaryTxt" runat="server" Height="250px" Width="500px"
                                                                    Focus="False" AllowHtmlMode="False" AssemblyResourceHandlerPath="" AutoConfigure=""
                                                                    AutoGenerateToolbarsFromString="True" AutoHideToolbar="True" AutoParseStyles="True"
                                                                    BackColor="158, 190, 245" BaseUrl="" BreakMode="Paragraph" ButtonDownImage="False"
                                                                    ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20" ButtonImagesLocation="InternalResource"
                                                                    ButtonOverImage="False" ButtonPath="" ButtonSet="Office2003" ButtonWidth="21"
                                                                    ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False" DesignModeBodyTagCssClass=""
                                                                    DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50" DownLevelMessage=""
                                                                    DownLevelMode="TextArea" DownLevelRows="10" EditorBorderColorDark="128, 128, 128"
                                                                    EditorBorderColorLight="128, 128, 128" EnableHtmlMode="True" EnableSsl="False"
                                                                    EnableToolbars="True" FormatHtmlTagsToXhtml="True" GutterBackColor="129, 169, 226"
                                                                    GutterBorderColorDark="128, 128, 128" GutterBorderColorLight="255, 255, 255"
                                                                    HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" HtmlModeDefaultsToMonoSpaceFont="True"
                                                                    ImageGalleryPath="~/images/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}"
                                                                    InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                                                                    Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True"
                                                                    RemoveServerNameFromUrls="True" RenderMode="NotSet" ScriptMode="External" ShowTagPath="False"
                                                                    SslUrl="/." StartMode="DesignMode" StripAllScripting="False" SupportFolder="/aspnet_client/FreeTextBox/"
                                                                    TabIndex="-1" TabMode="InsertSpaces" Text='<%# Bind("BookDec") %>' TextDirection="LeftToRight"
                                                                    ToolbarBackColor="Transparent" ToolbarBackgroundImage="True" ToolbarImagesLocation="InternalResource"
                                                                    ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                                                    ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" UseToolbarBackGroundImage="True">
                                                                </FTB:FreeTextBox>
                                                            </EditItemTemplate>
                                                            <InsertItemTemplate>
                                                                <FTB:FreeTextBox ID="ClassSummaryTxt" runat="server" Height="250px" Width="500px"
                                                                    Focus="False" AllowHtmlMode="False" AssemblyResourceHandlerPath="" AutoConfigure=""
                                                                    AutoGenerateToolbarsFromString="True" AutoHideToolbar="True" AutoParseStyles="True"
                                                                    BackColor="158, 190, 245" BaseUrl="" BreakMode="Paragraph" ButtonDownImage="False"
                                                                    ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20" ButtonImagesLocation="InternalResource"
                                                                    ButtonOverImage="False" ButtonPath="" ButtonSet="Office2003" ButtonWidth="21"
                                                                    ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False" DesignModeBodyTagCssClass=""
                                                                    DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50" DownLevelMessage=""
                                                                    DownLevelMode="TextArea" DownLevelRows="10" EditorBorderColorDark="128, 128, 128"
                                                                    EditorBorderColorLight="128, 128, 128" EnableHtmlMode="True" EnableSsl="False"
                                                                    EnableToolbars="True" FormatHtmlTagsToXhtml="True" GutterBackColor="129, 169, 226"
                                                                    GutterBorderColorDark="128, 128, 128" GutterBorderColorLight="255, 255, 255"
                                                                    HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" HtmlModeDefaultsToMonoSpaceFont="True"
                                                                    ImageGalleryPath="~/images/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}"
                                                                    InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                                                                    Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True"
                                                                    RemoveServerNameFromUrls="True" RenderMode="NotSet" ScriptMode="External" ShowTagPath="False"
                                                                    SslUrl="/." StartMode="DesignMode" StripAllScripting="False" SupportFolder="/aspnet_client/FreeTextBox/"
                                                                    TabIndex="-1" TabMode="InsertSpaces" Text='<%# Bind("BookDec") %>' TextDirection="LeftToRight"
                                                                    ToolbarBackColor="Transparent" ToolbarBackgroundImage="True" ToolbarImagesLocation="InternalResource"
                                                                    ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                                                    ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" UseToolbarBackGroundImage="True">
                                                                </FTB:FreeTextBox>
                                                            </InsertItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("BookDec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowEditButton="True" ShowInsertButton="True" ShowCancelButton="False" />
                                                    </Fields>
                                                </asp:DetailsView>
                                                &nbsp; &nbsp; &nbsp;&nbsp;
                                            </td>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="Left_04">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Left_03" valign="bottom" width="8" style="height: 19px">
                        <img height="8" src="../images/Admin_8.gif" width="8"></td>
                    <td class="Left_02" style="height: 19px">
                        &nbsp;</td>
                    <td class="Left_04" valign="bottom" width="8" style="height: 19px">
                        <img height="8" src="../images/Admin_1.gif" width="8"></td>
                </tr>
            </tbody>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetPublishs" TypeName="Jiaen.BLL.Publish"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetBookByID" TypeName="Jiaen.BLL.Book" DataObjectTypeName="Jiaen.Components.BookInfo" UpdateMethod="UpdateBook" InsertMethod="InsertBook">
            <SelectParameters>
                <asp:QueryStringParameter Name="bookID" QueryStringField="edit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetTeacher" TypeName="Jiaen.BLL.Teacher">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="type" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCatenas" TypeName="Jiaen.BLL.BookCatena"></asp:ObjectDataSource>
        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    </form>
</body>
</html>

