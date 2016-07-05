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
   public class SendArea
    {
       private static readonly ISendArea sendAreas= DataAccess.CreateSendArea();

       /// <summary>
       /// 获取配送地址列表
       /// </summary>
       /// <returns></returns>
     public static IList<SendAreaInfo> GetSendArea()
       {
           return sendAreas.GetSendArea();
       }

       public static IList<SendAreaInfo> GetSendArea(int type, int areaID)
       {
           return sendAreas.GetSendArea(type, areaID);
       }
       /// <summary>
       /// 获取特定配送地址信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static SendAreaInfo GetSendAreaByID(int sendID)
       {
           return sendAreas.GetSendAreaByID(sendID);
       }

       /// <summary>
       /// 添加配送地址信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertSendArea(SendAreaInfo send)
       {
           sendAreas.InsertSendArea(send);
       }

       /// <summary>
       /// 更新配送地址信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateSendArea(SendAreaInfo send)
       {
           return sendAreas.UpdateSendArea(send);
       }

       /// <summary>
       /// 删除配送地址信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteSendArea(int AreaID)
       {
           return sendAreas.DeleteSendArea(AreaID);
       }
    }
}
