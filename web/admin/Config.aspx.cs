using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.BLL;
using Jiaen.Components;
public partial class admin_Config : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataConfig();
        }
    }

    void dataConfig()
    {
        SiteName.Focus();
        SiteSettings site = SiteSetting.GetSiteSettings("jiaen");
        SiteName.Text = site.SiteName;
        SiteLogo.Text = site.SiteLogo;
        SiteBanner.Text = site.SiteBanner;
        SiteBottomAd.Text = site.SiteBottomAd;
        WatermarkList.SelectedValue=site.WatermarkType.ToString();
        WatermarkText.Text = site.WatermarkText;
        WatermarkFileName.Text = site.WatermarkFileName;
        TgNumTxt.Text = site.TgNum.ToString();
        ServiceTxt.Text = site.ServiceTxt;
        SiteBottomDec.Text = site.SiteBottomDec;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SiteSettings site = new SiteSettings();
        site.SiteName = SiteName.Text;
        site.SiteLogo=SiteLogo.Text;
        site.SiteBanner=SiteBanner.Text;
        site.SiteBottomAd=SiteBottomAd.Text;
        site.WatermarkType = (WatermarkType)Enum.Parse(typeof(WatermarkType),WatermarkList.SelectedValue);
        site.WatermarkText = WatermarkText.Text;
        site.WatermarkFileName=WatermarkFileName.Text  ;
        site.TgNum = int.Parse(TgNumTxt.Text);
        site.ServiceTxt=ServiceTxt.Text  ;
        site.SiteBottomDec=SiteBottomDec.Text;
        SiteSetting.SaveSiteSettings(site);
        dataConfig();
    }
}
