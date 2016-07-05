using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 配送方式
    /// </summary>
   public class SendInfo
    {
       private int intSendID;
       private string strName;
       private decimal dPrice;
       private string strDec;


       /// <summary>
       /// 配送方式编号
       /// </summary>
       public int SendID
       {
           get { return intSendID; }
           set { intSendID = value; }
       }

       /// <summary>
       /// 名字
       /// </summary>
       public string Name
       {
           get { return strName; }
           set { strName = value; }
       }

       /// <summary>
       /// 价格
       /// </summary>
       public decimal Price
       {
           get { return dPrice; }
           set { dPrice = value; }
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
