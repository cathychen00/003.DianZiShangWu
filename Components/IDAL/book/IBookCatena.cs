using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书系列接口
    /// </summary>
    public interface IBookCatena
    {
        /// <summary>
        /// 获取图书系列列表
        /// </summary>
        /// <returns></returns>
        IList<BookCatenaInfo> GetCatenas();

        /// <summary>
        /// 获取特定图书系列信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        BookCatenaInfo GetCatenaByID(int catenaID);

        /// <summary>
        /// 添加图书系列信息
        /// </summary>
        /// <param name="link"></param>
        void InsertCatena(BookCatenaInfo catena);

        /// <summary>
        /// 更新图书系列信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateCatena(BookCatenaInfo catena);

        /// <summary>
        /// 删除图书系列信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteCatena(int catenaID);
    }
}
