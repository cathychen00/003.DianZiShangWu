using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// վ�㶯̬ʵ����
    /// </summary>
   public class SiteDynamicInfo
    {
       private int intDynamicID;
       private string strDynamicTitle;
       private string strDynamicCss;
       private string strDynamicUrl;
       private string strTarget;
       private bool isShowNew;
       private string strDynamicContent;
       private DateTime dtAddDate;
       private int intReadCount;

       /// <summary>
       /// �Ķ�����
       /// </summary>
       public int ReadCount
       {
           get { return intReadCount; }
           set { intReadCount = value; }
       }

       /// <summary>
       /// վ�㶯̬���
       /// </summary>
       public int DynamicID
       {
           get { return intDynamicID; }
           set { intDynamicID = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string DynamicTitle
       {
           get { return strDynamicTitle; }
           set { strDynamicTitle = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string DynamicContent
       {
           get { return strDynamicContent; }
           set { strDynamicContent = value; }
       }

       /// <summary>
       /// ������ʽ
       /// </summary>
       public string DynamicCss
       {
           get { return strDynamicCss; }
           set { strDynamicCss = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string DynamicUrl
       {
           get { return strDynamicUrl; }
           set { strDynamicUrl = value; }
       }

       /// <summary>
       /// ���ӷ�ʽ
       /// </summary>
       public string Target
       {
           get { return strTarget; }
           set { strTarget = value; }
       }

       /// <summary>
       /// �Ƿ���ʾnew����
       /// </summary>
       public bool IsShowNew
       {
           get { return isShowNew; }
           set { isShowNew = value; }
       }

       /// <summary>
       /// �Ƿ���ʾnew����
       /// </summary>
       public DateTime AddDate
       {
           get { return dtAddDate; }
           set { dtAddDate = value; }
       }
    }
}
