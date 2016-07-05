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
        /// 教师编号
        /// </summary>
        public int TeacherID
        {
            get { return intTeacherID; }
            set { intTeacherID = value; }
        }

        /// <summary>
        /// 教师编号
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// 教师编号
        /// </summary>
        public string Image
        {
            get { return strImage; }
            set { strImage = value; }
        }

        /// <summary>
        /// 自我介绍
        /// </summary>
        public string SmallDec
        {
            get { return strSmallDec; }
            set { strSmallDec = value; }
        }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Dec
        {
            get { return strDec; }
            set { strDec = value; }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime AddDate
        {
            get { return dtAddDate; }
            set { dtAddDate = value; }
        }
    }
}
