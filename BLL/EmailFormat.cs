using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;

namespace Jiaen.BLL
{
    [DataObjectAttribute]
   public class EmailFormat
    {
       private static readonly IEmailFormat emails = DataAccess.CreateEmailFormat();

       /// <summary>
       /// 获取新闻
       /// </summary>
       /// <returns></returns>
     public static IList<EmailFormatInfo> GetEmailFormat()
       {
           return emails.GetEmailFormat();
       }

       /// <summary>
       /// 获取特定标题样式信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static EmailFormatInfo GetEmailFormatByID(int emailFormatID)
       {
           return emails.GetEmailFormatByID(emailFormatID);
       }


       /// <summary>
       /// 更新标题样式信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateEmailFormat(EmailFormatInfo emailFormat)
       {
           return emails.UpdateEmailFormat(emailFormat);
       }
    }
}
