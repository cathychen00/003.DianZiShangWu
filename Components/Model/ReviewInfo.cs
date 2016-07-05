using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ����ʵ��
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
        /// �Ƿ��¼�û�
        /// </summary>
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; }
        }

        /// <summary>
        /// �����û�
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// ���۱��
        /// </summary>
        public int ReviewID
        {
            get { return intReviewID; }
            set { intReviewID = value; }
        }

        /// <summary>
        /// ͼ����
        /// </summary>
        public int BookID
        {
            get { return intBookID; }
            set { intBookID = value; }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }

        /// <summary>
        /// �������ǳ�
        /// </summary>
        public string Author
        {
            get { return strAuthor; }
            set { strAuthor = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime PostTime
        {
            get { return dtPostTime; }
            set { dtPostTime = value; }
        }

        /// <summary>
        /// IP��ַ
        /// </summary>
        public string PostIP
        {
            get { return strPostIP; }
            set { strPostIP = value; }
        }


        /// <summary>
        /// ����
        /// </summary>
        public int RateID
        {
            get { return intRate; }
            set { intRate = value; }
        }

        /// <summary>
        /// ���������
        /// </summary>
        public int StatusID
        {
            get { return intStatus; }
            set { intStatus = value; }
        }

        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }
    }
}
