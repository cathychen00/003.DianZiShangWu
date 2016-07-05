using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ͼ��ʵ����
    /// </summary>
    /// <remarks></remarks>
   public class BookInfo
    {
       private int intBookID;
       private string strBookName;
       private string strBookCss;
       private string strBookAuthor;
       private string strBookPublish;

       private string strBookISBN;
       private DateTime dtPublishTime;
       private string strBookImage;
       private string strBookEditions;
       private int intBookPages;

       private int intReadCount;
       private int intReviewCount;
       private int intSaleCount;
       private int intStock;
       private decimal ftRate;

       private decimal ftPrice;
       private decimal ftMemberPrice;
       private decimal ftVipPrice;
       private string strBookDec;
       private int intCategory;

       private bool isGood;
       private bool isExpect;
       private bool isMain;

       private string strBookSmallImage;

       private bool isRelease;
       private bool isCheap;
       private bool isSaleGood;
       private bool reviewEnable;
       private string strSmallBookDec;
       private string searchKey;
       private DateTime addDate;
       private int intTeacherID;
       private int intCatenaID;
       private int intRebate;
       private int intVipRebate;
       private IList<BookInfo> bookInfo;


       /// <summary>
       /// �ۿ�
       /// </summary>
       public int Rebate
       {
           get { return intRebate; }
           set { intRebate = value; }
       }

       /// <summary>
       /// �Ŷ��ۿ�
       /// </summary>
       public int VipRebate
       {
           get { return intVipRebate; }
           set { intVipRebate = value; }
       }

       /// <summary>
       /// ��ʦ���
       /// </summary>
       public int TeacherID
       {
           get { return intTeacherID; }
           set { intTeacherID = value; }
       }

       /// <summary>
       /// ͼ��ϵ�б��
       /// </summary>
       public int CatenaID
       {
           get { return intCatenaID; }
           set { intCatenaID = value; }
       }

       public IList<BookInfo> Book
       {
           get { return bookInfo; }
           set { bookInfo = value; }
       }

       #region ͼ����,����,������ʽ,����,������

       /// <summary>
       /// ͼ����
       /// </summary>
       public int BookID
       {
           get { return intBookID; }
           set { intBookID = value; }
       }


       /// <summary>
       /// ����
       /// </summary>
       public string BookName
       {
           get { return strBookName; }
           set { strBookName = value; }
       }

       /// <summary>
       /// ������ʽ
       /// </summary>
       public string BookCss
       {
           get { return strBookCss; }
           set { strBookCss = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string BookAuthor
       {
           get { return strBookAuthor; }
           set { strBookAuthor = value; }
       }

       /// <summary>
       /// ������
       /// </summary>
       public string BookPublish
       {
           get { return strBookPublish; }
           set { strBookPublish = value; }
       }

       #endregion

       #region ���ʱ��,��������,����,���,ҳ��

       /// <summary>
       /// ����ͼ����
       /// </summary>
       public string BookISBN
       {
           get { return strBookISBN; }
           set { strBookISBN = value; }
       }


       /// <summary>
       /// ��������
       /// </summary>
       public DateTime PublishTime
       {
           get { return dtPublishTime; }
           set { dtPublishTime = value; }
       }

       /// <summary>
       /// ͼ�����
       /// </summary>
       public string BookImage
       {
           get { return strBookImage; }
           set { strBookImage = value; }
       }

       /// <summary>
       /// ���
       /// </summary>
       public string BookEditions
       {
           get { return strBookEditions; }
           set { strBookEditions = value; }
       }

       /// <summary>
       /// ҳ��
       /// </summary>
       public int BookPages
       {
           get { return intBookPages; }
           set { intBookPages = value; }
       }

       #endregion

       #region �Ķ�����,��������,��������,���,����

       /// <summary>
       /// �Ķ�����
       /// </summary>
       public int ReadCount
       {
           get { return intReadCount; }
           set { intReadCount = value; }
       }


       /// <summary>
       /// ��������
       /// </summary>
       public int ReviewCount
       {
           get { return intReviewCount; }
           set { intReviewCount = value; }
       }

       /// <summary>
       /// ��������
       /// </summary>
       public int SaleCount
       {
           get { return intSaleCount; }
           set { intSaleCount = value; }
       }

       /// <summary>
       /// ���
       /// </summary>
       public int Stock
       {
           get { return intStock; }
           set { intStock = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public decimal Rate
       {
           get { return ftRate; }
           set { ftRate = value; }
       }

       #endregion

       #region ԭ��,��Ա�۸�,ͼ�����ݽ���,ͼ�����

       /// <summary>
       /// ԭ��
       /// </summary>
       public decimal Price
       {
           get { return ftPrice; }
           set { ftPrice = value; }
       }

       /// <summary>
       /// ��Ա��
       /// </summary>
       public decimal MemberPrice
       {
           get { return ftMemberPrice; }
           set { ftMemberPrice = value; }
       }

       /// <summary>
       /// �Ź���
       /// </summary>
       public decimal VipPrice
       {
           get { return ftVipPrice; }
           set { ftVipPrice = value; }
       }

       /// <summary>
       /// ���ݽ���
       /// </summary>
       public string BookDec
       {
           get { return strBookDec; }
           set { strBookDec = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public int Category
       {
           get { return intCategory; }
           set { intCategory = value; }
       }

       #endregion

       #region �Ƿ񷢲����Ƿ��ؼۣ��Ƿ��������Ƽ�,����,��ʾ����ҳ

       /// <summary>
       /// �Ƿ񷢲�
       /// </summary>
       public bool IsRelease
       {
           get { return isRelease; }
           set { isRelease = value; }
       }

       /// <summary>
       /// �Ƿ��ؼ�
       /// </summary>
       public bool IsCheap
       {
           get { return isCheap; }
           set { isCheap = value; }
       }

       /// <summary>
       /// �Ƿ�����
       /// </summary>
       public bool IsSaleGood
       {
           get { return isSaleGood; }
           set { isSaleGood = value; }
       }

       /// <summary>
       /// �Ƿ�Ϊ�Ƽ��鼮
       /// </summary>
       public bool IsGood
       {
           get { return isGood; }
           set { isGood = value; }
       }

       /// <summary>
       /// �Ƿ�Ϊ����
       /// </summary>
       public bool IsExpect
       {
           get { return isExpect; }
           set { isExpect = value; }
       }

       /// <summary>
       /// �Ƿ���ʾ����ҳ
       /// </summary>
       public bool IsMain
       {
           get { return isMain; }
           set { isMain = value; }
       }

       #endregion



       /// <summary>
       /// ͼ�����
       /// </summary>
       public string BookSmallImage
       {
           get { return strBookSmallImage; }
           set { strBookSmallImage = value; }
       }

       /// <summary>
       /// �Ƿ���������
       /// </summary>
       public bool ReviewEnable
       {
           get { return reviewEnable; }
           set { reviewEnable = value; }
       }

       /// <summary>
       /// ͼ����
       /// </summary>
       public string SmallBookDec
       {
           get { return strSmallBookDec; }
           set { strSmallBookDec = value; }
       }

       /// <summary>
       /// ��������ؼ���
       /// </summary>
       public string SearchKey
       {
           get { return searchKey; }
           set { searchKey = value; }
       }

       /// <summary>
       /// ��������ؼ���
       /// </summary>
       public DateTime AddDate
       {
           get { return addDate; }
           set { addDate = value; }
       }

       public CategoryInfo CategoryInfo
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

       public ReviewInfo ReviewInfo
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }


       public BookCatenaInfo BookCatenaInfo
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

       public PublishInfo PublishInfo
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }
   }
}
