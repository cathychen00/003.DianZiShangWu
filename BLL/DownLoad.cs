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
       /// 获取下载文件列表
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
       /// 获取分类下载文件列表
       /// </summary>
       /// <returns></returns>
       public static IList<DownLoadInfo> GetDownLoadByCat(int catID)
       {
           return downLoads.GetDownLoadByCat(catID);
       }

       /// <summary>
       /// 获取下载排行
       /// </summary>
       /// <returns></returns>
       public static IList<DownLoadInfo> GetTopDownLoad()
       {
           return downLoads.GetTopDownLoad();
       }

       /// <summary>
       /// 获取特定下载文件信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static DownLoadInfo GetDownLoadByID(int downLoadID)
       {
           return downLoads.GetDownLoadByID(downLoadID);
       }

       /// <summary>
       /// 添加下载文件信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertDownLoad(DownLoadInfo downLoad)
       {
           downLoads.InsertDownLoad(downLoad);
       }

       /// <summary>
       /// 更新下载文件信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateDownLoad(DownLoadInfo downLoad)
       {
           return downLoads.UpdateDownLoad(downLoad);
       }

       /// <summary>
       /// 更新数字信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateCount(int type, int ID)
       {
           return downLoads.UpdateCount(type,ID);
       }

       /// <summary>
       /// 删除下载文件信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteDownLoad(DownLoadInfo downLoad)
       {
           return downLoads.DeleteDownLoad(downLoad);
       }

    }
}
