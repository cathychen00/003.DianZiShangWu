<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Control_Search" %>
      <div class="seach">
        <div align="left" >
          <fieldset>
          　<asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
         您好，欢迎光临迦恩计算机资源网。请 <a runat=server href="~/login.aspx">登录</a> /<a runat=server href="~/userReg.aspx">注册</a> /<a runat=server href="~/pwd.aspx">忘记密码?</a>
    </AnonymousTemplate>
    <LoggedInTemplate>
              您好，<asp:LoginName ID="LoginName1" runat="server" />，欢迎光临迦恩计算机资源网。<asp:HyperLink Visible=false ID="HyperLink1" NavigateUrl="~/admin/default.htm" runat="server">进入后台管理</asp:HyperLink>
    </LoggedInTemplate>
    
</asp:LoginView>
          <input onkeypress=whenDown(event) id=txtKeyWord 
onclick="if(this.value=='key1 key2 key3'){this.value='';}" size=20 
value="key1 key2 key3" name=q runat="server" />
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><img runat="server" src="~/images/seach.gif" width="18" height="18" /></asp:LinkButton>
            <a runat=server target="_blank" href="~/advanceSearch.aspx">高级搜索</a>  
          </fieldset>
        </div>
      </div>

