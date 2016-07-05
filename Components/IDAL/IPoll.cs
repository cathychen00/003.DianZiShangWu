using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 投票信息接口
    /// </summary>
   public interface IPoll
    {
        /// <summary>
        /// 获取所有投票
        /// </summary>
        /// <returns></returns>
       IList<PollInfo> GetPoll();

       /// <summary>
       /// 获取最新投票
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       IList<PollInfo> GetTopPoll(int type);

        /// <summary>
       /// 获取特定投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       PollInfo GetPollByID(int pollID);

        /// <summary>
        /// 增加投票
        /// </summary>
        /// <param name="link"></param>
       void InsertPoll(PollInfo poll);

        /// <summary>
       /// 更新投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdatePoll(PollInfo poll);

       /// <summary>
       /// 更新投票
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       int UpdatePollNum(PollInfo poll);

        /// <summary>
       /// 删除投票
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeletePoll(int pollID);
    }
}
