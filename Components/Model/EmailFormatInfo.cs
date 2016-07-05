using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
   public class EmailFormatInfo
    {
       private int intID;
       private string strEmailType;
       private string strEmailTitle;
       private string strEmailTemplete;
       private string strExplainInfo;
       private bool isSend;

       /// <summary>
       /// 类型编号
       /// </summary>
       public int EmailID
       {
           get { return intID; }
           set { intID = value; }
       }

       /// <summary>
       /// 类型
       /// </summary>
       public string EmailType
       {
           get { return strEmailType; }
           set { strEmailType = value; }
       }

       /// <summary>
       /// 标题
       /// </summary>
       public string EmailTitle
       {
           get { return strEmailTitle; }
           set { strEmailTitle = value; }
       }

       /// <summary>
       /// 模板
       /// </summary>
       public string EmailTemplete
       {
           get { return strEmailTemplete; }
           set { strEmailTemplete = value; }
       }

       /// <summary>
       /// 说明
       /// </summary>
       public string ExplainInfo
       {
           get { return strExplainInfo; }
           set { strExplainInfo = value; }
       }


       /// <summary>
       /// 是否启用
       /// </summary>
       public bool IsSend
       {
           get { return isSend; }
           set { isSend = value; }
       }
    }
}
