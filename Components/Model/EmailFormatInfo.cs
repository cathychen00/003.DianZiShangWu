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
       /// ���ͱ��
       /// </summary>
       public int EmailID
       {
           get { return intID; }
           set { intID = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string EmailType
       {
           get { return strEmailType; }
           set { strEmailType = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string EmailTitle
       {
           get { return strEmailTitle; }
           set { strEmailTitle = value; }
       }

       /// <summary>
       /// ģ��
       /// </summary>
       public string EmailTemplete
       {
           get { return strEmailTemplete; }
           set { strEmailTemplete = value; }
       }

       /// <summary>
       /// ˵��
       /// </summary>
       public string ExplainInfo
       {
           get { return strExplainInfo; }
           set { strExplainInfo = value; }
       }


       /// <summary>
       /// �Ƿ�����
       /// </summary>
       public bool IsSend
       {
           get { return isSend; }
           set { isSend = value; }
       }
    }
}
