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
       /// ��ȡ����
       /// </summary>
       /// <returns></returns>
     public static IList<EmailFormatInfo> GetEmailFormat()
       {
           return emails.GetEmailFormat();
       }

       /// <summary>
       /// ��ȡ�ض�������ʽ��Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static EmailFormatInfo GetEmailFormatByID(int emailFormatID)
       {
           return emails.GetEmailFormatByID(emailFormatID);
       }


       /// <summary>
       /// ���±�����ʽ��Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateEmailFormat(EmailFormatInfo emailFormat)
       {
           return emails.UpdateEmailFormat(emailFormat);
       }
    }
}
