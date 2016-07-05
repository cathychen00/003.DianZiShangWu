using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ���������Ϣ�ӿ�
    /// </summary>
   public interface IHelpClass
    {

        /// <summary>
        /// ��ȡ��������б�
        /// </summary>
        /// <returns></returns>
        IList<HelpClassInfo> GetHelpClass();

       /// <summary>
       /// ��ȡ��ʾ��ҳ�����б�
       /// </summary>
       /// <returns></returns>
       IList<HelpClassInfo> GetMainHelpClass();

        /// <summary>
        /// ��ȡ�ض����������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        HelpClassInfo GetHelpClassByID(int HelpClassID);

        /// <summary>
        /// ��Ӱ��������Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertHelpClass(HelpClassInfo HelpClass);

        /// <summary>
        /// ���°��������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateHelpClass(HelpClassInfo HelpClass);

        /// <summary>
        /// ɾ�����������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteHelpClass(HelpClassInfo HelpClass);
    }
}
