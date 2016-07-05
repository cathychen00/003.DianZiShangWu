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
    /// ��������ʵ����
    /// </summary>
    public class FriendLinkInfo
    {
        //��ţ����ƣ����ӣ�logo,�Ƿ���ҳ��ʾ
        //�����Ƿ�ͨ�����������ͣ�����ʱ��
        private int intID;
        private string strName;
        private string strUrl;
        private string strLogo;
        private int intOrder;
        private bool isMain;
        private bool isArrow;
        private DateTime dtAddDate;

        /// <summary>
        /// ���ӱ��
        /// </summary>
        public int LinkID
        {
            get { return intID; }
            set { intID = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string LinkName
        {
            get { return strName; }
            set { strName = value; }

        }

        /// <summary>
        /// ����URL
        /// </summary>
        public string LinkURL
        {
            get { return strUrl; }
            set { strUrl = value; }
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string LinkLogo
        {
            get { return strLogo; }
            set { strLogo = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int LinkOrder
        {
            get { return intOrder; }
            set { intOrder = value; }
        }

        /// <summary>
        /// �Ƿ���ҳ��ʾ
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }

        /// <summary>
        /// �����Ƿ�ͨ��
        /// </summary>
        public bool IsArrow
        {
            get { return isArrow; }
            set { isArrow = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime AddDate
        {
            get { return dtAddDate; }
            set { dtAddDate = value; }
        }
    }
}