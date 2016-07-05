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
   public class DownLoad
    {
       private static readonly IDownLoad downLoads = DataAccess.CreateDownLoad();

       /// <summary>
       /// ��ȡ�����ļ��б�
       /// </summary>
       /// <returns></returns>
      public static IList<DownLoadInfo> GetDownLoad()
       {
           return downLoads.GetDownLoad();
       }

       public static IList<DownLoadInfo> GetCBDownLoad()
       {
           return downLoads.GetCBDownLoad();
       }

       /// <summary>
       /// ��ȡ���������ļ��б�
       /// </summary>
       /// <returns></returns>
       public static IList<DownLoadInfo> GetDownLoadByCat(int catID)
       {
           return downLoads.GetDownLoadByCat(catID);
       }

       /// <summary>
       /// ��ȡ��������
       /// </summary>
       /// <returns></returns>
       public static IList<DownLoadInfo> GetTopDownLoad()
       {
           return downLoads.GetTopDownLoad();
       }

       /// <summary>
       /// ��ȡ�ض������ļ���Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static DownLoadInfo GetDownLoadByID(int downLoadID)
       {
           return downLoads.GetDownLoadByID(downLoadID);
       }

       /// <summary>
       /// ��������ļ���Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertDownLoad(DownLoadInfo downLoad)
       {
           downLoads.InsertDownLoad(downLoad);
       }

       /// <summary>
       /// ���������ļ���Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateDownLoad(DownLoadInfo downLoad)
       {
           return downLoads.UpdateDownLoad(downLoad);
       }

       /// <summary>
       /// ����������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateCount(int type, int ID)
       {
           return downLoads.UpdateCount(type,ID);
       }

       /// <summary>
       /// ɾ�������ļ���Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteDownLoad(DownLoadInfo downLoad)
       {
           return downLoads.DeleteDownLoad(downLoad);
       }

    }
}
