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
       /// �ļ����
       /// </summary>
       public int DownID
       {
           get { return downID; }
           set { downID = value; }
       }

       /// <summary>
       /// �ļ�����
       /// </summary>
       public string DownName
       {
           get { return strDownName; }
           set { strDownName = value; }
       }

       /// <summary>
       /// ���ص�ַ
       /// </summary>
       public string DownURL
       {
           get { return strDownURL; }
           set { strDownURL = value; }
       }

       /// <summary>
       /// �ļ�����
       /// </summary>
       public int Rate
       {
           get { return intRate; }
           set { intRate = value; }
       }

       /// <summary>
       /// �ļ���С
       /// </summary>
       public int Size
       {
           get { return intSize; }
           set { intSize = value; }
       }

       /// <summary>
       /// ���ش���
       /// </summary>
       public int DownCount
       {
           get { return downCount; }
           set { downCount = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string Author
       {
           get { return strAuthor; }
           set { strAuthor = value; }
       }

       /// <summary>
       /// �ļ�����
       /// </summary>
       public string Dec
       {
           get { return strDec; }
           set { strDec = value; }
       }
    }
}
