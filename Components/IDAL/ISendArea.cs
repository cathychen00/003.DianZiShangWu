using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ���͵�ַ�ӿ�
    /// </summary>
   public interface ISendArea
    {
        /// <summary>
        /// ��ȡ���͵�ַ�б�
        /// </summary>
        /// <returns></returns>
       IList<SendAreaInfo> GetSendArea();

       /// <summary>
       /// ���ݷ����ȡ��ַ�б�
       /// </summary>
       /// <param name="type"></param>
       /// <param name="areaID"></param>
       /// <returns></returns>
       IList<SendAreaInfo> GetSendArea(int type, int areaID);

        /// <summary>
       /// ��ȡ�ض����͵�ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       SendAreaInfo GetSendAreaByID(int sendID);

        /// <summary>
       /// ������͵�ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
       void InsertSendArea(SendAreaInfo send);

        /// <summary>
       /// �������͵�ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdateSendArea(SendAreaInfo send);

        /// <summary>
       /// ɾ�����͵�ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteSendArea(int AreaID);
    }
}
