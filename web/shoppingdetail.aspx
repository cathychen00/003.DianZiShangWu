<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shoppingdetail.aspx.cs" Inherits="shoppingdetail" %>
<%@ Register Src="Control/cartHelp.ascx" TagName="cartHelp" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>送货地址</title>
    <link href="images/cssothers.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="shopwhole">
        <uc2:cartHelp id="CartHelp1" runat="server"></uc2:cartHelp>
            
            <DIV class="shop-banner">　<IMG height=41 
src="images/goulog.jpg" width=128 /><IMG 
height=36 alt="1" src="images/11.jpg" width=122 /><IMG height=36 src="images/one.jpg" 
width=12 /><IMG height=36 alt="2" 
src="images/2_1.jpg" width=113 /><IMG 
height=36 src="images/one.jpg" width=12 
/><IMG height=36 alt="3" src="images/3.jpg" width=114 /><IMG height=36 src="images/one.jpg" 
width=12 /><IMG height=36 src="images/4.jpg" 
width=109 /><IMG height=36 
src="images/one.jpg" width=12 /><IMG 
height=36 src="images/5.jpg" width=122 
/></DIV>
            <!-----------shop-bananer--------------------------->
            <div class="shop-tit">
                <img src="images/litter.gif" alt="heng" width="15" height="12" />用户名:<asp:LoginName
                    ID="LoginName1" runat="server" />
            </div>
            <div class="shop-main">
                <table cellspacing="2" cellpadding="2" width="96%" align="center" border="0">
                    <!--DWLayoutTable-->
                    <tr>
                        <td width="729" align="middle" valign="baseline">
                            <p align="left">
                                <font size="3"><b><font color="#ff6600">收货人信息：</font>（*号为必填）</b></font></p>
                        </td>
                    </tr>
                    <tr>
                        <td height="223" valign="top">

                            <table cellspacing="1" cellpadding="5" width="100%" bgcolor="#f8d8b1" border="0">
                                <tr bgcolor="#ffffff">
                                    <td align="right" width="16%">
                                        * 姓名：</td>
                                    <td width="84%">
                                        <asp:TextBox ID="userNameTxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                   <tr bgcolor="#ffffff">
                                    <td align="right" width="30%">
                                        * 省/市：</td>
                                    <td width="84%">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ProvinceList" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                    DataTextField="Name" DataValueField="AreaID" OnTextChanged="ProvinceList_TextChanged">
                                                </asp:DropDownList>城市：&nbsp;<asp:DropDownList ID="CityList" runat="server" DataTextField="Name"
                                                    DataValueField="AreaID">
                                                </asp:DropDownList>&nbsp;
                                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetSendArea" TypeName="Jiaen.BLL.SendArea">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="type" Type="Int32" />
                                                        <asp:Parameter DefaultValue="0" Name="areaID" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ProvinceList" EventName="TextChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="right" width="30%">
                                        * 详细地址：</td>
                                    <td width="84%">
                                        <asp:TextBox ID="addressTxt" runat="server" Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="addressTxt"
                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="right" width="16%">
                                        * 邮编：</td>
                                    <td width="84%">
                                        <asp:TextBox ID="postTxt" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="postTxt"
                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="right" width="16%">
                                        * 电话：</td>
                                    <td width="84%">
                                        <asp:TextBox ID="telephoneTxt" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="telephoneTxt"
                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetSendArea" TypeName="Jiaen.BLL.SendArea">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="type" Type="Int32" />
                                    <asp:Parameter DefaultValue="0" Name="areaID" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <div class="shopcon">
                    <p>
                      
                        <a href=# onclick="javascript:history.back()"><img src="images/return.jpg" width="111" height="27" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><img src="images/next.jpg" width="111" height="27" /></asp:LinkButton></p>
                </div>
            </div>
            <!-----------shop-main--------------------------->
            <jiaen:footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>

