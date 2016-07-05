using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 配送地址接口
    /// </summary>
   public interface ISendArea
    {
        /// <summary>
        /// 获取配送地址列表
        /// </summary>
        /// <returns></returns>
       IList<SendAreaInfo> GetSendArea();

       /// <summary>
       /// 根据分类获取地址列表
       /// </summary>
       /// <param name="type"></param>
       /// <param name="areaID"></param>
       /// <returns></returns>
       IList<SendAreaInfo> GetSendArea(int type, int areaID);

        /// <summary>
       /// 获取特定配送地址信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       SendAreaInfo GetSendAreaByID(int sendID);

        /// <summary>
       /// 添加配送地址信息
        /// </summary>
        /// <param name="link"></param>
       void InsertSendArea(SendAreaInfo send);

        /// <summary>
       /// 更新配送地址信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdateSendArea(SendAreaInfo send);

        /// <summary>
       /// 删除配送地址信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteSendArea(int AreaID);
    }
}
