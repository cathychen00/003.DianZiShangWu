using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// Email模板信息接口
    /// </summary>
   public interface IEmailFormat
    {

        /// <summary>
        /// 获取Email模板
        /// </summary>
        /// <returns></returns>
        IList<EmailFormatInfo> GetEmailFormat();

        /// <summary>
        /// 获取特定Email模板
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        EmailFormatInfo GetEmailFormatByID(int emailFormatID);


        /// <summary>
        /// 更新Email模板
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateEmailFormat(EmailFormatInfo emailFormat);

    }
}
