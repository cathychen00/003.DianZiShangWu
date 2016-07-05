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
public partial class tgshoppingorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkCount();
            getPay();
            sumPrices();
        }
    }

    void checkCount()
    {
        if (Jiaen.BLL.ShoppingCart.SelectTgCart().Count <= 0)
        {
            Response.Redirect("Default.aspx");

        }
    }

    void getPay()
    {

        int pay = Address.GetAddressByID().PayType;
        if (pay == -1)
        {
            payName.Text = "货到付款";
        }
        else
        {
            payName.Text = Payment.GetPaymentByID(pay).PayName;
        }
    }

    void sumPrices()
    {
        if (Session["tgPrice"] == null)
        {
            Response.Redirect("tgShoppingCart.aspx");
        }
        //Request.ServerVariables["URL"].EndsWith
        decimal orderPrice;
        orderPrice = Convert.ToDecimal(Session["tgPrice"].ToString().Substring(1));
        decimal dSendPrice = Address.GetAddressByID().Price;
        balanceTxt.Text = string.Format("{0:c}",Address.GetAddressByID().Balance);
        needBalancePay.Text = string.Format("{0:n}",(orderPrice + dSendPrice - Convert.ToDecimal(balancePay.Text)));
        sumPrice.Text = string.Format("{0:c}", (orderPrice + dSendPrice));
        sendPrice.Text = string.Format("{0:c}", dSendPrice);
        orderPriceTxt.Text = string.Format("{0:c}", orderPrice);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        checkCount();
        OrdersInfo order = new OrdersInfo();
        long orderID = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddhhmmss"));
        Response.Cookies["orderID"].Value = orderID.ToString();
        Response.Cookies["orderID"].Expires = DateTime.Now.AddDays(1);
        AddressInfo address = Address.GetAddressByID();
        //定单编号,用户,送货用户,地址,邮编,电话
        order.OrderID = orderID;
        order.UserName = address.UserName;
        order.AddressName = address.AddressName;
        order.Address = address.Address;
        order.Post = address.Post;
        order.Telephone = address.Telephone;
        //省份,城市,送货方式,付款方式
        order.Province = address.Province;
        order.City = address.City;
        order.SendType = address.SendType;
        order.PayType = address.PayType;
        //是否开发票,图书价格,送货费用,总价格,留言
        order.EnableInvoice = Convert.ToBoolean(InvoiceList.SelectedValue);
        order.BookPrice = Convert.ToDecimal(Session["tgPrice"].ToString().Substring(1));
        order.SendPrice = Convert.ToDecimal(sendPrice.Text.Substring(1));
        order.SumPrice = Convert.ToDecimal(sumPrice.Text.Substring(1));
        order.BalancePrice = Convert.ToDecimal(balancePay.Text);
        order.NeedPayPrice = Convert.ToDecimal(needBalancePay.Text);
        order.TgPrice = Convert.ToDecimal(Session["tgPrice"].ToString().Substring(1));
        order.IsTg = true;
        order.Message = messageTxt.Text;
        Orders.InsertOrders(order);
        Address.UpdateAddressBalance(order.BalancePrice);
        try
        {

            EmailSend es = new EmailSend();
            es.sendOrderEmail(orderID.ToString(), sumPrice.Text.Substring(1));
        }
        catch (Exception ee)
        {
        }
        finally
        {
            Response.Redirect("shoppingComplete.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (balancePayTxt.Text == null)
        {
            balancePayTxt.Text = "0";
        }
        decimal payTxt = decimal.Parse(balancePayTxt.Text);
        if (payTxt <= Address.GetAddressByID().Balance)
        {
            balancePay.Text = balancePayTxt.Text;
            sumPrices();
        }
        else
        {
            failTxt.Text = "支付金额必须小于帐户余额";
        }
    }
}
