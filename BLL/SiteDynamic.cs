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
    public class SiteDynamic
    {
        private static readonly ISiteDynamic sd = DataAccess.CreateSiteDynamic();

        /// <summary>
        /// 获取新闻
        /// </summary>
        /// <returns></returns>
        public static IList<SiteDynamicInfo> GetSiteDynamic(SiteDynamicType type)
        {
            return sd.GetSiteDynamic(type);
        }

        /// <summary>
        /// 获取特定标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static SiteDynamicInfo GetSiteDynamicByID(int siteDynamicID)
        {
            return sd.GetSiteDynamicByID(siteDynamicID);
        }

        /// <summary>
        /// 添加标题样式信息
        /// </summary>
        /// <param name="link"></param>
        public static void InsertSiteDynamic(SiteDynamicInfo siteDynamic)
        {
            sd.InsertSiteDynamic(siteDynamic);

        }

        /// <summary>
        /// 更新标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateSiteDynamic(SiteDynamicInfo siteDynamic)
        {
            return sd.UpdateSiteDynamic(siteDynamic);
        }

        /// <summary>
        /// 删除标题样式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteSiteDynamic(int siteDynamicID)
        {
            return sd.DeleteSiteDynamic(siteDynamicID);
        }
    }
}
