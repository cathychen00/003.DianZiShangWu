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
        /// ��ȡͼ��������Ϣ
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        public static IList<ReviewInfo> GetReview(ReviewType rt, int ID)
        {
            return reviews.GetReview(rt, ID);
        }

        /// <summary>
        ///��ȡ�ض�ID������Ϣ
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        public static ReviewInfo GetReviewByID(int reviewID)
        {
            return reviews.GetReviewByID(reviewID);
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="r"></param>
        public static void InsertReview(ReviewInfo r)
        {
            reviews.InsertReview(r);
        }

        /// <summary>
        ///�޸��ض�ID������Ϣ
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        public static int UpdateReview(ReviewInfo r)
        {
           return reviews.UpdateReview(r);
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int DeleteReview(int reviewID)
        {
            return reviews.DeleteReview(reviewID);
        }
    }
}
