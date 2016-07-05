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
       /// 分类编号
       /// </summary>
       public int ID
       {
           get { return intID; }
           set { intID = value; }
       }

       /// <summary>
       /// 类别名称
       /// </summary>
       public string ClassName
       {
           get { return strClassName; }
           set { strClassName = value; }
       }

       /// <summary>
       /// 排序
       /// </summary>
       public int Order
       {
           get { return odrder; }
           set { odrder = value; }
       }

       /// <summary>
       /// 加入时间
       /// </summary>
       public DateTime AddDate
       {
           get { return addDate; }
           set { addDate = value; }
       }
    }
}
