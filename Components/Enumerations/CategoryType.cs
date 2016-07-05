using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public enum CategoryType
    {
        /// <summary>
        /// 图书父类
        /// </summary>
        Book = 0,
        /// <summary>
        /// 子类图书
        /// </summary>
        ParesentBook = 1,
        /// <summary>
        /// 显示首页父类
        /// </summary>
        MainBook=2,
        /// <summary>
        /// 显示首页子类图书
        /// </summary>
        MainParesentBook = 3
    }
}
