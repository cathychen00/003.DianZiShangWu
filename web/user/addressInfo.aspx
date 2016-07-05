<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="addressInfo.aspx.cs" Inherits="user_addressInfo" Title="送货地址" %>

<%@ Register Src="../Control/userLeftMenu.ascx" TagName="userLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="showInfo-main">
        <uc1:userLeftMenu ID="UserLeftMenu2" runat="server" />
        <div class="loginInfo-main-right">
            <br />
            <div class="ff9clolor">
                <img src="../images/usercenter.jpg" width="160" height="50" />欢迎来到迦恩计算机网站中心!</div>
            <table cellspacing="0" cellpadding="0" width="502" border="0" align="left">
                <!--DWLayoutTable-->
                <tbody>
                    <tr>
                        <td width="500" height="27" valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/firstlog.jpg">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="154" height="5">
                                    </td>
                                    <td width="163">
                                    </td>
                                    <td width="183">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 21px">
                                    </td>
                                    <td valign="top" style="height: 21px">
                                        <strong class="ff9clolor">修改送货地址</strong></td>
                                    <td style="height: 21px">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="253" valign="top" style="border-left: #c2c2c2 1px solid; border-right: #c2c2c2 1px solid;">
                            <br />
                            <table id="table6" cellspacing="0" cellpadding="5" width="400" border="0">
                                <!--DWLayoutTable-->
                                <tbody>
                                    <tr height="28">
                                        <td width="100" height="33" align="right">
                                            <div align="left">
                                                收货人姓名：</div>
                                        </td>
                                        <td width="280">
                                            <asp:TextBox ID="UserNameTextBox" runat="server">
                                            </asp:TextBox></td>
                                    </tr>
                                    <tr height="28">
                                        <td height="33" align="right">
                                            <div align="left">
                                                收货人省/市：</div>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ProvinceList" runat="server" OnTextChanged="ProvinceList_TextChanged"
                                                        DataValueField="AreaID" DataTextField="Name" DataSourceID="ObjectDataSource1"
                                                        AutoPostBack="True">
                                                        
                                                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="CityList" runat="server" DataValueField="AreaID"
                                                        DataTextField="Name">
                                                        
                                                    </asp:DropDownList>&nbsp;
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Jiaen.BLL.SendArea"
                                                        SelectMethod="GetSendArea" OldValuesParameterFormatString="original_{0}">
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
                                    <tr height="28">
                                        <td height="33" align="right">
                                            <div align="left">
                                                详细地址：</div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="AddressTextBox" runat="server" /></td>
                                    </tr>
                                    <tr height="33">
                                        <td height="33" align="right">
                                            <div align="left">
                                                邮编：</div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="PostTextBox" runat="server" /></td>
                                    </tr>
                                    <tr height="33">
                                        <td height="33" align="right">
                                            <div align="left">
                                                电话：</div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TelephoneTextBox" runat="server" /></td>
                                    </tr>
                                    <tr height="33">
                                        <td align="right" height="33">
                                        </td>
                                        <td>
                                            <asp:Label ID="successTxt" runat="server" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                            <div align="center">
                                <img height="1" src="../images/line.gif" width="304"></div>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="58" valign="top">
                            <table width="500" border="0" background="../images/bg_bottom.gif" cellpadding="0"
                                cellspacing="0">
                                <!--DWLayoutTable-->
                                <tr>
                                    <td width="117" height="11">
                                    </td>
                                    <td width="93">
                                    </td>
                                    <td width="80">
                                    </td>
                                    <td width="197">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="36">
                                    </td>
                                    <td valign="top">
                                        <input id="changeBtn" style="width: 80px; height: 29px;" type="submit" value="确定"
                                            name="AddToCart" runat="server" onserverclick="changeBtn_ServerClick" /></td>
                                    <td valign="top">
                                        <input id="Submit1" style="width: 80px; height: 29px;" type="reset" value="取消" name="AddToCart" /></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="11">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="50">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-----showInfo-main-right----------------------->
    </div>
</asp:Content>

