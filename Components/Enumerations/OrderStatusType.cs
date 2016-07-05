using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatusType
    {
        /// <summary>
        /// 是否审核
        /// </summary>
        Pass=0,
        /// <summary>
        /// 是否付款
        /// </summary>
        Pay=1,
        /// <summary>
        /// 是否发货
        /// </summary>
        Send=2,
        /// <summary>
        /// 是否归档
        /// </summary>
        Finished=3,
        /// <summary>
        /// 是否取消
        /// </summary>
        Cancel=4
    }
}
