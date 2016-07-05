using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 投票实体类
    /// </summary>
   public class PollInfo
    {
       private int intPollID;
       private string strTitle;
       private string strItems;
       private string strNum;
       private bool isMultiple;
       private bool inIndex;
       private bool canView;

       /// <summary>
       /// 投票编号
       /// </summary>
       public int PollID
       {
           get { return intPollID; }
           set { intPollID = value; }
       }

       /// <summary>
       /// 投票标题
       /// </summary>
       public string Title
       {
           get { return strTitle; }
           set { strTitle = value; }
       }

       /// <summary>
       /// 投票项目
       /// </summary>
       public string Items
       {
           get { return strItems; }
           set { strItems = value; }
       }

       /// <summary>
       /// 投票数目
       /// </summary>
       public string Num
       {
           get { return strNum; }
           set { strNum = value; }
       }

       /// <summary>
       /// 是否可多选
       /// </summary>
       public bool IsMultiple
       {
           get { return isMultiple; }
           set { isMultiple = value; }
       }

       /// <summary>
       /// 首页显示
       /// </summary>
       public bool InIndex
       {
           get { return inIndex; }
           set { inIndex = value; }
       }

       /// <summary>
       /// 公开投票结果
       /// </summary>
       public bool CanView
       {
           get { return canView; }
           set { canView = value; }
       }
    }
}
