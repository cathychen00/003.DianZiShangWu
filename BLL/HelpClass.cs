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
   public class HelpClass
    {
       private static readonly IHelpClass helpClass = DataAccess.CreateHelpClass();

       /// <summary>
       /// 获取帮助类别列表
       /// </summary>
       /// <returns></returns>
      public static IList<HelpClassInfo> GetHelpClass()
       {
           return helpClass.GetHelpClass();
       }

       /// <summary>
       /// 获取显示首页帮助列表
       /// </summary>
       /// <returns></returns>
       public static IList<HelpClassInfo> GetMainHelpClass()
       {
           return helpClass.GetMainHelpClass();
       }

       /// <summary>
       /// 获取特定帮助类别信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static HelpClassInfo GetHelpClassByID(int HelpClassID)
       {
           return helpClass.GetHelpClassByID(HelpClassID);
       }

       /// <summary>
       /// 添加帮助类别信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertHelpClass(HelpClassInfo HelpClass)
       {
           helpClass.InsertHelpClass(HelpClass);
       }

       /// <summary>
       /// 更新帮助类别信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateHelpClass(HelpClassInfo HelpClass)
       {
           return helpClass.UpdateHelpClass(HelpClass);
       }

       /// <summary>
       /// 删除帮助类别信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteHelpClass(HelpClassInfo HelpClass)
       {
           return helpClass.DeleteHelpClass(HelpClass);
       }
    }
}
