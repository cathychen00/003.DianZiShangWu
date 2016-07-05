using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 送货人地址实体类
    /// </summary>
   public class AddressInfo:SendInfo
    {
        private int intAddressID;
        private string strAddressName;
        private string strAddress;
        private string strPost;
        private string strTelephone;
        private int intUserID;
        private bool isDefault;
        private string strUserName;
        private string strCity;
        private string strProvince;
        private int intSendType;
        private int intPayType;
        private decimal balance;

       /// <summary>
       /// 帐户余额
       /// </summary>
       public decimal Balance
       {
           get { return balance; }
           set { balance = value; }
       }

        /// <summary>
        /// 付款方式
        /// </summary>
       public int PayType
        {
            get { return intPayType; }
            set { intPayType = value; }
        }

        /// <summary>
        /// 送货方式
        /// </summary>
       public int SendType
       {
           get { return intSendType; }
           set { intSendType = value; }
       }

        /// <summary>
        /// 城市
        /// </summary>
       public string City
        {
            get { return strCity; }
            set { strCity = value; }
        }

        /// <summary>
        /// 省
        /// </summary>
       public string Province
        {
            get { return strProvince; }
            set { strProvince = value; }
        }

        /// <summary>
        /// 地址编号
        /// </summary>
        public int AddressID
        {
            get { return intAddressID; }
            set { intAddressID = value; }
        }

        /// <summary>
        /// 送货人名字
        /// </summary>
        public string AddressName
        {
            get { return strAddressName; }
            set { strAddressName = value; }
        }

        /// <summary>
        ///用户名字
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// 送货人详细地址
        /// </summary>
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }


        /// <summary>
        /// 邮编
        /// </summary>
       public string Post
        {
            get { return strPost; }
            set { strPost = value; }
        }

        /// <summary>
        /// 送货人名字
        /// </summary>
       public string Telephone
        {
            get { return strTelephone; }
            set { strTelephone = value; }
        }


        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }

        /// <summary>
        /// 是否为默认送货地址
        /// </summary>
       public bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }

    }
}
