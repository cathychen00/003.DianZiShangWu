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
       /// ��ȡ��������б�
       /// </summary>
       /// <returns></returns>
      public static IList<DownClassInfo> GetDownClass()
       {
           return downClasses.GetDownClass();
       }

       /// <summary>
       /// ��ȡ�ض����������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static DownClassInfo GetDownClassByID(int downClassID)
       {
           return downClasses.GetDownClassByID(downClassID);
       }

       /// <summary>
       /// ������������Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertDownClass(DownClassInfo downClass)
       {
           downClasses.InsertDownClass(downClass);
       }

       /// <summary>
       /// �������������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateDownClass(DownClassInfo downClass)
       {
           return downClasses.UpdateDownClass(downClass);
       }

       /// <summary>
       /// ɾ�����������Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteDownClass(DownClassInfo downClass)
       {
           return downClasses.DeleteDownClass(downClass);
       }
    }
}
