using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Net.Configuration;
namespace Jiaen.BLL
{
    [DataObjectAttribute]
    public class SiteSetting
    {
        private static readonly ISiteSetting site = DataAccess.CreateSiteSetting();

        private static readonly Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);

        public static SiteSettings GetSiteSettings(string applicationName)
        {
            return site.GetSiteSettings(applicationName);
        }

        public static int SaveSiteSettings(SiteSettings siteSettings)
        {
            return site.SaveSiteSettings(siteSettings);
        }

        public static void InsertSiteSettings(SiteSettings siteSettings)
        {
            site.InsertSiteSettings(siteSettings);
        }

        public static SmtpSection getSMTP()
        {
            SmtpSection section = (SmtpSection)config.GetSection("system.net/mailSettings/smtp");
            return section;
        }

        public static void saveSMTP(string host,string userName,string password,string From)
        {
            getSMTP().Network.Host = host;
            getSMTP().Network.UserName = userName;
            getSMTP().Network.Password = password;
            getSMTP().From = From;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
