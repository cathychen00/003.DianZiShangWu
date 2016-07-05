using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 资源信息接口
    /// </summary>
    public interface IDownLoad
    {
        /// <summary>
        /// 获取下载文件列表
        /// </summary>
        /// <returns></returns>
        IList<DownLoadInfo> GetDownLoad();

        /// <summary>
        /// 获取分类下载文件列表
        /// </summary>
        /// <returns></returns>
        IList<DownLoadInfo> GetDownLoadByCat(int catID);

        IList<DownLoadInfo> GetCBDownLoad();

        /// <summary>
        /// 获取下载排行
        /// </summary>
        /// <returns></returns>
        IList<DownLoadInfo> GetTopDownLoad();

        /// <summary>
        /// 获取特定下载文件信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        DownLoadInfo GetDownLoadByID(int downLoadID);

        /// <summary>
        /// 添加下载文件信息
        /// </summary>
        /// <param name="link"></param>
        void InsertDownLoad(DownLoadInfo downLoad);

        /// <summary>
        /// 更新下载文件信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateDownLoad(DownLoadInfo downLoad);

        /// <summary>
        /// 更新下载次数信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateCount(int type, int ID);

        /// <summary>
        /// 删除下载文件信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteDownLoad(DownLoadInfo downLoad);
    }
}
