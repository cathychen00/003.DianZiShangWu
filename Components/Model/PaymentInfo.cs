using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
   public class PaymentInfo
    {
       private int intPaymentID;

       private int  intPayType;
       private string strPayName;
       private int intOnLinePayType;
       private string strUserName;
       private string strPrivateKey;
       private string strDec;
       private bool status;
       private string strPartnerID;

       /// <summary>
       /// 用户标识
       /// </summary>
       public string PartnerID
       {
           get { return strPartnerID; }
           set { strPartnerID = value; }
       }

       /// <summary>
       /// 支付编号
       /// </summary>
       public int PaymentID
       {
           get { return intPaymentID; }
           set { intPaymentID = value; }
       }

       /// <summary>
       /// 支付方式
       /// </summary>
       public int PayType
       {
           get { return intPayType; }
           set { intPayType = value; }
       }

       /// <summary>
       /// 在线支付方式
       /// </summary>
       public int OnLinePayType
       {
           get { return intOnLinePayType; }
           set { intOnLinePayType = value; }
       }

       /// <summary>
       /// 支付名称
       /// </summary>
       public string PayName
       {
           get { return strPayName; }
           set { strPayName = value; }
       }

       /// <summary>
       /// 用户名称
       /// </summary>
       public string UserName
       {
           get { return strUserName; }
           set { strUserName = value; }
       }

       /// <summary>
       /// 支付密钥
       /// </summary>
       public string PrivateKey
       {
           get { return strPrivateKey; }
           set { strPrivateKey = value; }
       }

       /// <summary>
       /// 状态
       /// </summary>
       public bool Status
       {
           get { return status; }
           set { status = value; }
       }

       /// <summary>
       /// 说明
       /// </summary>
       public string Dec
       {
           get { return strDec; }
           set { strDec = value; }
       }
    }
}
