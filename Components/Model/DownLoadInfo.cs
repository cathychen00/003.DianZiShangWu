using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
   public class DownLoadInfo:DownClassInfo
    {
       private int downID;
       private string strDownName;
       private int intRate;
       private int intSize;
       private int downCount;
       private string strDownURL;
       private string strAuthor;
       private string strDec;

       /// <summary>
       /// 文件编号
       /// </summary>
       public int DownID
       {
           get { return downID; }
           set { downID = value; }
       }

       /// <summary>
       /// 文件名称
       /// </summary>
       public string DownName
       {
           get { return strDownName; }
           set { strDownName = value; }
       }

       /// <summary>
       /// 下载地址
       /// </summary>
       public string DownURL
       {
           get { return strDownURL; }
           set { strDownURL = value; }
       }

       /// <summary>
       /// 文件评价
       /// </summary>
       public int Rate
       {
           get { return intRate; }
           set { intRate = value; }
       }

       /// <summary>
       /// 文件大小
       /// </summary>
       public int Size
       {
           get { return intSize; }
           set { intSize = value; }
       }

       /// <summary>
       /// 下载次数
       /// </summary>
       public int DownCount
       {
           get { return downCount; }
           set { downCount = value; }
       }

       /// <summary>
       /// 作者
       /// </summary>
       public string Author
       {
           get { return strAuthor; }
           set { strAuthor = value; }
       }

       /// <summary>
       /// 文件介绍
       /// </summary>
       public string Dec
       {
           get { return strDec; }
           set { strDec = value; }
       }
    }
}
