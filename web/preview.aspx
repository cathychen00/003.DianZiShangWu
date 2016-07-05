<%@ Page Language="C#" MasterPageFile="~/Templete2.master" AutoEventWireup="true"
    CodeFile="preview.aspx.cs" Inherits="preview" Title="在线投稿" %>

<%@ Register Src="Control/ViewTopDynamic.ascx" TagName="ViewTopDynamic" TagPrefix="uc3" %>

<%@ Register Src="Control/bookList.ascx" TagName="bookList" TagPrefix="uc2" %>

<%@ Register Src="Control/newAndGood.ascx" TagName="newAndGood" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <!--主要部分分左右-->
        &nbsp;<div class="main-left">
            <uc1:newAndGood ID="NewAndGood1" runat="server" />
            <uc3:ViewTopDynamic ID="ViewTopDynamic1" runat="server" />
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            &nbsp;<asp:SiteMapPath ID="SiteMapPath1" runat="server">
            </asp:SiteMapPath>
           <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="DownID"
            DataSourceID="ObjectDataSource1" DefaultMode="Insert" OnItemInserted="DetailsView1_ItemInserted" Width="400px">
            <Fields>
                <asp:TemplateField HeaderText="标题" SortExpression="HelpTitle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DownName") %>' Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DownName") %>' Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DownName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件上传" SortExpression="Size">
                    <InsertItemTemplate>
                        <asp:TextBox ID="fileTxt" runat="server" Text='<%# Bind("DownURL") %>' Width="200px" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="flieSize" runat="server" Enabled="false" Text='<%# Bind("Size") %>' Visible="False"></asp:TextBox>
             
                        <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Button ID="Button1"
                            runat="server" CausesValidation="False" OnClick="Button1_Click" Text="上传" />
                        <asp:Label ID="Label1" ForeColor=red runat="server"></asp:Label>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="作者" SortExpression="Author">
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Author") %>' Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="介绍" SortExpression="Dec">
                    
                    <InsertItemTemplate>
                        
                        <asp:TextBox Text='<%# Bind("Dec") %>' ID="TextBox3" runat="server" Height="86px" TextMode="MultiLine" Width="283px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                   
                </asp:TemplateField>
                <asp:CommandField ShowCancelButton="False" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Red"></asp:LinkButton>
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text='格式错误,必须为".gif", ".png", ".jpeg", ".jpg",".doc",".rar",".zip"'
                Visible="False"></asp:Label><!---------third----------></div>
        <!-------------------------right------------------------->
        <br />
        
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jiaen.Components.DownLoadInfo"
        InsertMethod="InsertDownLoad" OldValuesParameterFormatString="original_{0}" OnInserting="ObjectDataSource1_Inserting"
        SelectMethod="GetDownLoad" TypeName="Jiaen.BLL.DownLoad">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDownClass" TypeName="Jiaen.BLL.DownClass"></asp:ObjectDataSource>
</asp:Content>

