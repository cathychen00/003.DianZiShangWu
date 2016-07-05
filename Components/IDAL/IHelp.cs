using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ������Ϣ�ӿ�
    /// </summary>
   public interface IHelp
    {
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <returns></returns>
        IList<HelpInfo> GetHelp();

        /// <summary>
        /// ��ȡ�ض�����
        /// </summary>
        /// <returns></returns>
       IList<HelpInfo> GetClassHelpByID(int classID);

        /// <summary>
        /// ��ȡ�ض�������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        HelpInfo GetHelpByID(int HelpID);

        /// <summary>
        /// ��Ӱ�����Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertHelp(HelpInfo Help);

        /// <summary>
        /// ���°�����Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateHelp(HelpInfo Help);

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteHelp(int helpID);
    }
}
