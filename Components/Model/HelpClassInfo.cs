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
        /// 类别编号
        /// </summary>
        public int ClassID
        {
            get { return intClassID; }
            set { intClassID = value; }
        }

        /// <summary>
        /// 是否显示首页
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string ClassName
        {
            get { return strClassName; }
            set { strClassName = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order
        {
            get { return intOrder; }
            set { intOrder = value; }
        }

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
    }
}
