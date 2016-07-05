using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ��Դ���ӿ�
    /// </summary>
   public interface IDownClass
    {
        /// <summary>
        /// ��ȡ��������б�
        /// </summary>
        /// <returns></returns>
        IList<DownClassInfo> GetDownClass();

        /// <summary>
        /// ��ȡ�ض����������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        DownClassInfo GetDownClassByID(int downClassID);

        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertDownClass(DownClassInfo downClass);

        /// <summary>
        /// �������������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateDownClass(DownClassInfo downClass);

        /// <summary>
        /// ɾ�����������Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteDownClass(DownClassInfo downClass);
    }
}
