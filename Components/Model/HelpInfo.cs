using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public class HelpInfo:HelpClassInfo
    {
        private int intHelpID;

        private string strHelpTitle;
        private string strHelpContent;

        /// <summary>
        /// 类别编号
        /// </summary>
        public int HelpID
        {
            get { return intHelpID; }
            set { intHelpID = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string HelpTitle
        {
            get { return strHelpTitle; }
            set { strHelpTitle = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string HelpContent
        {
            get { return strHelpContent; }
            set { strHelpContent = value; }
        }
    }
}
