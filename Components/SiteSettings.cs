using System.Collections;
namespace Jiaen.Components
{
    /// <summary>
    /// վ������
    /// </summary>
    public class SiteSettings
    {
        private Hashtable settings = new Hashtable();
        //վ������,վ�����,Logo,Banner,��ʽ

        //��֤�� �Ƿ�����ˮӡ
        //ע��,ǰ̨��¼,��̨��¼,����,����
        //����ͼ��,վ�㶯̬,��������,�������,�����Ƽ�
        //��ҳ ��ҳ��Ϣ 

        //ͼ�����,

        public Hashtable Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        #region վ����Ϣ

        /// <summary>
        /// վ������
        /// </summary>
        public string SiteName
        {
            get
            {
                string key = "SiteName";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "����������վ";
            }
            set { settings["SiteName"] = value; }
        }

        /// <summary>
        /// վ����
        /// </summary>
        public string SiteDec
        {
            get
            {

                string key = "SiteDec";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteDec"] = value; }
        }

        /// <summary>
        /// վ��Logo
        /// </summary>
        public string SiteLogo
        {
            get
            {
                string key = "SiteLogo";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteLogo"] = value; }
        }

        /// <summary>
        /// վ��Banner
        /// </summary>
        public string SiteBanner
        {
            get
            {
                string key = "SiteBanner";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteBanner"] = value; }
        }

        /// <summary>
        /// վ����ʽ
        /// </summary>
        public string SiteStyle
        {
            get
            {
                string key = "SiteStyle";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteStyle"] = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string ServiceTxt
        {
            get
            {
                string key = "ServiceTxt";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["ServiceTxt"] = value; }
        }

        /// <summary>
        /// ͼ����ʾ����
        /// </summary>
        public int BookCount
        {
            get
            {
                string key = "BookCount";

                if (settings[key] != null)
                    return (int)settings[key];
                else
                    return 10;
            }
            set { settings["BookCount"] = value; }
        }

        /// <summary>
        /// �ײ���Ȩ��Ϣ
        /// </summary>
        public string SiteBottomDec
        {
            get
            {
                string key = "SiteBottomDec";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteBottomDec"] = value; }
        }

        #endregion

        #region ˮӡ��� 

        /// <summary>
        /// �Ƿ��ˮӡ����
        /// </summary>
        public bool EnableWatermark
        {
            get
            {
                string key = "EnableWatermark";

                if (settings[key] != null)
                    return (bool)settings[key];
                else
                    return false;
            }
            set { settings["EnableWatermark"] = value; }
        }

        /// <summary>
        /// ˮӡ����
        /// </summary>
        public WatermarkType WatermarkType
        {
            get
            {

                string key = "WatermarkType";

                if (settings[key] != null)
                    return (WatermarkType)settings[key];
                else
                    return WatermarkType.Text;
            }
            set { settings["WatermarkType"] = value; }
        }

        /// <summary>
        /// ˮӡ����
        /// </summary>
        public string WatermarkText
        {
            get
            {
                string key = "WatermarkText";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "Powered by Jiaen.com";
            }
            set { settings["WatermarkText"] = value; }
        }

        /// <summary>
        /// ˮӡͼƬ
        /// </summary>
        public string WatermarkFileName
        {
            get
            {
                string key = "WatermarkFileName";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["WatermarkFileName"] = value; }
        }


        #endregion

        #region ���

        /// <summary>
        /// �������
        /// </summary>
        public string SiteBottomAd
        {
            get
            {
                string key = "SiteBottomAd";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteBottomAd"] = value; }
        }

        /// <summary>
        /// ͷ�����
        /// </summary>
        public string SiteMiddleAd
        {
            get
            {
                string key = "SiteMiddleAd";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "";
            }
            set { settings["SiteMiddleAd"] = value; }
        }


        #endregion

        /// <summary>
        /// �Ź���������
        /// </summary>
        public int TgNum
        {
            get
            {
                string key = "TgNum";

                if (settings[key] != null)
                    return (int)settings[key];
                else
                    return 20;
            }
            set { settings["TgNum"] = value; }
        }
    }
}
