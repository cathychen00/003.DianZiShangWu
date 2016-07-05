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
using Jiaen.BLL;
using Jiaen.Components;
public partial class admin_EmailList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string edit = Request.QueryString["edit"];
        if (edit != null)
        {
            DetailsView1.Visible = true;
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
            DetailsView1.Visible = false;
        }
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        GridView1.Visible = true;
        DetailsView1.Visible = false;
        string edit = Request.QueryString["edit"];
        if (edit == "2")
        {
            EmailSend send = new EmailSend();
            
            send.sendPwdEmail();
        }
    }

    protected void ObjectDataSource2_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        EmailFormatInfo email = (EmailFormatInfo)e.InputParameters[0];
        if (email.EmailID == 2)
        {
            email.EmailTemplete = Server.HtmlDecode(email.EmailTemplete);
        }
    }
}
