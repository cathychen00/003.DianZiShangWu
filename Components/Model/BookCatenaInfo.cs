using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ͼ��ϵ��ʵ����
    /// </summary>
    public class BookCatenaInfo
    {
        private int intCatenaID;
        private string strCatenaName;
        private string strCatenaDec;
        private DateTime dtAddDate;

        /// <summary>
        /// ͼ��ϵ�б��
        /// </summary>
        public int CatenaID
        {
            get { return intCatenaID; }
            set { intCatenaID = value; }
        }


        /// <summary>
        /// ͼ��ϵ������
        /// </summary>
        public string CatenaName
        {
            get { return strCatenaName; }
            set { strCatenaName = value; }
        }

        /// <summary>
        /// ͼ��ϵ�н���
        /// </summary>
        public string CatenaDec
        {
            get { return strCatenaDec; }
            set { strCatenaDec = value; }
        }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime AddDate
        {
            get { return dtAddDate; }
            set { dtAddDate = value; }
        }
    }
}
