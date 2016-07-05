using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 站点动态实体类
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
       /// 阅读数量
       /// </summary>
       public int ReadCount
       {
           get { return intReadCount; }
           set { intReadCount = value; }
       }

       /// <summary>
       /// 站点动态编号
       /// </summary>
       public int DynamicID
       {
           get { return intDynamicID; }
           set { intDynamicID = value; }
       }

       /// <summary>
       /// 标题
       /// </summary>
       public string DynamicTitle
       {
           get { return strDynamicTitle; }
           set { strDynamicTitle = value; }
       }

       /// <summary>
       /// 内容
       /// </summary>
       public string DynamicContent
       {
           get { return strDynamicContent; }
           set { strDynamicContent = value; }
       }

       /// <summary>
       /// 标题样式
       /// </summary>
       public string DynamicCss
       {
           get { return strDynamicCss; }
           set { strDynamicCss = value; }
       }

       /// <summary>
       /// 链接
       /// </summary>
       public string DynamicUrl
       {
           get { return strDynamicUrl; }
           set { strDynamicUrl = value; }
       }

       /// <summary>
       /// 链接方式
       /// </summary>
       public string Target
       {
           get { return strTarget; }
           set { strTarget = value; }
       }

       /// <summary>
       /// 是否显示new字样
       /// </summary>
       public bool IsShowNew
       {
           get { return isShowNew; }
           set { isShowNew = value; }
       }

       /// <summary>
       /// 是否显示new字样
       /// </summary>
       public DateTime AddDate
       {
           get { return dtAddDate; }
           set { dtAddDate = value; }
       }
    }
}
