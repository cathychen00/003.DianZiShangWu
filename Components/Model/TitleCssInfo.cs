using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 标题样式实体类
    /// </summary>
    public class TitleCssInfo
    {
        private int intTitleCssID;
        private string strTitleCssName;
        private string strTitleCssDec;
        private DateTime dtAddDate;

        /// <summary>
        /// 样式编号
        /// </summary>
        public int TitleCssID
        {
            get { return intTitleCssID; }
            set { intTitleCssID = value; }
        }

        /// <summary>
        /// 样式名字
        /// </summary>
        public string TitleCssName
        {
            get { return strTitleCssName; }
            set { strTitleCssName = value; }
        }

        /// <summary>
        /// 样式说明
        /// </summary>
        public string TitleCssDec
        {
            get { return strTitleCssDec; }
            set { strTitleCssDec = value; }
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
