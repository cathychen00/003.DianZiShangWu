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
        /// 获取投票
        /// </summary>
        /// <returns></returns>
        public static IList<PollInfo> GetPoll()
        {
            return polls.GetPoll();
        }

        /// <summary>
        /// 获取投票
        /// </summary>
        /// <returns></returns>
        public static IList<PollInfo> GetTopPoll(int type)
        {
            return polls.GetTopPoll(type);
        }

        /// <summary>
        /// 获取特定投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static PollInfo GetPollByID(int pollID)
        {
            return polls.GetPollByID(pollID);
        }

        /// <summary>
        /// 增加投票
        /// </summary>
        /// <param name="link"></param>
        public static void InsertPoll(PollInfo poll)
        {
            polls.InsertPoll(poll);
        }

        /// <summary>
        /// 更新投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdatePoll(PollInfo poll)
        {
            return polls.UpdatePoll(poll);
        }

        /// <summary>
        /// 更新投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdatePollNum(PollInfo poll)
        {
            return polls.UpdatePollNum(poll);
        }

        /// <summary>
        /// 删除投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeletePoll(int pollID)
        {
            return polls.DeletePoll(pollID);
        }
    }
}
