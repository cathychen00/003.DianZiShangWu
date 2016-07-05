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
   public class Help
    {
       private static readonly IHelp helps = DataAccess.CreateHelp();

       /// <summary>
       /// 获取帮助列表
       /// </summary>
       /// <returns></returns>
       public static IList<HelpInfo> GetHelp()
       {
           return helps.GetHelp();
       }

       /// <summary>
       /// 获取帮助列表
       /// </summary>
       /// <returns></returns>
       public static IList<HelpInfo> GetClassHelpByID(int classID)
       {
           return helps.GetClassHelpByID(classID);
       }

       /// <summary>
       /// 获取特定帮助信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static HelpInfo GetHelpByID(int HelpID)
       {
           return helps.GetHelpByID(HelpID);
       }

       /// <summary>
       /// 添加帮助信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertHelp(HelpInfo Help)
       {
           helps.InsertHelp(Help);
       }

       /// <summary>
       /// 更新帮助信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateHelp(HelpInfo Help)
       {
           return helps.UpdateHelp(Help);
       }

       /// <summary>
       /// 删除帮助信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteHelp(int helpID)
       {
           return helps.DeleteHelp(helpID);
       }
    }
}
