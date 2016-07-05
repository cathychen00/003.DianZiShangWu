using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;

namespace Jiaen.BLL
{
    [DataObjectAttribute]
    public class SiteDynamic
    {
        private static readonly ISiteDynamic sd = DataAccess.CreateSiteDynamic();

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public static IList<SiteDynamicInfo> GetSiteDynamic(SiteDynamicType type)
        {
            return sd.GetSiteDynamic(type);
        }

        /// <summary>
        /// ��ȡ�ض�������ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static SiteDynamicInfo GetSiteDynamicByID(int siteDynamicID)
        {
            return sd.GetSiteDynamicByID(siteDynamicID);
        }

        /// <summary>
        /// ��ӱ�����ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        public static void InsertSiteDynamic(SiteDynamicInfo siteDynamic)
        {
            sd.InsertSiteDynamic(siteDynamic);

        }

        /// <summary>
        /// ���±�����ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateSiteDynamic(SiteDynamicInfo siteDynamic)
        {
            return sd.UpdateSiteDynamic(siteDynamic);
        }

        /// <summary>
        /// ɾ��������ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteSiteDynamic(int siteDynamicID)
        {
            return sd.DeleteSiteDynamic(siteDynamicID);
        }
    }
}
