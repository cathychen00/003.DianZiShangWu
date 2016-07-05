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

public partial class admin_addTitleCss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string edit = Request.QueryString["edit"];
        if (edit != null)
        {
            DetailsView1.DefaultMode = DetailsViewMode.Edit;
        }
        else
        {
            DetailsView1.DefaultMode = DetailsViewMode.Insert;
        }
    }


    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Response.Redirect("titleCss.aspx");
    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("titleCss.aspx");
    }
}
