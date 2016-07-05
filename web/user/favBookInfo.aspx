<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="favBookInfo.aspx.cs" Inherits="user_favBook" Title="图书收藏" %>

<%@ Register Src="../Control/userLeftMenu.ascx" TagName="userLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <script language="javascript" type="text/javascript" src="../JScript/common.js"></script>
    
    <div class="showInfo-main">
  <uc1:userLeftMenu ID="UserLeftMenu2" runat="server" />
  <div class="loginInfo-main-right">
 
 <br/><div class="ff9clolor"><img src="../images/usercenter.jpg" width="160" height="50" />欢迎来到迦恩计算机网站中心!</div>
 
  <TABLE cellSpacing=0 cellPadding=0 width=502  border=0 align="left">
  <!--DWLayoutTable-->
        <TBODY>
       
        <tr>
            <TD width="500" height=27 valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/firstlog.jpg">
                <!--DWLayoutTable-->
                <tr>
                  <td width="188" height="5"></td>
                  <td width="163"></td>
                  <td width="149"></td>
                </tr>
                <tr>
                  <td height="21"></td>
                  <td valign="top" ><b class="ff9clolor">我的收藏夹</b></td>
                <td></td>
                </tr>
                <tr>
                  <td height="3"></td>
                  <td></td>
                  <td></td>
                </tr>
                    </table></TD>
            <td width="4">&nbsp;</td>
          </TR>
        
        
        <TR>
          <TD height="253" valign="top" style="BORDER-LEFT:#c2c2c2 1px solid; BORDER-RIGHT:#c2c2c2 1px solid;">
		      <br/>
		      
		      <asp:GridView id="GridView1" runat="server" PageSize="5" DataKeyNames="FavID" AllowPaging="True" DataSourceID="ObjectDataSource1"
		         BackColor="#FFCC99"
            CellPadding="1" CellSpacing="1" 
		       AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        选择
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server"  />
                    </ItemTemplate>
                    <HeaderStyle Height="40px" Width="29px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品图片">
                    <ItemTemplate>
                        <asp:Image ID="Image1" Width="80" Height="110" ImageUrl='<%# Eval("bookSmallImage") %>' runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品信息">
                <ItemTemplate>
                         <%# Eval("bookName") %><br  />
                         售价：<%# Eval("Price","{0:C}") %> 迦恩售价：<%# Eval("MemberPrice","{0:C}") %>
                    </ItemTemplate>
                    <HeaderStyle Height="82px" Width="380px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="购买">
                    <ItemStyle Width="77px"  />
                    <ItemTemplate>
                    <DIV align=center><a href='<%# "favBookInfo.aspx?buyID="+Eval("BookID") %>'><IMG style="CURSOR: hand"  height=20 
            src="../images/cart3.gif" width=37></a> </DIV>
                    <DIV align=center><BR><asp:ImageButton Width=15 
          BorderWidth=0  ImageUrl="../images/trash.gif" CommandName="Delete" ID="ImageButton1" runat="server" /></DIV>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="BookID" SortExpression="BookID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="bookID" runat="server" Text='<%# Bind("BookID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
           <HeaderStyle BackColor="#F9F8DD" HorizontalAlign="Center"  />
            <RowStyle BackColor="#F9F8DD"  />
            <PagerStyle BackColor="#FFCC99"  />
        </asp:GridView>
                  
				  
				  <TABLE cellSpacing=0 cellPadding=0 width="90%" align=center border=0>
				    <!--DWLayoutTable-->
          <TBODY>
          <TR>
            <TD colSpan=2 height=10></TD></TR>
          <TR>
            <TD width="24%" height=10><FONT color=#ffffff>---</FONT> <INPUT 
            onclick=javascript:SelectAllCheckboxes(this); type=checkbox value=on name=chkall> 
              <SPAN class=s><FONT color=#ff0099>全部选中</FONT></SPAN> </TD>
            <TD width="76%" height=10>
              <DIV align=right><FONT color=#000099><SPAN class=s><FONT 
            color=#ff0099>
                                <asp:Button ID="deleteBtn" style="width: 80px; border-top-style: ridge; border-right-style: ridge;
                                    border-left-style: ridge; height: 29px; border-bottom-style: ridge" runat="server" Text="删除" OnClick="deleteBtn_Click" /><asp:Button ID="AddToCartBtn" style="width: 80px; border-top-style: ridge; border-right-style: ridge;
                                    border-left-style: ridge; height: 29px; border-bottom-style: ridge" runat="server" Text="加入购物车" OnClick="AddToCartBtn_Click" />
                  &nbsp;
              </FONT></SPAN></FONT></DIV></TD></TR>
          <tr>
            <td height="5"></td>
            <td></td>
          </tr>
          </TBODY></TABLE>          
             <br/>
			 
			  <DIV align=center><IMG height=1 
            src="../images/line.gif" width=304></DIV></TD>
			
          <TD>&nbsp;</TD>
          </TR>
        
        <TR>
          <TD height="58" valign="top"><table width="500" border="0"  background="../images/bg_bottom.gif" cellpadding="0" cellspacing="0">
                <!--DWLayoutTable-->
                <tr>
                  <td width="500" height="58"></td>
                </tr>
          </table></TD>
        <TD>&nbsp;</TD>
        </TR>
        <TR>
          <TD height="50">&nbsp;<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteFavBook" SelectMethod="GetFavBooks" TypeName="Jiaen.BLL.FavBook">
            <DeleteParameters>
                <asp:Parameter Name="favID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
        
        </TD>
          <TD>&nbsp;</TD>
        </TR>
      </TBODY>
      </TABLE>
  
  </div><!-----showInfo-main-right----------------------->
  </div>
</asp:Content>

