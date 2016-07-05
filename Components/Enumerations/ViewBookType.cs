using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public enum ViewBookType
    {
        /// <summary>
        /// 最新图书
        /// </summary>
        New=0,
        /// <summary>
        /// 销售排行
        /// </summary>
        Sale=1,
        /// <summary>
        /// 点击排行
        /// </summary>
        Read=2,
        /// <summary>
        /// 好书推荐
        /// </summary>
        Good=3,
        /// <summary>
        /// 期书
        /// </summary>
        Expect=4,
        /// <summary>
        /// 重点新书
        /// </summary>
        NewAndGood=5
    }
}
