using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 新闻动态信息接口
    /// </summary>
    public interface ISiteDynamic
    {
        /// <summary>
        /// 获取新闻
        /// </summary>
        /// <returns></returns>
        IList<SiteDynamicInfo> GetSiteDynamic(SiteDynamicType type);

        /// <summary>
        /// 获取特定标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        SiteDynamicInfo GetSiteDynamicByID(int siteDynamicID);

        /// <summary>
        /// 添加标题样式信息
        /// </summary>
        /// <param name="link"></param>
        void InsertSiteDynamic(SiteDynamicInfo siteDynamic);

        /// <summary>
        /// 更新标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateSiteDynamic(SiteDynamicInfo siteDynamic);

        /// <summary>
        /// 删除标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteSiteDynamic(int siteDynamicID);
    }
}
