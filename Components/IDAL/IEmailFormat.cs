using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// Emailģ����Ϣ�ӿ�
    /// </summary>
   public interface IEmailFormat
    {

        /// <summary>
        /// ��ȡEmailģ��
        /// </summary>
        /// <returns></returns>
        IList<EmailFormatInfo> GetEmailFormat();

        /// <summary>
        /// ��ȡ�ض�Emailģ��
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        EmailFormatInfo GetEmailFormatByID(int emailFormatID);


        /// <summary>
        /// ����Emailģ��
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateEmailFormat(EmailFormatInfo emailFormat);

    }
}
