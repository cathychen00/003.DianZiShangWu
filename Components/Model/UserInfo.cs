using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// �û�ʵ����
    /// </summary>
   public class UserInfo
    {
       private int intUserID;
       private string strUserName;
       private string strPassWord;
       private string strEmail;
       private DateTime dtAddDate;

       /// <summary>
       /// �û����
       /// </summary>
       public int UserID
       {
           get { return intUserID; }
           set { intUserID = value; }
       }

       /// <summary>
       /// �û�����
       /// </summary>
       public string UserName
       {
           get { return strUserName; }
           set { strUserName = value; }
       }

       /// <summary>
       /// ���Ա��
       /// </summary>
       public string PassWord
       {
           get { return strPassWord; }
           set { strPassWord = value; }
       }

       /// <summary>
       /// ���Ա��
       /// </summary>
       public string Email
       {
           get { return strEmail; }
           set { strEmail = value; }
       }

       /// <summary>
       /// ע��ʱ��
       /// </summary>
       public DateTime AddDate
       {
           get { return dtAddDate; }
           set { dtAddDate = value; }
       }
    }
}
