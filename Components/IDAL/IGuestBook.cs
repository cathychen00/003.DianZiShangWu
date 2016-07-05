using System;
using System.Collections.Generic;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 留言簿接口
    /// </summary>
    public interface IGuestBook
    {

        /// <summary>
        /// 获取用户留言
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IList<GuestBookInfo> GetGuestBook(int userID);


        /// <summary>
        /// 获取特定留言信息
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        GuestBookInfo GetGuestBookByID(int gbID);

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="g"></param>
        void InsertGuestBook(GuestBookInfo g);

        /// <summary>
        /// 删除留言信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int DeleteGuestBookByID(int gbID);
    }
}
