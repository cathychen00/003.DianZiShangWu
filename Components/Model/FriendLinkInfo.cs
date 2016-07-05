using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace Jiaen.Components
{
    /// <summary>
    /// 友情链接实体类
    /// </summary>
    public class FriendLinkInfo
    {
        //编号，名称，链接，logo,是否首页显示
        //申请是否通过，链接类型，加入时间
        private int intID;
        private string strName;
        private string strUrl;
        private string strLogo;
        private int intOrder;
        private bool isMain;
        private bool isArrow;
        private DateTime dtAddDate;

        /// <summary>
        /// 链接编号
        /// </summary>
        public int LinkID
        {
            get { return intID; }
            set { intID = value; }
        }

        /// <summary>
        /// 链接名称
        /// </summary>
        public string LinkName
        {
            get { return strName; }
            set { strName = value; }

        }

        /// <summary>
        /// 链接URL
        /// </summary>
        public string LinkURL
        {
            get { return strUrl; }
            set { strUrl = value; }
        }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string LinkLogo
        {
            get { return strLogo; }
            set { strLogo = value; }
        }

        /// <summary>
        /// 链接排序
        /// </summary>
        public int LinkOrder
        {
            get { return intOrder; }
            set { intOrder = value; }
        }

        /// <summary>
        /// 是否首页显示
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// 申请是否通过
        /// </summary>
        public bool IsArrow
        {
            get { return isArrow; }
            set { isArrow = value; }
        }

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime AddDate
        {
            get { return dtAddDate; }
            set { dtAddDate = value; }
        }
    }
}