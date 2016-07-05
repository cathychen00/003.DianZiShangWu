using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书信息接口
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// 获取首页图书信息
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetIndexBook(ViewBookType type);

        /// <summary>
        /// 获取特价图书
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetCheapBook(int type);

        /// <summary>
        /// 获取特价图书排行
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetCheapTopBook();

        /// <summary>
        /// 获取可团购图书
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetTgBook();

        /// <summary>
        /// 获取月图书排行
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetTopBook(int year,int month);

        ///// <summary>
        ///// 获取周图书排行
        ///// </summary>
        ///// <returns></returns>
        //IList<BookInfo> GetTopWeekBook();

        /// <summary>
        /// 获取分类图书排行
        /// </summary>
        /// <returns></returns>
        IList<BookInfo> GetTopBook(int year, int month, int catID, CatType type);

        /// <summary>
        /// 根据获取图书方式获取图书
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IList<BookInfo> GetBook(BookType type);

        /// <summary>
        /// 获取最新图书
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetNewBook(int type);

        /// <summary>
        /// 获取搜索图书
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetSearchBook(int type,string key);

        /// <summary>
        /// 获取分类图书
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetBookByCatID(int type,int catID);

        /// <summary>
        /// 获取特定图书信息
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        BookInfo GetBookByID(int bookID);

        /// <summary>
        /// 获取相关图书信息
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        IList<BookInfo> GetCatBookByID(string bookName);

        /// <summary>
        /// 插入图书信息
        /// </summary>
        /// <param name="book"></param>
        void InsertBook(BookInfo book);

        /// <summary>
        /// 更新图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int UpdateBook(BookInfo book);


        /// <summary>
        /// 更新相关数量
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateCount(CountType type, int ID);

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int UpdateStockCount(int ID, int count);

        /// <summary>
        /// 更新评价信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateRebate(float rebate, int ID);

        /// <summary>
        /// 更新图书价格
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int UpdatePrice(BookInfo book);

        /// <summary>
        /// 删除图书信息
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        int DeleteBook(int bookID);

        /// <summary>
        /// 获取子类图书
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
        IList<BookInfo> GetBookByParentID(int type, int catID);

        /// <summary>
        /// 获取教师图书
        /// </summary>
        /// <param name="type"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        IList<BookInfo> GetTeacherBook(int type,int teacherID);

        /// <summary>
        /// 获取搜索结果图书
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IList<BookInfo> GetAdvanceSearchBook(string[] key);
    }
}
