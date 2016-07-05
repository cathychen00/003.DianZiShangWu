using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 收藏夹
    /// </summary>
   public class FavBookInfo:BookInfo
    {
       private int intFavID;
       private DateTime dtAddDate;
       private string strUserName;


       /// <summary>
       /// 收藏图书编号
       /// </summary>
       public int FavID
       {
           get { return intFavID; }
           set { intFavID = value; }
       }

       /// <summary>
       /// 用户
       /// </summary>
       public string UserName
       {
           get { return strUserName; }
           set { strUserName = value; }
       }
    }
}
