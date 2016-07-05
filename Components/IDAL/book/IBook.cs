using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ����Ϣ�ӿ�
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// ��ȡ��ҳͼ����Ϣ
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetIndexBook(ViewBookType type);

        /// <summary>
        /// ��ȡ�ؼ�ͼ��
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetCheapBook(int type);

        /// <summary>
        /// ��ȡ�ؼ�ͼ������
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetCheapTopBook();

        /// <summary>
        /// ��ȡ���Ź�ͼ��
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetTgBook();

        /// <summary>
        /// ��ȡ��ͼ������
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetTopBook(int year,int month);

        ///// <summary>
        ///// ��ȡ��ͼ������
        ///// </summary>
        ///// <returns></returns>
        //IList<BookInfo> GetTopWeekBook();

        /// <summary>
        /// ��ȡ����ͼ������
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetTopBook(int year, int month, int catID, CatType type);

        /// <summary>
        /// ���ݻ�ȡͼ�鷽ʽ��ȡͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IList<BookInfo> GetBook(BookType type);

        /// <summary>
        /// ��ȡ����ͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetNewBook(int type);

        /// <summary>
        /// ��ȡ����ͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetSearchBook(int type,string key);

        /// <summary>
        /// ��ȡ����ͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetBookByCatID(int type,int catID);

        /// <summary>
        /// ��ȡ�ض�ͼ����Ϣ
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        BookInfo GetBookByID(int bookID);

        /// <summary>
        /// ��ȡ���ͼ����Ϣ
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        IList<BookInfo> GetCatBookByID(string bookName);

        /// <summary>
        /// ����ͼ����Ϣ
        /// </summary>
        /// <param name="book"></param>
        void InsertBook(BookInfo book);

        /// <summary>
        /// ����ͼ����Ϣ
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int UpdateBook(BookInfo book);


        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateCount(CountType type, int ID);

        /// <summary>
        /// ���¿��
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int UpdateStockCount(int ID, int count);

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateRebate(float rebate, int ID);

        /// <summary>
        /// ����ͼ��۸�
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int UpdatePrice(BookInfo book);

        /// <summary>
        /// ɾ��ͼ����Ϣ
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        int DeleteBook(int bookID);

        /// <summary>
        /// ��ȡ����ͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetBookByParentID(int type, int catID);

        /// <summary>
        /// ��ȡ��ʦͼ��
        /// </summary>
        /// <param name="type"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        IList<BookInfo> GetTeacherBook(int type,int teacherID);

        /// <summary>
        /// ��ȡ�������ͼ��
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IList<BookInfo> GetAdvanceSearchBook(string[] key);
    }
}
