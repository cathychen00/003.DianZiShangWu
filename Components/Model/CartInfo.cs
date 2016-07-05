using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 购物车
    /// </summary>
   public class CartInfo:BookInfo
    {
        private int _id;
        private string _name;
        private int _quantity;
        private bool _isTg;

       /// <summary>
       /// 是否团购
       /// </summary>
       public bool IsTg
       {
           get { return _isTg; }
           set { _isTg = value; }
       }

       /// <summary>
       /// 购物车编号
       /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 用户
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}
