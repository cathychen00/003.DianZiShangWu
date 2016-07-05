using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public class GuestBookInfo
    {
        private int intGbID;
        private int intUserID;
        private string strUserName;
        private string strTitle;
        private string strContent;
        private string strEmail;
        private DateTime dtPostTime;
        private int intSendUserID;

        /// <summary>
        /// 留言编号
        /// </summary>
        public int GbID
        {
            get { return intGbID; }
            set { intGbID = value; }
        }

        /// <summary>
        /// 发送留言用户编号
        /// </summary>
        public int SendUserID
        {
            get { return intSendUserID; }
            set { intSendUserID = value; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }

        /// <summary>
        /// 留言者
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// 留言标题
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }

        /// <summary>
        /// 留言者电子信箱
        /// </summary>
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime PostTime
        {
            get { return dtPostTime; }
            set { dtPostTime = value; }
        }
    }
}
