using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 配送区域
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
        /// 送货上门
        /// </summary>
        public bool IsSended
        {
            get { return isSended; }
            set { isSended = value; }
        }

        /// <summary>
        /// 配送区域编号
        /// </summary>
        public int AreaID
        {
            get { return intAreaID; }
            set { intAreaID = value; }
        }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// 地区编号
        /// </summary>
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        /// <summary>
        /// 子区域
        /// </summary>
        public int ParentID
        {
            get { return intParentID; }
            set { intParentID = value; }
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string Dec
        {
            get { return strDec; }
            set { strDec = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return intSort; }
            set { intSort = value; }
        }

    }
}
