using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ������ʽʵ����
    /// </summary>
    public class TitleCssInfo
    {
        private int intTitleCssID;
        private string strTitleCssName;
        private string strTitleCssDec;
        private DateTime dtAddDate;

        /// <summary>
        /// ��ʽ���
        /// </summary>
        public int TitleCssID
        {
            get { return intTitleCssID; }
            set { intTitleCssID = value; }
        }

        /// <summary>
        /// ��ʽ����
        /// </summary>
        public string TitleCssName
        {
            get { return strTitleCssName; }
            set { strTitleCssName = value; }
        }

        /// <summary>
        /// ��ʽ˵��
        /// </summary>
        public string TitleCssDec
        {
            get { return strTitleCssDec; }
            set { strTitleCssDec = value; }
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
