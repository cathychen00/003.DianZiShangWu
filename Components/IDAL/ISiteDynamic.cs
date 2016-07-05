using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ���Ŷ�̬��Ϣ�ӿ�
    /// </summary>
    public interface ISiteDynamic
    {
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        IList<SiteDynamicInfo> GetSiteDynamic(SiteDynamicType type);

        /// <summary>
        /// ��ȡ�ض�������ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        SiteDynamicInfo GetSiteDynamicByID(int siteDynamicID);

        /// <summary>
        /// ��ӱ�����ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertSiteDynamic(SiteDynamicInfo siteDynamic);

        /// <summary>
        /// ���±�����ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateSiteDynamic(SiteDynamicInfo siteDynamic);

        /// <summary>
        /// ɾ��������ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteSiteDynamic(int siteDynamicID);
    }
}
