using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 标题样式接口
    /// </summary>
   public interface ITitleCss
    {
        /// <summary>
        /// 获取标题样式列表
        /// </summary>
        /// <returns></returns>
       IList<TitleCssInfo> GetTitleCss();

        /// <summary>
        /// 获取特定标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       TitleCssInfo GetTitleCssByID(int titleCssID);

        /// <summary>
        /// 添加标题样式信息
        /// </summary>
        /// <param name="link"></param>
       void InsertTitleCss(TitleCssInfo titleCss);

        /// <summary>
        /// 更新标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdateTitleCss(TitleCssInfo titleCss);

        /// <summary>
        /// 删除标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteTitleCss(int titleCssID);
    }
}
