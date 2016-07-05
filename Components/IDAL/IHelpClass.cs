using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 帮助类别信息接口
    /// </summary>
   public interface IHelpClass
    {

        /// <summary>
        /// 获取帮助类别列表
        /// </summary>
        /// <returns></returns>
        IList<HelpClassInfo> GetHelpClass();

       /// <summary>
       /// 获取显示首页帮助列表
       /// </summary>
       /// <returns></returns>
       IList<HelpClassInfo> GetMainHelpClass();

        /// <summary>
        /// 获取特定帮助类别信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        HelpClassInfo GetHelpClassByID(int HelpClassID);

        /// <summary>
        /// 添加帮助类别信息
        /// </summary>
        /// <param name="link"></param>
        void InsertHelpClass(HelpClassInfo HelpClass);

        /// <summary>
        /// 更新帮助类别信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateHelpClass(HelpClassInfo HelpClass);

        /// <summary>
        /// 删除帮助类别信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteHelpClass(HelpClassInfo HelpClass);
    }
}
