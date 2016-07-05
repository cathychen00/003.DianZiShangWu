using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 资源类别接口
    /// </summary>
   public interface IDownClass
    {
        /// <summary>
        /// 获取下载类别列表
        /// </summary>
        /// <returns></returns>
        IList<DownClassInfo> GetDownClass();

        /// <summary>
        /// 获取特定下载类别信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        DownClassInfo GetDownClassByID(int downClassID);

        /// <summary>
        /// 添加下载类别信息
        /// </summary>
        /// <param name="link"></param>
        void InsertDownClass(DownClassInfo downClass);

        /// <summary>
        /// 更新下载类别信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateDownClass(DownClassInfo downClass);

        /// <summary>
        /// 删除下载类别信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteDownClass(DownClassInfo downClass);
    }
}
