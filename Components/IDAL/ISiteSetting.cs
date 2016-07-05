using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 站点配置信息接口
    /// </summary>
   public interface ISiteSetting
    {
       /// <summary>
       /// 获取站点配置
       /// </summary>
       /// <param name="applicationName"></param>
       /// <returns></returns>
       SiteSettings GetSiteSettings(string applicationName);

       /// <summary>
       /// 保存站点配置
       /// </summary>
       /// <param name="siteSettings"></param>
       /// <returns></returns>
       int SaveSiteSettings(SiteSettings siteSettings);

       /// <summary>
       /// 新增站点配置
       /// </summary>
       /// <param name="siteSettings"></param>
       void InsertSiteSettings(SiteSettings siteSettings);
    }
}
