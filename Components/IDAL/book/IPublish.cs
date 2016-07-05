using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书出版社接口
    /// </summary>
   public interface IPublish
    {
        /// <summary>
        /// 获取出版社列表
        /// </summary>
        /// <returns></returns>
       IList<PublishInfo> GetPublishs();

       /// <summary>
       /// 获取首页出版社列表
       /// </summary>
       /// <returns></returns>
       IList<PublishInfo> GetMainPublishs();

        /// <summary>
        /// 获取特定出版社信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       PublishInfo GetPublishByID(int publishID);

        /// <summary>
        /// 添加出版社信息
        /// </summary>
        /// <param name="link"></param>
       void InsertPublish(PublishInfo publish);

        /// <summary>
        /// 更新出版社信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdatePublish(PublishInfo publish);

        /// <summary>
        /// 删除出版社信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeletePublish(int publishID);
    }
}
