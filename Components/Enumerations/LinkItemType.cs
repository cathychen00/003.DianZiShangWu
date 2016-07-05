using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 链接管理操作类型
    /// </summary>
    public enum LinkItemType
    {
        /// <summary>
        /// 显示全部链接
        /// </summary>
        All=0,
        /// <summary>
        /// 已通过的链接
        /// </summary>
        Arrowed = 1,
         /// <summary>
        /// 申请中的链接
        /// </summary>
        Arrowing=2,
        /// <summary>
        /// 显示主页的链接
        /// </summary> 
        Mained=3,
        /// <summary>
        /// 未显示在主页的链接
        /// </summary>
        Maining = 4,
        /// <summary>
        /// 显示文字链接
        /// </summary>
        Text=5,
        /// <summary>
        /// 显示图片链接
        /// </summary>
        Image=6,
    }
}
