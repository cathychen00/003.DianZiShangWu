<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="help.aspx.cs" Inherits="help" Title="帮助中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="showInfo-main">
        <jiaen:help ID="Help1" runat="server" />
        <div class="help-main-right">
       
          <div class="ff9clolor">
   欢迎来到迦恩计算机网站中心!
   <br/>
   
   
  
    </div>
            <div class="help-main">
            <div class="help-top">
 </div>
 <div class="help-content">
                <p>
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b></b>
                    <div>
                        <asp:Repeater ID="Repeater1" DataSourceID="ObjectDataSource1" runat="server">
                            <ItemTemplate>
                                <img src="images/senior.gif" width="9" height="12" /><span class="ff9clolor">
            <asp:Label ID="HelpTitleLabel" runat="server" Text='<%# Bind("HelpTitle") %>'></asp:Label>
            </span>
            <a
                                    name='<%# Eval("HelpID") %>'></a><br />
                                <asp:Label ID="HelpContentLabel" runat="server" Text='<%# Bind("HelpContent") %>'>
                                </asp:Label><br />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetClassHelpByID" TypeName="Jiaen.BLL.Help">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="1" Name="classID" QueryStringField="classID"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
            </div>
            <div class="ff9clolor">
            </div>
        </div>
        <div class="help-main-right">
 <br/>
 
        <!-----showInfo-main-right----------------------->
    </div>
    </div>
    </div>
</asp:Content>

