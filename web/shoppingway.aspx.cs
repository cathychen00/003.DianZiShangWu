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
public partial class shoppingway : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool sended=SendArea.GetSendAreaByID(int.Parse(Address.GetAddressByID().City)).IsSended;
            ViewState["url"] = Request.UrlReferrer.AbsolutePath;
            if (!sended)
            {
                SendRadioButtonList1.Items.RemoveAt(2);
            }
            dataBind();
        }
    }

    //void sendBind()
    //{
    //    int sendID=int.Parse(Address.GetAddressByID().City);
    //    if(SendArea.GetSendAreaByID(sendID).IsSended)
    //    {

    //    }
    //}

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int  sendType1 =Address.GetAddressByID().SendType;
        Address.UpdateAddressSend(int.Parse(SendRadioButtonList1.SelectedValue));
        int sendType2 = Address.GetAddressByID().SendType;
        if ((sendType1 == 3) && sendType2 != 3)
        {
            Address.UpdateAddressPay(2);
            //Response.Redirect("payWay.aspx");
            Response.Redirect(ViewState["url"].ToString());
        }
        else
        {
            Response.Redirect(ViewState["url"].ToString());
        }
       
    }

    void dataBind()
    {
        SendRadioButtonList1.SelectedValue = Address.GetAddressByID().SendType.ToString();
    }
}
