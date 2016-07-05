using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 出版社实体
    /// </summary>
    public class PublishInfo
    {
        private int intPublishID;
        private string strPublishName;
        private string strPublishDec;
        private DateTime dtAddDate;
        private bool isMain;

        /// <summary>
        /// 出版社编号
        /// </summary>
        public int PublishID
        {
            get { return intPublishID; }
            set { intPublishID = value; }
        }


        /// <summary>
        /// 出版社名字
        /// </summary>
        public string PublishName
        {
            get { return strPublishName; }
            set { strPublishName = value; }
        }

        /// <summary>
        /// 是否显示首页
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// 出版社介绍
        /// </summary>
        public string PublishDec
        {
            get { return strPublishDec; }
            set { strPublishDec = value; }
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
