﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_OnLinePayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string edit = Request.QueryString["edit"];
        if (edit != null)
        {
            DetailsView1.Visible = true;
        } else
        {
            DetailsView1.Visible = false;
        }
    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Response.Redirect("OnLinePayment.aspx");
        DetailsView1.Visible = false;
    }
}
