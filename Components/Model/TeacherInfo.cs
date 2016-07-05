using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public class TeacherInfo
    {
        private int intTeacherID;
        private string strName;
        private string strDec;
        private string strImage;
        private bool isMain;
        private string strSmallDec;
        private DateTime dtAddDate;

        /// <summary>
        /// ��ʦ���
        /// </summary>
        public int TeacherID
        {
            get { return intTeacherID; }
            set { intTeacherID = value; }
        }

        /// <summary>
        /// ��ʦ���
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// ��ʦ���
        /// </summary>
        public string Image
        {
            get { return strImage; }
            set { strImage = value; }
        }

        /// <summary>
        /// ���ҽ���
        /// </summary>
        public string SmallDec
        {
            get { return strSmallDec; }
            set { strSmallDec = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Dec
        {
            get { return strDec; }
            set { strDec = value; }
        }

        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// ʱ��
        /// </summary>
        public DateTime AddDate
        {
            get { return dtAddDate; }
            set { dtAddDate = value; }
        }
    }
}
