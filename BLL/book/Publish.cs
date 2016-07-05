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
       /// ��ȡ�������б�
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
       /// ��ȡ�ض���������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static PublishInfo GetPublishByID(int publishID)
       {
           return publishs.GetPublishByID(publishID);
       }

       /// <summary>
       /// ��ӳ�������Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertPublish(PublishInfo publish)
       {
           publishs.InsertPublish(publish);
       }

       /// <summary>
       /// ���³�������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdatePublish(PublishInfo publish)
       {
           return publishs.UpdatePublish(publish);
       }

       /// <summary>
       /// ɾ����������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeletePublish(int publishID)
       {
           return publishs.DeletePublish(publishID);
       }
    }
}
