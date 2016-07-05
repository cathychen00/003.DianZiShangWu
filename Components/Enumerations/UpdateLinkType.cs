using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public enum UpdateLinkType
    {
        //更新操作
        /// <summary>
        /// 基本信息
        /// </summary>
        LinkMessage = 0,
        /// <summary>
        /// 是否显示在首页
        /// </summary>
        IsMained = 1,
        /// <summary>
        /// 是否通过
        /// </summary>
        IsAllowed = 2,
        /// <summary>
        /// 排序
        /// </summary>
        Order=3
    }
}
