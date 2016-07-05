using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 图书实体类
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
       /// 折扣
       /// </summary>
       public int Rebate
       {
           get { return intRebate; }
           set { intRebate = value; }
       }

       /// <summary>
       /// 团队折扣
       /// </summary>
       public int VipRebate
       {
           get { return intVipRebate; }
           set { intVipRebate = value; }
       }

       /// <summary>
       /// 教师编号
       /// </summary>
       public int TeacherID
       {
           get { return intTeacherID; }
           set { intTeacherID = value; }
       }

       /// <summary>
       /// 图书系列编号
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

       #region 图书编号,书名,标题样式,作者,出版社

       /// <summary>
       /// 图书编号
       /// </summary>
       public int BookID
       {
           get { return intBookID; }
           set { intBookID = value; }
       }


       /// <summary>
       /// 书名
       /// </summary>
       public string BookName
       {
           get { return strBookName; }
           set { strBookName = value; }
       }

       /// <summary>
       /// 标题样式
       /// </summary>
       public string BookCss
       {
           get { return strBookCss; }
           set { strBookCss = value; }
       }

       /// <summary>
       /// 作者
       /// </summary>
       public string BookAuthor
       {
           get { return strBookAuthor; }
           set { strBookAuthor = value; }
       }

       /// <summary>
       /// 出版社
       /// </summary>
       public string BookPublish
       {
           get { return strBookPublish; }
           set { strBookPublish = value; }
       }

       #endregion

       #region 国际编号,出版日期,封面,版次,页数

       /// <summary>
       /// 国际图书编号
       /// </summary>
       public string BookISBN
       {
           get { return strBookISBN; }
           set { strBookISBN = value; }
       }


       /// <summary>
       /// 出版日期
       /// </summary>
       public DateTime PublishTime
       {
           get { return dtPublishTime; }
           set { dtPublishTime = value; }
       }

       /// <summary>
       /// 图书封面
       /// </summary>
       public string BookImage
       {
           get { return strBookImage; }
           set { strBookImage = value; }
       }

       /// <summary>
       /// 版次
       /// </summary>
       public string BookEditions
       {
           get { return strBookEditions; }
           set { strBookEditions = value; }
       }

       /// <summary>
       /// 页数
       /// </summary>
       public int BookPages
       {
           get { return intBookPages; }
           set { intBookPages = value; }
       }

       #endregion

       #region 阅读总数,评论总数,销售总数,库存,评级

       /// <summary>
       /// 阅读总数
       /// </summary>
       public int ReadCount
       {
           get { return intReadCount; }
           set { intReadCount = value; }
       }


       /// <summary>
       /// 评论总数
       /// </summary>
       public int ReviewCount
       {
           get { return intReviewCount; }
           set { intReviewCount = value; }
       }

       /// <summary>
       /// 销售总数
       /// </summary>
       public int SaleCount
       {
           get { return intSaleCount; }
           set { intSaleCount = value; }
       }

       /// <summary>
       /// 库存
       /// </summary>
       public int Stock
       {
           get { return intStock; }
           set { intStock = value; }
       }

       /// <summary>
       /// 评级
       /// </summary>
       public decimal Rate
       {
           get { return ftRate; }
           set { ftRate = value; }
       }

       #endregion

       #region 原价,会员价格,图书内容介绍,图书分类

       /// <summary>
       /// 原价
       /// </summary>
       public decimal Price
       {
           get { return ftPrice; }
           set { ftPrice = value; }
       }

       /// <summary>
       /// 会员价
       /// </summary>
       public decimal MemberPrice
       {
           get { return ftMemberPrice; }
           set { ftMemberPrice = value; }
       }

       /// <summary>
       /// 团购价
       /// </summary>
       public decimal VipPrice
       {
           get { return ftVipPrice; }
           set { ftVipPrice = value; }
       }

       /// <summary>
       /// 内容介绍
       /// </summary>
       public string BookDec
       {
           get { return strBookDec; }
           set { strBookDec = value; }
       }

       /// <summary>
       /// 分类
       /// </summary>
       public int Category
       {
           get { return intCategory; }
           set { intCategory = value; }
       }

       #endregion

       #region 是否发布，是否特价，是否热卖，推荐,期书,显示在主页

       /// <summary>
       /// 是否发布
       /// </summary>
       public bool IsRelease
       {
           get { return isRelease; }
           set { isRelease = value; }
       }

       /// <summary>
       /// 是否特价
       /// </summary>
       public bool IsCheap
       {
           get { return isCheap; }
           set { isCheap = value; }
       }

       /// <summary>
       /// 是否热卖
       /// </summary>
       public bool IsSaleGood
       {
           get { return isSaleGood; }
           set { isSaleGood = value; }
       }

       /// <summary>
       /// 是否为推荐书籍
       /// </summary>
       public bool IsGood
       {
           get { return isGood; }
           set { isGood = value; }
       }

       /// <summary>
       /// 是否为期书
       /// </summary>
       public bool IsExpect
       {
           get { return isExpect; }
           set { isExpect = value; }
       }

       /// <summary>
       /// 是否显示在首页
       /// </summary>
       public bool IsMain
       {
           get { return isMain; }
           set { isMain = value; }
       }

       #endregion



       /// <summary>
       /// 图书封面
       /// </summary>
       public string BookSmallImage
       {
           get { return strBookSmallImage; }
           set { strBookSmallImage = value; }
       }

       /// <summary>
       /// 是否允许评论
       /// </summary>
       public bool ReviewEnable
       {
           get { return reviewEnable; }
           set { reviewEnable = value; }
       }

       /// <summary>
       /// 图书简介
       /// </summary>
       public string SmallBookDec
       {
           get { return strSmallBookDec; }
           set { strSmallBookDec = value; }
       }

       /// <summary>
       /// 相关搜索关键字
       /// </summary>
       public string SearchKey
       {
           get { return searchKey; }
           set { searchKey = value; }
       }

       /// <summary>
       /// 相关搜索关键字
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
