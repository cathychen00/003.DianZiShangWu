using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书评论信息接口
    /// </summary>
    public interface IReview
    {
        /// <summary>
        /// 获取图书评论信息
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        IList<ReviewInfo> GetReview(ReviewType rt,int ID);

        /// <summary>
        /// 获取图书评论信息
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        IList<ReviewInfo> GetUserReview(ReviewType rt, string userName);

        /// <summary>
        ///获取特定ID评论信息
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        ReviewInfo GetReviewByID(int reviewID);

        /// <summary>
        /// 添加评论信息
        /// </summary>
        /// <param name="r"></param>
        void InsertReview(ReviewInfo r);

        /// <summary>
        ///修改特定ID评论信息
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        int UpdateReview(ReviewInfo r);

        /// <summary>
        /// 删除评论信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int DeleteReview(int reviewID);
    }
}
