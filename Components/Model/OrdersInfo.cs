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
        /// �Ź��۸�
        /// </summary>
        public decimal TgPrice
        {
            get { return tgPrice; }
            set { tgPrice = value; }
        }


        /// <summary>
        /// ֧��
        /// </summary>
        public decimal OtherPayPrice
        {
            get { return otherPayPrice; }
            set { otherPayPrice = value; }
        }

        /// <summary>
        /// ��֧��
        /// </summary>
        public decimal BalancePrice
        {
            get { return balancePrice; }
            set { balancePrice = value; }
        }

        /// <summary>
        /// ����Ҫ֧��
        /// </summary>
        public decimal NeedPayPrice
        {
            get { return needPayPrice; }
            set { needPayPrice = value; }
        }

        /// <summary>
        /// �Ƿ��Ź�
        /// </summary>
        public bool IsTg
        {
            get { return isTg; }
            set { isTg = value; }
        }

        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool IsPass
        {
            get { return isPass; }
            set { isPass = value; }
        }

        /// <summary>
        /// �Ƿ�ȡ��
        /// </summary>
        public bool IsCancel
        {
            get { return isCancel; }
            set { isCancel = value; }
        }

        /// <summary>
        /// �Ƿ��ѷ���
        /// </summary>
        public bool IsSended
        {
            get { return isSended; }
            set { isSended = value; }
        }

        /// <summary>
        /// �Ƿ񸶿�
        /// </summary>
        public bool IsPay
        {
            get { return isPay; }
            set { isPay = value; }
        }

        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        /// <summary>
        /// ͼ���ܼ۸�
        /// </summary>
        public decimal BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public decimal SendPrice
        {
            get { return sendPrice; }
            set { sendPrice = value; }
        }

        /// <summary>
        /// �ܼ۸�
        /// </summary>
        public decimal SumPrice
        {
            get { return sumPrice; }
            set { sumPrice = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Message
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        /// <summary>
        /// �Ƿ񿪷�Ʊ
        /// </summary>
        public bool EnableInvoice
        {
            get { return enableInvoice; }
            set { enableInvoice = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public long OrderID
        {
            get { return longOrderID; }
            set { longOrderID = value; }
        }

        ///// <summary>
        ///// �¶����û�
        ///// </summary>
        //public string UserName
        //{
        //    get { return strUserName; }
        //    set { strUserName = value; }
        //}

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime SendDate
        {
            get { return sendDate; }
            set { sendDate = value; }
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        public int OrderStatus
        {
            get { return intOrderStatus; }
            set { intOrderStatus = value; }
        }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }

        /// <summary>
        /// ��
        /// </summary>
        public int Year
        {
            get { return intYear; }
            set { intYear = value; }
        }

    }
}
