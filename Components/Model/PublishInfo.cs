using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ������ʵ��
    /// </summary>
    public class PublishInfo
    {
        private int intPublishID;
        private string strPublishName;
        private string strPublishDec;
        private DateTime dtAddDate;
        private bool isMain;

        /// <summary>
        /// ��������
        /// </summary>
        public int PublishID
        {
            get { return intPublishID; }
            set { intPublishID = value; }
        }


        /// <summary>
        /// ����������
        /// </summary>
        public string PublishName
        {
            get { return strPublishName; }
            set { strPublishName = value; }
        }

        /// <summary>
        /// �Ƿ���ʾ��ҳ
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// ���������
        /// </summary>
        public string PublishDec
        {
            get { return strPublishDec; }
            set { strPublishDec = value; }
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
