<%@ Page MasterPageFile="~/Templete2.master" EnableViewState="true" Language="C#" AutoEventWireup="true"
    CodeFile="topsale.aspx.cs" Inherits="topsale" Title="销售排行" %>

<%@ Import Namespace="Jiaen.Components.Utility" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main">
        <!--主要部分分左右-->
        <div class="main-left">
            <div class="leftbanner_1">
                <fieldset>
                    <legend>
                        <img src="images/changxiao.jpg" alt="changxiao" width="150" height="40" /></legend>
                   
                  
                   <br>
                    选择年:<label>
                        <Jiaen:YearDropDownList ID="YearDropDownList1" runat="server">
                        </Jiaen:YearDropDownList></label><br><br>
                    选择月:<label>
                        <Jiaen:MonthDropDownList ID="MonthDropDownList1" runat="server">
                        </Jiaen:MonthDropDownList></label>
                        <br><br>
                        重新排:<asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
                    <div class="sign">
                        <img src="images/sign.gif" alt="sign" width="4" height="20" />
                        分类排行</div>
                    <div class="fenpai">
                        <ul class="fenul">
                            <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource1">
                                <ItemTemplate>
                                    <li><b>■【<%# Eval("CategoryName") %>】</b><br>
                                    </li>
                                    <asp:Repeater OnItemCommand="Repeater3_ItemCommand"  DataSource='<%# dataCategory((int)Eval("CategoryID")) %>' ID="Repeater2"
                                        runat="server">
                                        <ItemTemplate>

                                            <span>·<asp:LinkButton CommandArgument='<%# Eval("CategoryID") %>' CommandName="catSet" ID="LinkButton1"  runat="server"><asp:Label id="CategoryName" Text='<%# Eval("CategoryName") %>' Runat="Server" /></asp:LinkButton>
                                            </a></span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!-----fenpai----->
                </fieldset>
            </div>
        </div>
        <!-------------------------left结尾------------------------->
        <div class="main-right">
            <div class="right-first">
                <b>
                    <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                    </asp:SiteMapPath>
                </b></div>
            <div class="bule">
                <img src="images/bule.jpg" alt="bule" width="21" height="24" />最新排行榜<span>|NETLIST</span>
            </div>
            <!--topsale--->
            
            <asp:Repeater EnableViewState="false" ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="right-topsale">
                        <div class="topsale-image">
                            <img runat=server src='<%# Eval("bookSmallImage") %>' alt='<%# Eval("bookName") %>' width="80" height="100" /></div>
                        <div class="topsale-word">
                            <a href='bookInfo.aspx?bookID=<%# Eval("bookID") %>'><span>NO.<%# Container.ItemIndex+1 %>:<%# Eval("bookName") %></span></a><br>
                            市场价：<%# Eval("Price","{0:c}") %>元 | 迦恩价：<%# Eval("MemberPrice","{0:c}") %>元<br>
                            <a href='shoppingCart.aspx?bookID=<%# Eval("bookID") %>'>
                                <img src="images/add-to-cart.gif" alt="buy" /></a> <a href='user/favBookInfo.aspx?bookID=<%# Eval("bookID") %>'>
                                    <img src="images/favorites.gif" alt="re" width="85" height="14" /></a><br>
                            <span>【简介】:</span><%# StringHelper.subStr(80,(string)Eval("bookDec")) %>
                            
                        </div>
                    </div>
                </ItemTemplate>
                
            </asp:Repeater>
            
        </div>
        <!------------->
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCategory" TypeName="Jiaen.BLL.Category">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="categoryType" Type="Object" />
            <asp:Parameter DefaultValue="0" Name="categoryID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>

