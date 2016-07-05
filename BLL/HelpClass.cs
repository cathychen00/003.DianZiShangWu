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
       /// ��ȡ��������б�
       /// </summary>
       /// <returns></returns>
      public static IList<HelpClassInfo> GetHelpClass()
       {
           return helpClass.GetHelpClass();
       }

       /// <summary>
       /// ��ȡ��ʾ��ҳ�����б�
       /// </summary>
       /// <returns></returns>
       public static IList<HelpClassInfo> GetMainHelpClass()
       {
           return helpClass.GetMainHelpClass();
       }

       /// <summary>
       /// ��ȡ�ض����������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static HelpClassInfo GetHelpClassByID(int HelpClassID)
       {
           return helpClass.GetHelpClassByID(HelpClassID);
       }

       /// <summary>
       /// ��Ӱ��������Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertHelpClass(HelpClassInfo HelpClass)
       {
           helpClass.InsertHelpClass(HelpClass);
       }

       /// <summary>
       /// ���°��������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateHelpClass(HelpClassInfo HelpClass)
       {
           return helpClass.UpdateHelpClass(HelpClass);
       }

       /// <summary>
       /// ɾ�����������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteHelpClass(HelpClassInfo HelpClass)
       {
           return helpClass.DeleteHelpClass(HelpClass);
       }
    }
}
