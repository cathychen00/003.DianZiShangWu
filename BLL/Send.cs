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
        /// 获取配送方式列表
        /// </summary>
        /// <returns></returns>
        public static IList<SendInfo> GetSend()
        {
            return sends.GetSend();
        }


        /// <summary>
        /// 获取特定配送方式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static SendInfo GetSendByID(int sendID)
        {
            return sends.GetSendByID(sendID);
        }

        /// <summary>
        /// 添加配送方式信息
        /// </summary>
        /// <param name="link"></param>
       public static void InsertSend(SendInfo send)
        {
            sends.InsertSend(send);
        }

        /// <summary>
        /// 更新配送方式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateSend(SendInfo send)
        {
            return sends.UpdateSend(send);
        }

        /// <summary>
        /// 删除配送方式信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteSend(int SendID)
        {
            return sends.DeleteSend(SendID);
        }
    
    }
}
