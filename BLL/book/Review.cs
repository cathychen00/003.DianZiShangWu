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
    public class Review
    {
        private static readonly IReview reviews = DataAccess.CreateReview();

        /// <summary>
        /// 获取图书评论信息
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        public static IList<ReviewInfo> GetReview(ReviewType rt, int ID)
        {
            return reviews.GetReview(rt, ID);
        }

        /// <summary>
        ///获取特定ID评论信息
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        public static ReviewInfo GetReviewByID(int reviewID)
        {
            return reviews.GetReviewByID(reviewID);
        }

        /// <summary>
        /// 添加评论信息
        /// </summary>
        /// <param name="r"></param>
        public static void InsertReview(ReviewInfo r)
        {
            reviews.InsertReview(r);
        }

        /// <summary>
        ///修改特定ID评论信息
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        public static int UpdateReview(ReviewInfo r)
        {
           return reviews.UpdateReview(r);
        }

        /// <summary>
        /// 删除评论信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int DeleteReview(int reviewID)
        {
            return reviews.DeleteReview(reviewID);
        }
    }
}
