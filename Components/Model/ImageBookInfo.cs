using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ͼ����ʵ����
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
        /// ͼƬID
        /// </summary>
        public int ImageID
        {
            get { return intImageID; }
            set { intImageID = value; }
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string ImageURL
        {
            get { return strImageURL; }
            set { strImageURL = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string LinkURL
        {
            get { return strLinkURL; }
            set { strLinkURL = value; }
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public int ImageOrder
        {
            get { return intImageOrder; }
            set { intImageOrder = value; }
        }


        /// <summary>
        /// ͼƬλ��
        /// </summary>
        public int ImageStation
        {
            get { return intImageStation; }
            set { intImageStation = value; }
        }

        /// <summary>
        /// �Ƿ���ʾ����ҳ
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
    }
}
