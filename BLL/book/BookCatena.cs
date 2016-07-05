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
       /// 获取图书系列列表
       /// </summary>
       /// <returns></returns>
      public static IList<BookCatenaInfo> GetCatenas()
       {
           return catenas.GetCatenas();
       }

       /// <summary>
       /// 获取特定图书系列信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static BookCatenaInfo GetCatenaByID(int catenaID)
       {
           return catenas.GetCatenaByID(catenaID);
       }

       /// <summary>
       /// 添加图书系列信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertCatena(BookCatenaInfo catena)
       {
           catenas.InsertCatena(catena);
       }

       /// <summary>
       /// 更新图书系列信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateCatena(BookCatenaInfo catena)
       {
           return catenas.UpdateCatena(catena);
       }

       /// <summary>
       /// 删除图书系列信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteCatena(int catenaID)
       {
           return catenas.DeleteCatena(catenaID);
       }
    }
}
