using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
public partial class admin_Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        PaymentInfo pay = (PaymentInfo)e.InputParameters[0];
        pay.PartnerID = string.Empty;
        pay.PrivateKey = string.Empty;
       
        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DetailsView1.Visible = false;
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DetailsView1.Visible = true;
    }
    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        DetailsView1.Visible = true;
    }
}
