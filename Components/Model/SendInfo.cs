using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ���ͷ�ʽ
    /// </summary>
   public class SendInfo
    {
       private int intSendID;
       private string strName;
       private decimal dPrice;
       private string strDec;


       /// <summary>
       /// ���ͷ�ʽ���
       /// </summary>
       public int SendID
       {
           get { return intSendID; }
           set { intSendID = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string Name
       {
           get { return strName; }
           set { strName = value; }
       }

       /// <summary>
       /// �۸�
       /// </summary>
       public decimal Price
       {
           get { return dPrice; }
           set { dPrice = value; }
       }

       /// <summary>
       /// ˵��
       /// </summary>
       public string Dec
       {
           get { return strDec; }
           set { strDec = value; }
       }
    }
}
