using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    public class OrderDetailInfo : CartInfo
    {
        private long longOrderID;
        private int intID;
        /// <summary>
        /// �������
        /// </summary>
        public long OrderID
        {
            get { return longOrderID; }
            set { longOrderID = value; }
        }

        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }
    }
}
