using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// �ղؼ�
    /// </summary>
   public class FavBookInfo:BookInfo
    {
       private int intFavID;
       private DateTime dtAddDate;
       private string strUserName;


       /// <summary>
       /// �ղ�ͼ����
       /// </summary>
       public int FavID
       {
           get { return intFavID; }
           set { intFavID = value; }
       }

       /// <summary>
       /// �û�
       /// </summary>
       public string UserName
       {
           get { return strUserName; }
           set { strUserName = value; }
       }
    }
}
