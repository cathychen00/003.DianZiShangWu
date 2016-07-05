using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ��������Ϣ�ӿ�
    /// </summary>
    public interface IReview
    {
        /// <summary>
        /// ��ȡͼ��������Ϣ
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        IList<ReviewInfo> GetReview(ReviewType rt,int ID);

        /// <summary>
        /// ��ȡͼ��������Ϣ
        /// </summary>
        /// <param name="blogID"></param>
        /// <returns></returns>
        IList<ReviewInfo> GetUserReview(ReviewType rt, string userName);

        /// <summary>
        ///��ȡ�ض�ID������Ϣ
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        ReviewInfo GetReviewByID(int reviewID);

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="r"></param>
        void InsertReview(ReviewInfo r);

        /// <summary>
        ///�޸��ض�ID������Ϣ
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        int UpdateReview(ReviewInfo r);

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int DeleteReview(int reviewID);
    }
}
