using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 用户实体类
    /// </summary>
   public class UserInfo
    {
       private int intUserID;
       private string strUserName;
       private string strPassWord;
       private string strEmail;
       private DateTime dtAddDate;

       /// <summary>
       /// 用户编号
       /// </summary>
       public int UserID
       {
           get { return intUserID; }
           set { intUserID = value; }
       }

       /// <summary>
       /// 用户名字
       /// </summary>
       public string UserName
       {
           get { return strUserName; }
           set { strUserName = value; }
       }

       /// <summary>
       /// 留言编号
       /// </summary>
       public string PassWord
       {
           get { return strPassWord; }
           set { strPassWord = value; }
       }

       /// <summary>
       /// 留言编号
       /// </summary>
       public string Email
       {
           get { return strEmail; }
           set { strEmail = value; }
       }

       /// <summary>
       /// 注册时间
       /// </summary>
       public DateTime AddDate
       {
           get { return dtAddDate; }
           set { dtAddDate = value; }
       }
    }
}
