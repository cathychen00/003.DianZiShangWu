using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ�������ӿ�
    /// </summary>
   public interface IPublish
    {
        /// <summary>
        /// ��ȡ�������б�
        /// </summary>
        /// <returns></returns>
       IList<PublishInfo> GetPublishs();

       /// <summary>
       /// ��ȡ��ҳ�������б�
       /// </summary>
       /// <returns></returns>
       IList<PublishInfo> GetMainPublishs();

        /// <summary>
        /// ��ȡ�ض���������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       PublishInfo GetPublishByID(int publishID);

        /// <summary>
        /// ��ӳ�������Ϣ
        /// </summary>
        /// <param name="link"></param>
       void InsertPublish(PublishInfo publish);

        /// <summary>
        /// ���³�������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdatePublish(PublishInfo publish);

        /// <summary>
        /// ɾ����������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeletePublish(int publishID);
    }
}
