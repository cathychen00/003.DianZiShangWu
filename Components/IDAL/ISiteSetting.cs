using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// վ��������Ϣ�ӿ�
    /// </summary>
   public interface ISiteSetting
    {
       /// <summary>
       /// ��ȡվ������
       /// </summary>
       /// <param name="applicationName"></param>
       /// <returns></returns>
       SiteSettings GetSiteSettings(string applicationName);

       /// <summary>
       /// ����վ������
       /// </summary>
       /// <param name="siteSettings"></param>
       /// <returns></returns>
       int SaveSiteSettings(SiteSettings siteSettings);

       /// <summary>
       /// ����վ������
       /// </summary>
       /// <param name="siteSettings"></param>
       void InsertSiteSettings(SiteSettings siteSettings);
    }
}
