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
   public class Publish
    {
       private static readonly IPublish publishs = DataAccess.CreatePublish();

       /// <summary>
       /// 获取出版社列表
       /// </summary>
       /// <returns></returns>
      public static IList<PublishInfo> GetPublishs()
       {
           return publishs.GetPublishs();
       }

       public static IList<PublishInfo> GetMainPublishs()
       {
           return publishs.GetMainPublishs();
       }

       /// <summary>
       /// 获取特定出版社信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static PublishInfo GetPublishByID(int publishID)
       {
           return publishs.GetPublishByID(publishID);
       }

       /// <summary>
       /// 添加出版社信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertPublish(PublishInfo publish)
       {
           publishs.InsertPublish(publish);
       }

       /// <summary>
       /// 更新出版社信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdatePublish(PublishInfo publish)
       {
           return publishs.UpdatePublish(publish);
       }

       /// <summary>
       /// 删除出版社信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeletePublish(int publishID)
       {
           return publishs.DeletePublish(publishID);
       }
    }
}
