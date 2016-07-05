using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Jiaen.Components;
using Jiaen.BLL;

namespace Jiaen.Controls
{
    public enum ImageType
    {
        Logo,
        Banner,
        Ad
    }
    public class SiteImage : System.Web.UI.WebControls.Image
    {
        private string logo = SiteSetting.GetSiteSettings("jiaen").SiteLogo;
        private string banner = SiteSetting.GetSiteSettings("jiaen").SiteBanner;
        private string ad = SiteSetting.GetSiteSettings("jiaen").SiteBottomAd;
        
        public override string ImageUrl
        {
            get
            {
                string imageUrl = "";
                if (this.ImageType == ImageType.Logo)
                {
                    imageUrl = logo;
                }
                else if (this.ImageType == ImageType.Banner)
                {
                    imageUrl = banner;
                }
                else
                    if (this.ImageType == ImageType.Ad)
                    {
                        imageUrl = ad;
                    }
                return imageUrl;
            }
            set
            {
                base.ImageUrl = value;
            }
        }

        public virtual ImageType ImageType
        {
            get
            {
                object t = ViewState["ImageType"];
                return (t == null) ? ImageType.Logo : (ImageType)t;
            }
            set
            {
                ViewState["ImageType"] = value;
            }
        }
    }
}
