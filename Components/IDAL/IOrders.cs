using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ������Ϣ�ӿ�
    /// </summary>
   public interface IOrders
    {

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
       IList<OrdersInfo> GetAllOrders();

       /// <summary>
       /// ��ȡ״̬����
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetStatusOrders(int state);

       /// <summary>
       /// ����ʱ���ȡ������Ϣ
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetYearOrders();

       /// <summary>
       /// ��ȡ���ն�����Ϣ
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetTodayOrders();

       /// <summary>
       /// ��ȡ�û�����
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetUserOrders(string userName);

       /// <summary>
       /// ��ȡ�û�����
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetUserOrders();

        /// <summary>
        /// ��ȡ������ϸ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       OrdersInfo GetOrdersByID(long orderID);

        /// <summary>
        /// ��Ӷ�����Ϣ
        /// </summary>
        /// <param name="link"></param>
       void InsertOrders(OrdersInfo order);

       /// <summary>
       /// ��ȡ������Ʒ��Ϣ
       /// </summary>
       /// <returns></returns>
       IList<OrderDetailInfo> GetDerailByID(long orderID);

       /// <summary>
       /// ���¶�����Ϣ
       /// </summary>
       /// <returns></returns>
       int UpdateOrderTypeByID(OrdersInfo order);

       /// <summary>
       /// ���¶���״̬
       /// </summary>
       /// <returns></returns>
       int UpdateOrderStatusByID(int status,long orderID);

       /// <summary>
       /// ���¶���״̬
       /// </summary>
       /// <returns></returns>
       int UpdateOrderPayByID(decimal money, long orderID);

       /// <summary>
       /// ���¶�������
       /// </summary>
       /// <param name="orderID"></param>
       /// <returns></returns>
       int UpdateOrderDateByID(long orderID);

       /// <summary>
       /// ����״̬��ȡ����ͼ����Ϣ
       /// </summary>
       /// <param name="bookID"></param>
       /// <param name="status"></param>
       /// <returns></returns>
       bool GetBookByID(int bookID,int status);
    }
}
