using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 更新数量类型
    /// </summary>
   public enum CountType
    {
       /// <summary>
       /// 图书阅读数
       /// </summary>
       BookReadCount=0,
       /// <summary>
       /// 新闻阅读数
       /// </summary>
       DynamicReadCount=1,
       /// <summary>
       /// 图书库存
       /// </summary>
       BookStock=2,
       /// <summary>
       /// 评论数
       /// </summary>
       ReviewCount=3,
       /// <summary>
       /// 评价
       /// </summary>
       Rate=4,
       /// <summary>
       /// 下载
       /// </summary>
       DownLoad=5
    }
}
