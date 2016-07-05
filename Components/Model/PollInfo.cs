using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ͶƱʵ����
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
       /// ͶƱ���
       /// </summary>
       public int PollID
       {
           get { return intPollID; }
           set { intPollID = value; }
       }

       /// <summary>
       /// ͶƱ����
       /// </summary>
       public string Title
       {
           get { return strTitle; }
           set { strTitle = value; }
       }

       /// <summary>
       /// ͶƱ��Ŀ
       /// </summary>
       public string Items
       {
           get { return strItems; }
           set { strItems = value; }
       }

       /// <summary>
       /// ͶƱ��Ŀ
       /// </summary>
       public string Num
       {
           get { return strNum; }
           set { strNum = value; }
       }

       /// <summary>
       /// �Ƿ�ɶ�ѡ
       /// </summary>
       public bool IsMultiple
       {
           get { return isMultiple; }
           set { isMultiple = value; }
       }

       /// <summary>
       /// ��ҳ��ʾ
       /// </summary>
       public bool InIndex
       {
           get { return inIndex; }
           set { inIndex = value; }
       }

       /// <summary>
       /// ����ͶƱ���
       /// </summary>
       public bool CanView
       {
           get { return canView; }
           set { canView = value; }
       }
    }
}
