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
   public class TitleCss
    {
       private static readonly ITitleCss tc = DataAccess.CreateTitleCss();
        /// <summary>
        /// 获取标题样式列表
        /// </summary>
        /// <returns></returns>
       public static IList<TitleCssInfo> GetTitleCss()
       {
           return tc.GetTitleCss();
       }

        /// <summary>
        /// 获取特定标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       public static TitleCssInfo GetTitleCssByID(int titleCssID)
       {
           return tc.GetTitleCssByID(titleCssID);
       }

        /// <summary>
        /// 添加标题样式信息
        /// </summary>
        /// <param name="link"></param>
       public static void InsertTitleCss(TitleCssInfo titleCss)
       {
           tc.InsertTitleCss(titleCss);
       }

        /// <summary>
        /// 更新标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       public static int UpdateTitleCss(TitleCssInfo titleCss)
       {
          return tc.UpdateTitleCss(titleCss);
       }

        /// <summary>
        /// 删除标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       public static int DeleteTitleCss(int titleCssID)
       {
           return tc.DeleteTitleCss(titleCssID);
       }
    }
}
