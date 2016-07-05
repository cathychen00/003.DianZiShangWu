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
        /// ¶©µ¥±àºÅ
        /// </summary>
        public long OrderID
        {
            get { return longOrderID; }
            set { longOrderID = value; }
        }

        /// <summary>
        /// ²úÆ·±àºÅ
        /// </summary>
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }
    }
}
