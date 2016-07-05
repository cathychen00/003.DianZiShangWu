using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 图书广告实体类
    /// </summary>
    public class ImageBookInfo
    {
        private int intImageID;
        private string strImageURL;
        private string strLinkURL;
        private int intImageOrder;
        private int intImageStation;
        private DateTime addDate;
        private bool isMain;


        /// <summary>
        /// 图片ID
        /// </summary>
        public int ImageID
        {
            get { return intImageID; }
            set { intImageID = value; }
        }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string ImageURL
        {
            get { return strImageURL; }
            set { strImageURL = value; }
        }

        /// <summary>
        /// 超链接
        /// </summary>
        public string LinkURL
        {
            get { return strLinkURL; }
            set { strLinkURL = value; }
        }

        /// <summary>
        /// 图片排序
        /// </summary>
        public int ImageOrder
        {
            get { return intImageOrder; }
            set { intImageOrder = value; }
        }


        /// <summary>
        /// 图片位置
        /// </summary>
        public int ImageStation
        {
            get { return intImageStation; }
            set { intImageStation = value; }
        }

        /// <summary>
        /// 是否显示在首页
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
    }
}
