using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 帮助信息接口
    /// </summary>
   public interface IHelp
    {
        /// <summary>
        /// 获取帮助列表
        /// </summary>
        /// <returns></returns>
        IList<HelpInfo> GetHelp();

        /// <summary>
        /// 获取特定帮助
        /// </summary>
        /// <returns></returns>
       IList<HelpInfo> GetClassHelpByID(int classID);

        /// <summary>
        /// 获取特定帮助信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        HelpInfo GetHelpByID(int HelpID);

        /// <summary>
        /// 添加帮助信息
        /// </summary>
        /// <param name="link"></param>
        void InsertHelp(HelpInfo Help);

        /// <summary>
        /// 更新帮助信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateHelp(HelpInfo Help);

        /// <summary>
        /// 删除帮助信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteHelp(int helpID);
    }
}
