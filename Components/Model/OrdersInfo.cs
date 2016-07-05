using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public class OrdersInfo : AddressInfo
    {
        private DateTime addDate;
        private long longOrderID;
        private int intOrderStatus;
        private DateTime sendDate;
        private int intYear;
        private bool enableInvoice;
        private decimal bookPrice;
        private decimal sendPrice;
        private decimal sumPrice;
        private string strMessage;

        private bool isPass;
        private bool isCancel;
        private bool isSended;
        private bool isPay;
        private bool isFinished;
        private bool isTg;
        private decimal balancePrice;
        private decimal needPayPrice;
        private decimal otherPayPrice;
        private decimal tgPrice;

        /// <summary>
        /// 团购价格
        /// </summary>
        public decimal TgPrice
        {
            get { return tgPrice; }
            set { tgPrice = value; }
        }


        /// <summary>
        /// 支付
        /// </summary>
        public decimal OtherPayPrice
        {
            get { return otherPayPrice; }
            set { otherPayPrice = value; }
        }

        /// <summary>
        /// 已支付
        /// </summary>
        public decimal BalancePrice
        {
            get { return balancePrice; }
            set { balancePrice = value; }
        }

        /// <summary>
        /// 还需要支付
        /// </summary>
        public decimal NeedPayPrice
        {
            get { return needPayPrice; }
            set { needPayPrice = value; }
        }

        /// <summary>
        /// 是否团购
        /// </summary>
        public bool IsTg
        {
            get { return isTg; }
            set { isTg = value; }
        }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsPass
        {
            get { return isPass; }
            set { isPass = value; }
        }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool IsCancel
        {
            get { return isCancel; }
            set { isCancel = value; }
        }

        /// <summary>
        /// 是否已发货
        /// </summary>
        public bool IsSended
        {
            get { return isSended; }
            set { isSended = value; }
        }

        /// <summary>
        /// 是否付款
        /// </summary>
        public bool IsPay
        {
            get { return isPay; }
            set { isPay = value; }
        }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        /// <summary>
        /// 图书总价格
        /// </summary>
        public decimal BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        /// <summary>
        /// 送货费用
        /// </summary>
        public decimal SendPrice
        {
            get { return sendPrice; }
            set { sendPrice = value; }
        }

        /// <summary>
        /// 总价格
        /// </summary>
        public decimal SumPrice
        {
            get { return sumPrice; }
            set { sumPrice = value; }
        }

        /// <summary>
        /// 留言
        /// </summary>
        public string Message
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        /// <summary>
        /// 是否开发票
        /// </summary>
        public bool EnableInvoice
        {
            get { return enableInvoice; }
            set { enableInvoice = value; }
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderID
        {
            get { return longOrderID; }
            set { longOrderID = value; }
        }

        ///// <summary>
        ///// 下订单用户
        ///// </summary>
        //public string UserName
        //{
        //    get { return strUserName; }
        //    set { strUserName = value; }
        //}

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime SendDate
        {
            get { return sendDate; }
            set { sendDate = value; }
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus
        {
            get { return intOrderStatus; }
            set { intOrderStatus = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }

        /// <summary>
        /// 年
        /// </summary>
        public int Year
        {
            get { return intYear; }
            set { intYear = value; }
        }

    }
}
