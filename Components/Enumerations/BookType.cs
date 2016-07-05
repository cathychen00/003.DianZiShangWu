using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public enum BookType
    {
        /// <summary>
        /// 最新图书
        /// </summary>
        newBook = 0,
        /// <summary>
        /// 期待
        /// </summary>
        preview = 1,
        /// <summary>
        /// 特价
        /// </summary>
        cheap=2,
        /// <summary>
        /// 分类图书
        /// </summary>
        catID=3,
        /// <summary>
        /// 图书排行
        /// </summary>
        topSale=4,
        /// <summary>
        /// 搜索
        /// </summary>
        Search=5,
        /// <summary>
        /// 教师
        /// </summary>
        Teacher=6,
        /// <summary>
        /// 丛书
        /// </summary>
        Catena=7,
        /// <summary>
        /// 团购图书
        /// </summary>
        TG=8
    }
}
