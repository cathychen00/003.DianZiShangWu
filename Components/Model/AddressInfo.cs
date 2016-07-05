using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// �ͻ��˵�ַʵ����
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
       /// �ʻ����
       /// </summary>
       public decimal Balance
       {
           get { return balance; }
           set { balance = value; }
       }

        /// <summary>
        /// ���ʽ
        /// </summary>
       public int PayType
        {
            get { return intPayType; }
            set { intPayType = value; }
        }

        /// <summary>
        /// �ͻ���ʽ
        /// </summary>
       public int SendType
       {
           get { return intSendType; }
           set { intSendType = value; }
       }

        /// <summary>
        /// ����
        /// </summary>
       public string City
        {
            get { return strCity; }
            set { strCity = value; }
        }

        /// <summary>
        /// ʡ
        /// </summary>
       public string Province
        {
            get { return strProvince; }
            set { strProvince = value; }
        }

        /// <summary>
        /// ��ַ���
        /// </summary>
        public int AddressID
        {
            get { return intAddressID; }
            set { intAddressID = value; }
        }

        /// <summary>
        /// �ͻ�������
        /// </summary>
        public string AddressName
        {
            get { return strAddressName; }
            set { strAddressName = value; }
        }

        /// <summary>
        ///�û�����
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// �ͻ�����ϸ��ַ
        /// </summary>
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }


        /// <summary>
        /// �ʱ�
        /// </summary>
       public string Post
        {
            get { return strPost; }
            set { strPost = value; }
        }

        /// <summary>
        /// �ͻ�������
        /// </summary>
       public string Telephone
        {
            get { return strTelephone; }
            set { strTelephone = value; }
        }


        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }

        /// <summary>
        /// �Ƿ�ΪĬ���ͻ���ַ
        /// </summary>
       public bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }

    }
}
