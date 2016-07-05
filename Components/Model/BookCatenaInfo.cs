using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 图书系列实体类
    /// </summary>
    public class BookCatenaInfo
    {
        private int intCatenaID;
        private string strCatenaName;
        private string strCatenaDec;
        private DateTime dtAddDate;

        /// <summary>
        /// 图书系列编号
        /// </summary>
        public int CatenaID
        {
            get { return intCatenaID; }
            set { intCatenaID = value; }
        }


        /// <summary>
        /// 图书系列名字
        /// </summary>
        public string CatenaName
        {
            get { return strCatenaName; }
            set { strCatenaName = value; }
        }

        /// <summary>
        /// 图书系列介绍
        /// </summary>
        public string CatenaDec
        {
            get { return strCatenaDec; }
            set { strCatenaDec = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get { return dtAddDate; }
            set { dtAddDate = value; }
        }
    }
}
