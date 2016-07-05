using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ���ﳵ
    /// </summary>
   public class CartInfo:BookInfo
    {
        private int _id;
        private string _name;
        private int _quantity;
        private bool _isTg;

       /// <summary>
       /// �Ƿ��Ź�
       /// </summary>
       public bool IsTg
       {
           get { return _isTg; }
           set { _isTg = value; }
       }

       /// <summary>
       /// ���ﳵ���
       /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// �û�
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}
