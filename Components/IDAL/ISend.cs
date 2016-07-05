using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ���ͷ�ʽ�ӿ�
    /// </summary>
   public interface ISend
    {
        /// <summary>
        /// ��ȡ���ͷ�ʽ�б�
        /// </summary>
        /// <returns></returns>
       IList<SendInfo> GetSend();


        /// <summary>
       /// ��ȡ�ض����ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       SendInfo GetSendByID(int sendID);

        /// <summary>
       /// ������ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
       void InsertSend(SendInfo send);

        /// <summary>
       /// �������ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdateSend(SendInfo send);

        /// <summary>
       /// ɾ�����ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteSend(int SendID);
    }
}
