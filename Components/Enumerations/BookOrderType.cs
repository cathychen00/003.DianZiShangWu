using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
   public enum BookOrderType
    {
       /// <summary>
       /// 审核中
       /// </summary>
       PassIng=-1,
       /// <summary>
       /// 未通过
       /// </summary>
       NoPass=0,
       /// <summary>
       /// 已通过
       /// </summary>
       Pass=1,
       /// <summary>
       /// 未付款
       /// </summary>
       NoPayMoney = 2,
       /// <summary>
       /// 已付款
       /// </summary>
       PayMoney=3,
       /// <summary>
       /// 处理中
       /// </summary>
       DealIng=4,
       /// <summary>
       /// 处理完毕
       /// </summary>
       Dealed=5
    }
}
