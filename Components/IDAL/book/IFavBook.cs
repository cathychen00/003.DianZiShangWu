using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书收藏夹接口
    /// </summary>
    public interface IFavBook
    {
        /// <summary>
        /// 获取收藏图书
        /// </summary>
        /// <returns></returns>
        IList<FavBookInfo> GetFavBooks();

        /// <summary>
        /// 添加收藏图书
        /// </summary>
        /// <param name="link"></param>
        void InsertFavBook(int bookID);

        /// <summary>
        /// 删除收藏图书
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteFavBook(int favID);

        int DeleteFavBookByID(int bookID);
    }
}
