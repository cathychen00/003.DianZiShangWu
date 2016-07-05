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
   public class DownClass
    {
       private static readonly IDownClass downClasses = DataAccess.CreateDownClass();

       /// <summary>
       /// 获取下载类别列表
       /// </summary>
       /// <returns></returns>
      public static IList<DownClassInfo> GetDownClass()
       {
           return downClasses.GetDownClass();
       }

       /// <summary>
       /// 获取特定下载类别信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static DownClassInfo GetDownClassByID(int downClassID)
       {
           return downClasses.GetDownClassByID(downClassID);
       }

       /// <summary>
       /// 添加下载类别信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertDownClass(DownClassInfo downClass)
       {
           downClasses.InsertDownClass(downClass);
       }

       /// <summary>
       /// 更新下载类别信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateDownClass(DownClassInfo downClass)
       {
           return downClasses.UpdateDownClass(downClass);
       }

       /// <summary>
       /// 删除下载类别信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteDownClass(DownClassInfo downClass)
       {
           return downClasses.DeleteDownClass(downClass);
       }
    }
}
