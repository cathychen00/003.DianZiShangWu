using System.Collections;
namespace Jiaen.Components
{
    /// <summary>
    /// 站点设置
    /// </summary>
    public class SiteSettings
    {
        private Hashtable settings = new Hashtable();
        //站点名称,站点介绍,Logo,Banner,样式

        //验证码 是否启用水印
        //注册,前台登录,后台登录,评论,留言
        //最新图书,站点动态,畅销排行,点击排行,期书推荐
        //翻页 首页信息 

        //图书浏览,

        public Hashtable Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        #region 站点信息

        /// <summary>
        /// 站点名称
        /// </summary>
        public string SiteName
        {
            get
            {
                string key = "SiteName";

                if (settings[key] != null)
                    return (string)settings[key];
                else
                    return "电子商务网站";
            }
            set { settings["SiteName"] = value; }
        }

        /// <summary>
        /// 站点简介
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
        /// 站点Logo
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
        /// 站点Banner
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
        /// 站点样式
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
        /// 服务条款
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
        /// 图书显示条数
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
        /// 底部版权信息
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

        #region 水印相关 

        /// <summary>
        /// 是否打开水印功能
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
        /// 水印类型
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
        /// 水印文字
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
        /// 水印图片
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

        #region 广告

        /// <summary>
        /// 顶部广告
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
        /// 头部广告
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
        /// 团购最少数量
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
