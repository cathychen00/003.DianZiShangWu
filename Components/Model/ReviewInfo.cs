using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 评论实体
    /// </summary>
    /// <remarks></remarks>
    public class ReviewInfo
    {
        private int intReviewID;
        private int intBookID;
        private string strContent;
        private string strAuthor;
        private DateTime dtPostTime;
        private string strPostIP;
        private int intRate;
        private int intStatus;
        private int intUserID;
        private string strUserName;
        private bool isAuthenticated;

        /// <summary>
        /// 是否登录用户
        /// </summary>
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; }
        }

        /// <summary>
        /// 评论用户
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// 评论编号
        /// </summary>
        public int ReviewID
        {
            get { return intReviewID; }
            set { intReviewID = value; }
        }

        /// <summary>
        /// 图书编号
        /// </summary>
        public int BookID
        {
            get { return intBookID; }
            set { intBookID = value; }
        }

        /// <summary>
        /// 评论信息
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }

        /// <summary>
        /// 评论人昵称
        /// </summary>
        public string Author
        {
            get { return strAuthor; }
            set { strAuthor = value; }
        }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime PostTime
        {
            get { return dtPostTime; }
            set { dtPostTime = value; }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public string PostIP
        {
            get { return strPostIP; }
            set { strPostIP = value; }
        }


        /// <summary>
        /// 评价
        /// </summary>
        public int RateID
        {
            get { return intRate; }
            set { intRate = value; }
        }

        /// <summary>
        /// 评论人身份
        /// </summary>
        public int StatusID
        {
            get { return intStatus; }
            set { intStatus = value; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }
    }
}
