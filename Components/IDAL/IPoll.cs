using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ͶƱ��Ϣ�ӿ�
    /// </summary>
   public interface IPoll
    {
        /// <summary>
        /// ��ȡ����ͶƱ
        /// </summary>
        /// <returns></returns>
       IList<PollInfo> GetPoll();

       /// <summary>
       /// ��ȡ����ͶƱ
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       IList<PollInfo> GetTopPoll(int type);

        /// <summary>
       /// ��ȡ�ض�ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       PollInfo GetPollByID(int pollID);

        /// <summary>
        /// ����ͶƱ
        /// </summary>
        /// <param name="link"></param>
       void InsertPoll(PollInfo poll);

        /// <summary>
       /// ����ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdatePoll(PollInfo poll);

       /// <summary>
       /// ����ͶƱ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       int UpdatePollNum(PollInfo poll);

        /// <summary>
       /// ɾ��ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeletePoll(int pollID);
    }
}
