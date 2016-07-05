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
    public class Orders
    {
        private static readonly IOrders orders = DataAccess.CreateOrders();

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetAllOrders()
        {
            return orders.GetAllOrders();
        }

        /// <summary>
        /// ��ȡ���ն�����Ϣ
        /// </summary>
        /// <returns></returns>
        IList<OrdersInfo> GetTodayOrders()
        {
            return orders.GetTodayOrders();
        }

        public static IList<OrdersInfo> GetStatusOrders(int state)
        {
            return orders.GetStatusOrders(state);
        }
        /// <summary>
        /// ��ȡ������ϸ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static OrdersInfo GetOrdersByID(long orderID)
        {
            return orders.GetOrdersByID(orderID);
        }

        /// <summary>
        /// ��ȡʱ����
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetYearOrders()
        {
            return orders.GetYearOrders();
        }

        /// <summary>
        /// ��Ӷ�����Ϣ
        /// </summary>
        /// <param name="link"></param>
        public static void InsertOrders(OrdersInfo order)
        {
            orders.InsertOrders(order);
        }

        /// <summary>
        /// ��ȡ������Ʒ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static IList<OrderDetailInfo> GetDerailByID(long orderID)
        {
            return orders.GetDerailByID(orderID);
        }

        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetUserOrders(string userName)
        {
            return orders.GetUserOrders(userName);
        }

        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetUserOrders()
        {
            return orders.GetUserOrders();
        }

        /// <summary>
        /// ���¶�����Ϣ
        /// </summary>
        /// <returns></returns>
        public static int UpdateOrderTypeByID(OrdersInfo order)
        {
            return orders.UpdateOrderTypeByID(order);
        }

        /// <summary>
        /// ���¶���״̬
        /// </summary>
        /// <returns></returns>
        public static int UpdateOrderStatusByID(int status, long orderID)
        {
            return orders.UpdateOrderStatusByID(status, orderID);
        }

        /// <summary>
        /// ���¶���״̬
        /// </summary>
        /// <returns></returns>
        public static int UpdateOrderPayByID(decimal money, long orderID)
        {
            return orders.UpdateOrderPayByID(money, orderID);
        }

        public static int UpdateOrderDateByID(long orderID)
        {
            return orders.UpdateOrderDateByID(orderID);
        }

        public static bool GetBookByID(int bookID, int status)
        {
            return orders.GetBookByID(bookID,status);
        }
    }
}
