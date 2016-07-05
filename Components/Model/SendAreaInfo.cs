using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ��������
    /// </summary>
    public class SendAreaInfo
    {
        private int intAreaID;
        private string strName;
        private string strCode;
        private int intParentID;
        private string strDec;
        private int intSort;
        private bool isSended;

        private IList<SendAreaInfo> area;

        public IList<SendAreaInfo> Area
        {
            get { return area; }
            set { area = value; }
        }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public bool IsSended
        {
            get { return isSended; }
            set { isSended = value; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public int AreaID
        {
            get { return intAreaID; }
            set { intAreaID = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public int ParentID
        {
            get { return intParentID; }
            set { intParentID = value; }
        }

        /// <summary>
        /// ˵��
        /// </summary>
        public string Dec
        {
            get { return strDec; }
            set { strDec = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Sort
        {
            get { return intSort; }
            set { intSort = value; }
        }

    }
}
