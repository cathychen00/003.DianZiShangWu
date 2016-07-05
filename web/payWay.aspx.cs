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
public partial class payWay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["url"] = Request.UrlReferrer.AbsolutePath;
            dataBind();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Address.UpdateAddressPay(int.Parse(PayRadioButtonList1.SelectedValue));

        Response.Redirect(ViewState["url"].ToString());
    }

    void dataBind()
    {
        PayRadioButtonList1.SelectedValue = Address.GetAddressByID().PayType.ToString();
    }
}
