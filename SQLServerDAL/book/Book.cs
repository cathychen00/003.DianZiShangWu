using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using Jiaen.Components.IDAL;
using Jiaen.Components;
using Jiaen.Components.Utility;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Jiaen.SQLServerDAL
{
    public class Book : IBook
    {
        #region IBook 成员

        public IList<BookInfo> GetIndexBook(ViewBookType type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = (int)type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetIndexBook", objParams);

            while (reader.Read())
            {
                BookInfo item = new BookInfo();
                item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        public IList<BookInfo> GetBook(BookType type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = (int)type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetBook",objParams);
            while (reader.Read())
            {
                BookInfo item = new BookInfo();
                item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        public IList<BookInfo> GetTopBook(int year,int month,int catID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@year", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@month", SqlDbType.Int, 4);
            objParams[2] = new SqlParameter("@catID", SqlDbType.Int, 4);
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetTopBook", objParams);
            while (reader.Read())
            {
                BookInfo item = new BookInfo();
                item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        public BookInfo GetBookByID(int bookID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@bookID", SqlDbType.Int, 4);
            objParams[0].Value = bookID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetBookByID", objParams);
            BookInfo item = new BookInfo();
            while (reader.Read())
            {
                //图书编号
                item.BookID = reader.GetInt32(reader.GetOrdinal("BookID"));
                //图书名字，分类，价格，会员价格,大图,小图
                item.BookName = reader.GetString(reader.GetOrdinal("BookName"));
                item.Category = reader.GetInt32(reader.GetOrdinal("bookCategory"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("bookPrice"));
                item.MemberPrice = reader.GetDecimal(reader.GetOrdinal("bookMemberPrice"));
                item.BookPublish = reader.GetString(reader.GetOrdinal("BookPublish"));
                item.BookImage = reader.GetString(reader.GetOrdinal("BookImage"));
                item.BookSmallImage = reader.GetString(reader.GetOrdinal("bookSmallImage"));
                //是否发布，是否推荐，是否特价，是否热卖，是否允许评论,库存数量
                item.IsRelease = reader.GetBoolean(reader.GetOrdinal("isRelease"));
                item.IsGood = reader.GetBoolean(reader.GetOrdinal("isGood"));
                item.IsCheap = reader.GetBoolean(reader.GetOrdinal("isCheap"));
                item.IsSaleGood = reader.GetBoolean(reader.GetOrdinal("isSaleGood"));
                item.ReviewEnable = reader.GetBoolean(reader.GetOrdinal("reviewEnable"));
                item.Stock = reader.GetInt32(reader.GetOrdinal("bookStock"));
                //图书简介，作者，出版时间，国际编号，出版社，页数，版次
                item.SmallBookDec = reader.GetString(reader.GetOrdinal("smallBookDesc"));
                item.BookAuthor = reader.GetString(reader.GetOrdinal("bookAuthor"));
                item.PublishTime = reader.GetDateTime(reader.GetOrdinal("bookPublishTime"));
                item.BookISBN = reader.GetString(reader.GetOrdinal("bookISBN"));
                item.BookPublish = reader.GetString(reader.GetOrdinal("bookPublish"));
                item.BookPages = reader.GetInt32(reader.GetOrdinal("bookPages"));
                item.BookEditions = reader.GetString(reader.GetOrdinal("bookEditions"));
                //是否为期书,搜索关键字,加入时间,具体介绍
                item.IsExpect = reader.GetBoolean(reader.GetOrdinal("isExpect"));
                item.SearchKey = reader.GetString(reader.GetOrdinal("searchKey"));
                item.BookDec = reader.GetString(reader.GetOrdinal("BookDec"));
                item.ReadCount = reader.GetInt32(reader.GetOrdinal("bookReadCount"));
                item.ReviewCount = reader.GetInt32(reader.GetOrdinal("bookCommentCount"));
                //
                item.TeacherID = reader.GetInt32(reader.GetOrdinal("TeacherID"));
                item.CatenaID = reader.GetInt32(reader.GetOrdinal("CatenaID"));
                item.Rate = reader.GetDecimal(reader.GetOrdinal("bookRate"));
                //折扣，团队折扣，团队价格
                item.Rebate = reader.GetInt32(reader.GetOrdinal("Rebate"));
                item.VipRebate = reader.GetInt32(reader.GetOrdinal("VipRebate"));
                item.VipPrice = reader.GetDecimal(reader.GetOrdinal("VipPrice"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"));
            }
            reader.Close();
            return item;
        }

        public IList<BookInfo> GetCatBookByID(string bookName)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@bookName", SqlDbType.VarChar, 50);
            objParams[0].Value = bookName;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetCatBookByID", objParams);

            while (reader.Read())
            {
                BookInfo item = new BookInfo();
                item.BookID = reader.GetInt32(reader.GetOrdinal("BookID"));
                item.BookName = reader.GetString(reader.GetOrdinal("BookName"));
                item.BookPublish = reader.GetString(reader.GetOrdinal("BookPublish"));
                item.BookImage = reader.GetString(reader.GetOrdinal("BookImage"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("bookPrice"));
                item.MemberPrice = reader.GetDecimal(reader.GetOrdinal("bookMemberPrice"));
                item.BookSmallImage = reader.GetString(reader.GetOrdinal("bookSmallImage"));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        public void InsertBook(BookInfo book)
        {
            
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[26];
            //图书名字，分类，价格，会员价格,大图,小图
            objParams[0] = new SqlParameter("@bookName", book.BookName);
            objParams[1] = new SqlParameter("@bookCategory", book.Category);
            objParams[2] = new SqlParameter("@bookPrice", book.Price);
            objParams[3] = new SqlParameter("@bookMemberPrice", book.MemberPrice);
            objParams[4] = new SqlParameter("@bookImage", StringHelper.convertStr(book.BookImage));
            objParams[5] = new SqlParameter("@bookSmallImage",StringHelper.convertStr(book.BookSmallImage));
            //是否发布，是否推荐，是否特价，是否热卖，是否允许评论,库存数量
            objParams[6] = new SqlParameter("@isRelease", book.IsRelease);
            objParams[7] = new SqlParameter("@isGood", book.IsGood);
            objParams[8] = new SqlParameter("@isCheap", book.IsCheap);
            objParams[9] = new SqlParameter("@isSaleGood", book.IsSaleGood);
            objParams[10] = new SqlParameter("@reviewEnable", book.ReviewEnable);
            objParams[11] = new SqlParameter("@bookStock", book.Stock);
            //图书简介，作者，出版时间，国际编号，出版社，页数，版次
            objParams[12] = new SqlParameter("@smallBookDesc", StringHelper.convertStr(book.BookDec));
            objParams[13] = new SqlParameter("@bookAuthor", StringHelper.convertStr(book.BookAuthor));
            objParams[14] = new SqlParameter("@bookPublishTime", book.PublishTime);
            objParams[15] = new SqlParameter("@bookISBN", StringHelper.convertStr(book.BookISBN));
            objParams[16] = new SqlParameter("@bookPublish", StringHelper.convertStr(book.BookPublish));
            objParams[17] = new SqlParameter("@bookPages", book.BookPages);
            objParams[18] = new SqlParameter("@bookEditions", StringHelper.convertStr(book.BookEditions));
            //是否为期书,搜索关键字,加入时间,具体介绍
            objParams[19] = new SqlParameter("@isExpect", book.IsExpect);
            objParams[20] = new SqlParameter("@searchKey", StringHelper.convertStr(book.SearchKey));
            objParams[21] = new SqlParameter("@TeacherID", book.TeacherID);
            objParams[22] = new SqlParameter("@BookDec", StringHelper.convertStr(book.BookDec));
            objParams[23] = new SqlParameter("@CatenaID", book.CatenaID);
            //团购价格
            objParams[24] = new SqlParameter("@VipPrice", book.VipPrice);
            objParams[25] = new SqlParameter("@IsMain", book.IsMain);
            objSqlHelper.ExecuteNonQuery("je_Book_InsertBook", objParams);
        }

        public int UpdateBook(BookInfo book)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[27];
            //图书名字，分类，价格，会员价格,大图,小图
            objParams[0] = new SqlParameter("@bookName", book.BookName);
            objParams[1] = new SqlParameter("@bookCategory", book.Category);
            objParams[2] = new SqlParameter("@bookPrice", book.Price);
            objParams[3] = new SqlParameter("@bookMemberPrice", book.MemberPrice);
            objParams[4] = new SqlParameter("@bookImage", StringHelper.convertStr(book.BookImage));
            objParams[5] = new SqlParameter("@bookSmallImage", StringHelper.convertStr(book.BookSmallImage));
            //是否发布，是否推荐，是否特价，是否热卖，是否允许评论,库存数量
            objParams[6] = new SqlParameter("@isRelease", book.IsRelease);
            objParams[7] = new SqlParameter("@isCheap", book.IsCheap);
            objParams[8] = new SqlParameter("@isGood", book.IsGood);
            objParams[9] = new SqlParameter("@isSaleGood", book.IsSaleGood);
            objParams[10] = new SqlParameter("@reviewEnable", book.ReviewEnable);
            objParams[11] = new SqlParameter("@bookStock", book.Stock);
            //图书简介，作者，出版时间，国际编号，出版社，页数，版次
            objParams[12] = new SqlParameter("@smallBookDesc", StringHelper.convertStr(book.SmallBookDec));
            objParams[13] = new SqlParameter("@bookAuthor", StringHelper.convertStr(book.BookAuthor));
            objParams[14] = new SqlParameter("@bookPublishTime", book.PublishTime);
            objParams[15] = new SqlParameter("@bookISBN", StringHelper.convertStr(book.BookISBN));
            objParams[16] = new SqlParameter("@bookPublish", book.BookPublish);
            objParams[17] = new SqlParameter("@bookPages", book.BookPages);
            objParams[18] = new SqlParameter("@bookEditions", StringHelper.convertStr(book.BookEditions));
            //是否为期书,搜索关键字,加入时间,具体介绍
            objParams[19] = new SqlParameter("@isExpect", book.IsExpect);
            objParams[20] = new SqlParameter("@searchKey", StringHelper.convertStr(book.SearchKey));
            objParams[21] = new SqlParameter("@TeacherID", book.TeacherID);
            objParams[22] = new SqlParameter("@BookDec", StringHelper.convertStr(book.BookDec));
            objParams[23] = new SqlParameter("@CatenaID", book.CatenaID);
            objParams[24] = new SqlParameter("@bookID", book.BookID);
            objParams[25] = new SqlParameter("@VipPrice", book.VipPrice);
            objParams[26] = new SqlParameter("@IsMain", book.IsMain);
            return objSqlHelper.ExecuteNonQuery("je_Book_UpdateBook", objParams);
        }

        public int DeleteBook(int bookID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@bookID", bookID);
            return objSqlHelper.ExecuteNonQuery("je_Book_DeleteBook", objParams);
        }

        public IList<BookInfo> GetCheapBook(int type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetCheapBook", objParams);
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        public int UpdatePrice(BookInfo book)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@bookPrice", book.Price);
            objParams[1] = new SqlParameter("@bookMemberPrice", book.MemberPrice);
            objParams[2] = new SqlParameter("@bookID", book.BookID);
            return objSqlHelper.ExecuteNonQuery("je_Book_UpdatePrice", objParams);
        }

        public IList<BookInfo> GetBookByCatID(int type, int catID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@bookCategory", SqlDbType.Int, 4);
            objParams[0].Value = type;
            objParams[1].Value = catID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetBookByCatID", objParams); ;
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        /// <summary>
        /// 获取最新图书
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catID"></param>
        /// <returns></returns>
       public IList<BookInfo> GetNewBook(int type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetNewBook", objParams); ;
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        /// <summary>
        /// 获取月图书排行
        /// </summary>
        /// <returns></returns>
        public IList<BookInfo> GetTopBook(int year, int month)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@year", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@month", SqlDbType.Int, 4);
            objParams[0].Value = year;
            objParams[1].Value = month;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetTopBook", objParams); ;
            while (reader.Read())
            {
                BookInfo item = new BookInfo();
                item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        /// <summary>
        /// 获取分类图书排行
        /// </summary>
        /// <returns></returns>
        public IList<BookInfo> GetTopBook(int year, int month, int catID, CatType type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@year", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@month", SqlDbType.Int, 4);
            objParams[2] = new SqlParameter("@catID", SqlDbType.Int, 4);
            objParams[3] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = year;
            objParams[1].Value = month;
            objParams[2].Value = catID;
            objParams[3].Value = (int)type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetTopBookBycat", objParams); ;
            while (reader.Read())
            {
                BookInfo item = new BookInfo();
                item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();
            return books;
        }

        /// <summary>
        /// 获取可团购图书
        /// </summary>
        /// <returns></returns>
        public IList<BookInfo> GetTgBook()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
          
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetTgBook");
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        #endregion

        #region IBook 成员


        public int UpdateCount(CountType type, int ID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@type", (int)type);
            objParams[1] = new SqlParameter("@ID", ID);
            return objSqlHelper.ExecuteNonQuery("je_Book_UpdateCount", objParams);
        }

        public int UpdateStockCount(int ID,int count)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ID", ID);
            objParams[1] = new SqlParameter("@count", count);
            return objSqlHelper.ExecuteNonQuery("je_Book_UpdateStockCount", objParams);
        }

        public int UpdateRebate(float rebate, int ID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@rebate", rebate);
            objParams[1] = new SqlParameter("@ID", ID);

            return objSqlHelper.ExecuteNonQuery("je_Book_UpdateRebate", objParams);
        }

        public IList<BookInfo> GetBookByParentID(int type, int catID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@bookCategory", SqlDbType.Int, 4);
            objParams[0].Value = type;
            objParams[1].Value = catID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetBookByParentID", objParams); ;
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        public IList<BookInfo> GetSearchBook(int type, string key)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@key", SqlDbType.VarChar, 100);
            objParams[0].Value = (int)type;
            objParams[1].Value = key;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetSearchBook", objParams);
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        public IList<BookInfo> GetTeacherBook(int type, int teacherID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@teacherID", SqlDbType.Int, 4);
            objParams[0].Value = type;
            objParams[1].Value = teacherID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetTeacherBook", objParams);
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        public IList<BookInfo> GetCheapTopBook()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Book_GetCheapTopBook");
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        #endregion


        #region IBook 成员


        public IList<BookInfo> GetAdvanceSearchBook(string[] key)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookInfo> books = new List<BookInfo>();
            SqlParameter[] objParams = new SqlParameter[8];
            objParams[0] = new SqlParameter("@bookName", SqlDbType.VarChar,50);
            objParams[1] = new SqlParameter("@bookPublish", SqlDbType.VarChar, 50);
            objParams[2] = new SqlParameter("@bookAuthor", SqlDbType.VarChar, 50);
            objParams[3] = new SqlParameter("@bookCategory", SqlDbType.Int, 4);
            objParams[4] = new SqlParameter("@bookISBN", SqlDbType.VarChar, 50);
            objParams[5] = new SqlParameter("@bookPrice", SqlDbType.Money, 4);
            objParams[6] = new SqlParameter("@year", SqlDbType.VarChar, 4);
            objParams[7] = new SqlParameter("@month", SqlDbType.VarChar, 4);
            objParams[0].Value = key[0];
            objParams[1].Value = key[1];
            objParams[2].Value = key[2];
            objParams[3].Value = key[3];
            objParams[4].Value = key[4];
            objParams[5].Value = key[5];
            objParams[6].Value = key[7];
            objParams[7].Value = key[8];
            string mysql = @"select DISTINCT bookID, bookName, bookCategory, bookImage, 
            bookSmallImage, bookPrice, bookMemberPrice, bookStock, 
            bookAuthor, bookPublish,isGood,addDate 
            from je_category, je_books where bookName LIKE '%' + @bookName + '%'";
            if (key[1] != "")
            {
                mysql += " and bookPublish LIKE '%' + @bookPublish + '%'";
            }
            if (key[2] != "")
            {
                mysql += " and bookAuthor LIKE '%' + @bookAuthor + '%'";
            }
            if (key[3] != "0")
            {
                mysql += " and bookCategory in";
                mysql += @"(SELECT DISTINCT categoryID
                FROM je_category, je_books
                WHERE categoryID = @bookCategory
                UNION ALL
                SELECT DISTINCT categoryID
                FROM je_category, je_books
                WHERE je_category.Parentid = @bookCategory)";
            }
            if (key[4] != "")
            {
                mysql += " and bookISBN=bookISBN";
            }
            if (key[5] != "0")
            {
                switch (key[6])
                {
                    case "1":
                        mysql += " and bookMemberPrice>@bookPrice";
                        break;
                    case "2":
                        mysql += " and bookMemberPrice=@bookPrice";
                        break;
                    case "3":
                        mysql += " and bookMemberPrice<@bookPrice";
                        break;
                }
            }
            if (key[7] != "0")
            {
                mysql += " and Year(je_books.addDate) = @Year";
            }
            
            if (key[8] != "0")
            {
                mysql += " and DatePart(mm, je_books.addDate) = @Month";
            }

            mysql += " ORDER BY je_books.addDate DESC";
            SqlDataReader reader = objSqlHelper.ExecuteReader(mysql, objParams);
            while (reader.Read())
            {
                BookInfo item = GetBookByID(reader.GetInt32(reader.GetOrdinal("BookID")));
                books.Add(item);
            }
            reader.Close();

            return books;
        }

        #endregion
    }
}
