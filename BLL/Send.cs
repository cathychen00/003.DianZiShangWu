using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;

namespace Jiaen.BLL
{
    [DataObjectAttribute]
    public class Send
    {
        private static readonly ISend sends = DataAccess.CreateSend();

        /// <summary>
        /// ��ȡ���ͷ�ʽ�б�
        /// </summary>
        /// <returns></returns>
        public static IList<SendInfo> GetSend()
        {
            return sends.GetSend();
        }


        /// <summary>
        /// ��ȡ�ض����ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static SendInfo GetSendByID(int sendID)
        {
            return sends.GetSendByID(sendID);
        }

        /// <summary>
        /// ������ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
       public static void InsertSend(SendInfo send)
        {
            sends.InsertSend(send);
        }

        /// <summary>
        /// �������ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateSend(SendInfo send)
        {
            return sends.UpdateSend(send);
        }

        /// <summary>
        /// ɾ�����ͷ�ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteSend(int SendID)
        {
            return sends.DeleteSend(SendID);
        }
    
    }
}
