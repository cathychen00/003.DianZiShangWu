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
   public class Book
    {
       private static readonly IBook books = DataAccess.CreateBook();

       /// <summary>
       /// ��ȡ��ҳͼ����Ϣ
       /// </summary>
       /// <returns></returns>
      public static IList<BookInfo> GetIndexBook(ViewBookType type)
       {
           return books.GetIndexBook(type);
       }

       /// <summary>
       /// ��ȡ�ؼ�ͼ����Ϣ
       /// </summary>
       /// <returns></returns>
       public static IList<BookInfo> GetCheapBook(int type)
       {
           return books.GetCheapBook(type);
       }

       /// <summary>
       /// ��ȡ���Ź�ͼ��
       /// </summary>
       /// <returns></returns>
       public static IList<BookInfo> GetTgBook()
       {
           return books.GetTgBook();
       }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public static IList<BookInfo> GetCheapTopBook()
       {
           return books.GetCheapTopBook();
       }

       /// <summary>
       /// ��ȡͼ����Ϣ
       /// </summary>
       /// <returns></returns>
       public static IList<BookInfo> GetBook(BookType type)
       {
           return books.GetBook(type);
       }

       /// <summary>
       /// ����ͼ����Ϣ
       /// </summary>
       /// <returns></returns>
       public static void InsertBook(BookInfo book)
       {
           books.InsertBook(book);
       }

       public static BookInfo GetBookByID(int bookID)
       {
          return books.GetBookByID(bookID);
       }

       public static IList<BookInfo> GetCatBookByID(string bookName)
       {
           return books.GetCatBookByID(bookName);
       }

       /// <summary>
       /// ��ȡ����ͼ������
       /// </summary>
       /// <returns></returns>
       public static IList<BookInfo> GetTopBook(int year, int month, int catID, CatType type)
       {
           return books.GetTopBook(year, month,catID,type);
       }

       /// <summary>
       /// ��ȡͼ������
       /// </summary>
       /// <returns></returns>
       public static IList<BookInfo> GetTopBook(int year, int month)
       {
           return books.GetTopBook(year, month);
       }

       public static int UpdateBook(BookInfo book)
       {
           return books.UpdateBook(book);
       }

       /// <summary>
       /// ɾ��ͼ����Ϣ
       /// </summary>
       /// <param name="bookID"></param>
       /// <returns></returns>
       public static int DeleteBook(int bookID)
       {
           return books.DeleteBook(bookID);
       }

       /// <summary>
       /// ����ͼ��۸�
       /// </summary>
       /// <param name="book"></param>
       /// <returns></returns>
       public static int UpdatePrice(BookInfo book)
       {
           return books.UpdatePrice(book);
       }

       public static int UpdateCount(CountType type, int ID)
       {

           return books.UpdateCount(type, ID);
       }

       public static int UpdateRebate(float rebate, int ID)
       {
           return books.UpdateRebate(rebate, ID);
       }

        /// <summary>
        /// ��ȡ����ͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
       public static IList<BookInfo> GetBookByCatID(int type, int catID)
       {
           return books.GetBookByCatID(type, catID);
       }

       /// <summary>
       /// ��ȡ����ͼ��
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public static IList<BookInfo> GetNewBook(int type)
       {
           return books.GetNewBook(type);
       }

       public static IList<BookInfo> GetBookByParentID(int type, int catID)
       {
           return books.GetBookByParentID(type, catID);
       }

       public static IList<BookInfo> GetSearchBook(int type, string key)
       {
           return books.GetSearchBook(type, key);
       }

       public static IList<BookInfo> GetTeacherBook(int type, int teacherID)
       {
           return books.GetTeacherBook(type,teacherID);
       }

       public static IList<BookInfo> GetAdvanceSearchBook(string[] key)
       {
           return books.GetAdvanceSearchBook(key);
       }

       public static int UpdateStockCount(int ID, int count)
       {
           return books.UpdateStockCount(ID, count);
       }
    }
}
