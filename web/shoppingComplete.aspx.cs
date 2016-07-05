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
using CommonAliPay;
public partial class shoppingComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pay();
    }

    public void pay()
    {
        
        orderID.Text = Request.Cookies["orderID"].Value;
        long order = Convert.ToInt64(Request.Cookies["orderID"].Value);
        int payType = Orders.GetOrdersByID(order).PayType;
        if (payType == 2)
        {
            Panel1.Visible = true;
        }
        else
        {
            payMessage.Text = "请牢记如下信息:<br><font color=red>" + Payment.GetPaymentByID(payType).Dec+"</font>";
        }
        payTypeTxt.Text = getPay(payType);
    }

   public string getPay(int payType)
    {
        
        string pay = "";
        if (payType == -1)
        {
            pay = "货到付款";
        }
        else
        {
            pay = Payment.GetPaymentByID(payType).PayName;
        }
        return pay;
    }

    public string getSend(int sendType)
    {

        return Send.GetSendByID(sendType).Name;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        long orderID = Convert.ToInt64(Request.Cookies["orderID"].Value);
        OrdersInfo order = Orders.GetOrdersByID(orderID);
        
        AliPay ap = new AliPay();
        PaymentInfo pay=Payment.GetPaymentByID(2);
        string key = pay.PrivateKey;//填写自己的key
        string partner = pay.PartnerID;//填写自己的Partner
        decimal sendPrice =decimal.Round(order.SendPrice,2);
        decimal price = decimal.Round(order.NeedPayPrice, 2);
        StandardGoods bp = new StandardGoods("trade_create_by_buyer", partner, key, "MD5", order.OrderID.ToString(), Guid.NewGuid().ToString(), price - sendPrice, 1, pay.UserName, pay.UserName
            , "EMS", sendPrice, "BUYER_PAY", "1");
           bp.Notify_Url = "http://";
        ap.CreateStandardTrade("https://www.alipay.com/cooperate/gateway.do", bp, this);
    }
}
