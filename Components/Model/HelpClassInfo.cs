using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public class HelpClassInfo
    {
        private int intClassID;
        private string strClassName;
        private int intOrder;
        private DateTime addDate;
        private bool isVisible;



        /// <summary>
        /// �����
        /// </summary>
        public int ClassID
        {
            get { return intClassID; }
            set { intClassID = value; }
        }

        /// <summary>
        /// �Ƿ���ʾ��ҳ
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string ClassName
        {
            get { return strClassName; }
            set { strClassName = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Order
        {
            get { return intOrder; }
            set { intOrder = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
    }
}
