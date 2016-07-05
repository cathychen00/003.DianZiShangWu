using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.BLL;
using Jiaen.Components;
/// <summary>
/// DataFormat 的摘要说明
/// </summary>
public class DataFormat
{
   

    public static string OrderFormat(int orderStatus)
    {
        string statusTxt="";
        switch (orderStatus)
        {
            case -1:
                statusTxt = "等待审核中";
                break;
            case 0:
                statusTxt = "已通过审核";
                break;
            case 1:
                statusTxt = "已付款，等待发货";
                break;
            case 2:
                statusTxt = "已发货";
                break;
            case 3:
                statusTxt = "订单已结束";
                break;
            case 4:
                statusTxt = "订单已取消";
                break;
        }
        return statusTxt;
    }

    public static string getPay()
    {
        string payName = "";
        int pay = Address.GetAddressByID().PayType;
        if (pay == -1)
        {
            payName = "货到付款";
        }
        else
        {
            payName = Payment.GetPaymentByID(pay).PayName;
        }
        return payName;
    }

    public static string getPay(int payType)
    {
        string payName = "";
        if (payType == -1)
        {
            payName = "货到付款";
        }
        else
        {
            payName = Payment.GetPaymentByID(payType).PayName;
        }
        return payName;
    }

    public static string getSend(int sendType)
    {
        return Send.GetSendByID(sendType).Name;
    }

    public static string getNeedPay(decimal PayPrice)
    {
        string payTxt = "";
        if (PayPrice == 0)
        {
            payTxt = "此订单已支付结束";
        }
        else
        {
            payTxt = "还需支付" + string.Format("{0:c}", PayPrice) + "元";
        }
        return payTxt;
    }

    public static string getSumPay(decimal balancePrice,decimal otherPrice)
    {
        return string.Format("{0:c}",(balancePrice + otherPrice));
    }

    public static string isTg(bool isTg)
    {
        string TgTxt = "";
        if (isTg)
        {
            TgTxt = "<font color=red>(此为团购定单)</font>";
        }
        return TgTxt;
    }

    public static string isSend(DateTime addDate,DateTime sendDate)
    {
        string SendTxt = "";
        if (addDate.CompareTo(sendDate) == 0)
        {
            SendTxt = "尚未发货";
        }
        else
        {
            SendTxt = "已发货:"+sendDate.ToString();
        }
        return SendTxt;
    }

    public static string getRate(int rate)
    {
        string imgs = "";
        if (rate > 0)
        {
            string img = @"<img src='images/art.gif' alt='alt' width='13' height='12' />";
            for (int i = 1; i <= rate; i++)
            {
                imgs += img;
            }
        }
        return imgs;
    }

    public static string getBookImage(string image)
    {
        string img = "";
        if (image.Length > 0)
        {
            img = image;

        }
        else
        {
            img = @"<img src='images/22.jpg' alt='alt' width='13' height='12' />";
        }
        return img;
    }

    public static string getSize(int size)
    {
        string sizeTxt = "";
      if(size < 1024)
  return Convert.ToString(size*100/100) + " bytes";
 if(size < 1048576)
  return Convert.ToString(size / 1024*100/100) + "KB";
 if(size < 1073741824)
    return Convert.ToString(size / 1048576*100/100) + "MB";
  return Convert.ToString(size / 1073741824*100/100) + "GB";
       
    }



}
