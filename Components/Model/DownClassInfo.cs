using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
   public class DownClassInfo
    {
       private int intID;
       private string strClassName;
       private DateTime addDate;
       private int odrder;


       /// <summary>
       /// ������
       /// </summary>
       public int ID
       {
           get { return intID; }
           set { intID = value; }
       }

       /// <summary>
       /// �������
       /// </summary>
       public string ClassName
       {
           get { return strClassName; }
           set { strClassName = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public int Order
       {
           get { return odrder; }
           set { odrder = value; }
       }

       /// <summary>
       /// ����ʱ��
       /// </summary>
       public DateTime AddDate
       {
           get { return addDate; }
           set { addDate = value; }
       }
    }
}
