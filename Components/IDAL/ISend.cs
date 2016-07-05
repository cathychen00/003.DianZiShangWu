using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 配送方式接口
    /// </summary>
   public interface ISend
    {
        /// <summary>
        /// 获取配送方式列表
        /// </summary>
        /// <returns></returns>
       IList<SendInfo> GetSend();


        /// <summary>
       /// 获取特定配送方式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       SendInfo GetSendByID(int sendID);

        /// <summary>
       /// 添加配送方式信息
        /// </summary>
        /// <param name="link"></param>
       void InsertSend(SendInfo send);

        /// <summary>
       /// 更新配送方式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdateSend(SendInfo send);

        /// <summary>
       /// 删除配送方式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteSend(int SendID);
    }
}
