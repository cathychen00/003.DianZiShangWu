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
    public class Poll
    {
        private static readonly IPoll polls = DataAccess.CreatePoll();

        /// <summary>
        /// ��ȡͶƱ
        /// </summary>
        /// <returns></returns>
        public static IList<PollInfo> GetPoll()
        {
            return polls.GetPoll();
        }

        /// <summary>
        /// ��ȡͶƱ
        /// </summary>
        /// <returns></returns>
        public static IList<PollInfo> GetTopPoll(int type)
        {
            return polls.GetTopPoll(type);
        }

        /// <summary>
        /// ��ȡ�ض�ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static PollInfo GetPollByID(int pollID)
        {
            return polls.GetPollByID(pollID);
        }

        /// <summary>
        /// ����ͶƱ
        /// </summary>
        /// <param name="link"></param>
        public static void InsertPoll(PollInfo poll)
        {
            polls.InsertPoll(poll);
        }

        /// <summary>
        /// ����ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdatePoll(PollInfo poll)
        {
            return polls.UpdatePoll(poll);
        }

        /// <summary>
        /// ����ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdatePollNum(PollInfo poll)
        {
            return polls.UpdatePollNum(poll);
        }

        /// <summary>
        /// ɾ��ͶƱ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeletePoll(int pollID)
        {
            return polls.DeletePoll(pollID);
        }
    }
}
