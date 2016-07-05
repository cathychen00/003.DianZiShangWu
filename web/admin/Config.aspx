<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="admin_Config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../images/cssothers.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
<!--
body {
	background-color: #ffffff;
}
-->
</style>

    <script type="text/javascript">   
 
 function Button1_onclick() {
 var a= window.showModalDialog("Dialog.aspx?rif=Uploads/Images&cif=Uploads/Images");   
 if(a.length>0)
 {
 document.form1.SiteLogo.value=a;
 }
}
 function Button2_onclick() {
 var a= window.showModalDialog("Dialog.aspx?rif=Uploads/Images&cif=Uploads/Images");   
 if(a.length>0)
 {
 document.form1.SiteBanner.value=a;
 }
}
 function Button3_onclick() {
 var a= window.showModalDialog("Dialog.aspx?rif=Uploads/Images&cif=Uploads/Images");   
 if(a.length>0)
 {
 document.form1.SiteBottomAd.value=a;
 }
}
 function Button4_onclick() {
 var a= window.showModalDialog("Dialog.aspx?rif=Uploads/Images&cif=Uploads/Images");   
 if(a.length>0)
 {
 document.form1.WatermarkFileName.value=a;
 }
}

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
            <!--DWLayoutTable-->
            <tbody>
                <tr>
                    <td width="8" height="24" valign="top" class="Left_03">
                        <img height="7" src="../images/Admin_2.gif" width="8"></td>
                    <td rowspan="2" valign="top" class="Left_01">
                        <table class="C_order_state" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <!--DWLayoutTable-->
                            <tbody>
                                <tr>
                                    <td width="969" height="25">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="248" valign="top">
                                        <br />
                                        <table align="center" width="95%" cellspacing="0" cellpadding="0" border="0" style="border-bottom: 1px solid #ff9000;
                                            border-top: 1px solid #ff9000; border-left: 1px solid #ff9000; border-right: 1px solid #ff9000;">
                                            <!--DWLayoutTable-->
                                            <tbody>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        站点名称：</td>
                                                    <td align="left" class="ff9clolor" colspan="6">
                                                        <asp:TextBox ID="SiteName" runat="server" Width="250px"></asp:TextBox></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        Logo：</td>
                                                    <td align="left" class="ff9clolor" colspan="6">
                                                        <asp:TextBox ID="SiteLogo" runat="server" Width="250px"></asp:TextBox>
                                                        <asp:Button ID="Button1" runat="server" Text="上传" OnClientClick="return Button1_onclick()" /></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        Banner:</td>
                                                    <td align="left" class="ff9clolor" colspan="6">
                                                        <asp:TextBox ID="SiteBanner" runat="server" Width="251px"></asp:TextBox>
                                                        <asp:Button ID="Button2" runat="server" Text="上传" OnClientClick="return Button2_onclick()" /></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        头部广告</td>
                                                    <td colspan="6">
                                                        <asp:TextBox ID="SiteBottomAd" runat="server" Width="251px"></asp:TextBox>
                                                        <asp:Button ID="Button3" runat="server" Text="上传" OnClientClick="return Button3_onclick()" /></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        水印类型</td>
                                                    <td colspan="6">
                                                        <asp:RadioButtonList ID="WatermarkList" runat="server" RepeatDirection="Horizontal"
                                                            RepeatLayout="Flow">
                                                            <asp:ListItem Value="None">无</asp:ListItem>
                                                            <asp:ListItem Value="Text">文字</asp:ListItem>
                                                            <asp:ListItem Value="Image">图片</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        水印文字</td>
                                                    <td colspan="6">
                                                        <asp:TextBox ID="WatermarkText" runat="server" Width="250px"></asp:TextBox></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        水印图片</td>
                                                    <td align="left" class="ff9clolor" colspan="6">
                                                        <asp:TextBox ID="WatermarkFileName" runat="server" Width="250px"></asp:TextBox>
                                                        <asp:Button ID="Button5" runat="server" Text="上传" OnClientClick="return Button4_onclick()" /></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td align="left" class="ff9clolor" colspan="7">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="24" style="width: 200px">
                                                        团购最小数量</td>
                                                    <td align="left" colspan="6">
                                                       <asp:TextBox ID="TgNumTxt" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td align="left" class="ff9clolor" colspan="7">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td align="left" class="ff9clolor" colspan="7">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F9F9F2">
                                                    <td height="25" style="width: 200px">
                                                        &nbsp;服务条款</td>
                                                    <td colspan="6" align="left" valign="middle" class="ff9clolor">
                                                        
                                                        <asp:TextBox ID="ServiceTxt" runat="server" Height="200px" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="25" style="width: 200px">
                                                    </td>
                                                    <td align="left" class="ff9clolor" colspan="6" valign="middle">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#f9f9f2">
                                                    <td height="25" style="width: 200px">
                                                        底部版权信息</td>
                                                    <td align="left" class="ff9clolor" colspan="6" valign="middle">
                                                        <FTB:FreeTextBox ID="SiteBottomDec" runat="server" Height="200px" Width="500px">
                                                        </FTB:FreeTextBox>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F9F9F2">
                                                    <td height="26" colspan="6" valign="top">
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr bgcolor="#F9F9F2">
                                                    <td height="44" style="width: 200px">
                                                        &nbsp;</td>
                                                    <td width="119">
                                                        &nbsp;</td>
                                                    <td width="62">
                                                        &nbsp;<asp:Button ID="Button4" runat="server" Text="提交" OnClick="Button4_Click" /></td>
                                                    <td width="89">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="18">
                                        &nbsp;</td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="Left_04" valign="top" width="8">
                        <img height="7" src="../images/Admin_5.gif" width="8"></td>
                </tr>
                <tr>
                    <td height="267" class="Left_03">
                        &nbsp;</td>
                    <td class="Left_04">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Left_03" valign="bottom">
                        <img height="8" src="../images/Admin_8.gif" width="8"></td>
                    <td class="Left_02">
                        &nbsp;</td>
                    <td class="Left_04" valign="bottom">
                        <img height="8" src="../images/Admin_1.gif" width="8"></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>

