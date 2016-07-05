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
        /// ���Ա��
        /// </summary>
        public int GbID
        {
            get { return intGbID; }
            set { intGbID = value; }
        }

        /// <summary>
        /// ���������û����
        /// </summary>
        public int SendUserID
        {
            get { return intSendUserID; }
            set { intSendUserID = value; }
        }

        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// ���Ա���
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }

        /// <summary>
        /// �����ߵ�������
        /// </summary>
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime PostTime
        {
            get { return dtPostTime; }
            set { dtPostTime = value; }
        }
    }
}
