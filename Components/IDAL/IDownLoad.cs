using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ��Դ��Ϣ�ӿ�
    /// </summary>
    public interface IDownLoad
    {
        /// <summary>
        /// ��ȡ�����ļ��б�
        /// </summary>
        /// <returns></returns>
        IList<DownLoadInfo> GetDownLoad();

        /// <summary>
        /// ��ȡ���������ļ��б�
        /// </summary>
        /// <returns></returns>
        IList<DownLoadInfo> GetDownLoadByCat(int catID);

        IList<DownLoadInfo> GetCBDownLoad();

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        IList<DownLoadInfo> GetTopDownLoad();

        /// <summary>
        /// ��ȡ�ض������ļ���Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        DownLoadInfo GetDownLoadByID(int downLoadID);

        /// <summary>
        /// ��������ļ���Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertDownLoad(DownLoadInfo downLoad);

        /// <summary>
        /// ���������ļ���Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateDownLoad(DownLoadInfo downLoad);

        /// <summary>
        /// �������ش�����Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateCount(int type, int ID);

        /// <summary>
        /// ɾ�������ļ���Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteDownLoad(DownLoadInfo downLoad);
    }
}
