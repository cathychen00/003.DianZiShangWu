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
   public class BookCatena
    {
       private static readonly IBookCatena catenas = DataAccess.CreateBookCatena();

       /// <summary>
       /// ��ȡͼ��ϵ���б�
       /// </summary>
       /// <returns></returns>
      public static IList<BookCatenaInfo> GetCatenas()
       {
           return catenas.GetCatenas();
       }

       /// <summary>
       /// ��ȡ�ض�ͼ��ϵ����Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static BookCatenaInfo GetCatenaByID(int catenaID)
       {
           return catenas.GetCatenaByID(catenaID);
       }

       /// <summary>
       /// ���ͼ��ϵ����Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertCatena(BookCatenaInfo catena)
       {
           catenas.InsertCatena(catena);
       }

       /// <summary>
       /// ����ͼ��ϵ����Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateCatena(BookCatenaInfo catena)
       {
           return catenas.UpdateCatena(catena);
       }

       /// <summary>
       /// ɾ��ͼ��ϵ����Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteCatena(int catenaID)
       {
           return catenas.DeleteCatena(catenaID);
       }
    }
}
