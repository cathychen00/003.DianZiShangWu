<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewDnamicInfo.ascx.cs" Inherits="Control_ViewDnamicInfo" %>
  <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
<div class="bule">
       <img src="images/bule.jpg" alt="bule" width="21" height="24" /><%# Eval("DynamicTitle") %>  
 </div>
<div class="newinfo">
    <%# Eval("AddDate") %> 阅读数[<%# Eval("ReadCount") %>]
</div>
<div class="newmain">
<%# Eval("DynamicContent") %>
  </div>    
    </ItemTemplate>
</asp:FormView>
 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetSiteDynamicByID" TypeName="Jiaen.BLL.SiteDynamic" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="11" Name="siteDynamicID" QueryStringField="dyID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

