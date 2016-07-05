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
   public class ImageBook:IImageBook
    {
        
        #region IImageBook 成员

        public IList<ImageBookInfo> GetImageBook(ImageBookType type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<ImageBookInfo> imageBooks = new List<ImageBookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = (int)type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_IB_GetImageBook", objParams);
            while (reader.Read())
            {
                ImageBookInfo item = GetImageBookByID(reader.GetInt32(reader.GetOrdinal("imageID")));
                imageBooks.Add(item);
            }
            reader.Close();
            return imageBooks;
        }

        public ImageBookInfo GetImageBookByID(int imageID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@imageID", SqlDbType.Int, 4);
            objParams[0].Value = imageID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_IB_GetImageBookByID", objParams);
            ImageBookInfo item = new ImageBookInfo();
            while (reader.Read())
            {
                item.ImageID = reader.GetInt32(reader.GetOrdinal("imageID"));
                item.ImageURL = reader.GetString(reader.GetOrdinal("ImageURL"));
                item.LinkURL = reader.GetString(reader.GetOrdinal("LinkURL"));
                item.ImageOrder = reader.GetInt32(reader.GetOrdinal("ImageOrder"));
                item.ImageStation = reader.GetInt32(reader.GetOrdinal("ImageStation"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("AddDate"));
            }
            reader.Close();
            return item;
        }

        public void InsertImageBook(ImageBookInfo image)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@ImageURL", image.ImageURL);
            objParams[1] = new SqlParameter("@LinkURL", image.LinkURL);
            objParams[2] = new SqlParameter("@ImageStation", image.ImageStation);
            objParams[3] = new SqlParameter("@IsMain", image.IsMain);
            objSqlHelper.ExecuteNonQuery("je_IB_InsertImageBook", objParams);
        }

        public int UpdateImageBook(ImageBookInfo image)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[5];
            objParams[0] = new SqlParameter("@ImageURL", image.ImageURL);
            objParams[1] = new SqlParameter("@LinkURL", image.LinkURL);
            objParams[2] = new SqlParameter("@ImageStation", image.ImageStation);
            objParams[3] = new SqlParameter("@IsMain", image.IsMain);
            objParams[4] = new SqlParameter("@ImageID", image.ImageID);
            return objSqlHelper.ExecuteNonQuery("je_IB_UpdateImageBook", objParams);
        }

        /// <summary>
        /// 更新图片信息
        /// </summary>
        /// <param name="g"></param>
       public int UpdateImageBook(UpdateImageType type, int order, int imageID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[3];
           objParams[0] = new SqlParameter("@type", (int)type);
           objParams[1] = new SqlParameter("@order", order);
           objParams[2] = new SqlParameter("@imageID", imageID);

           return objSqlHelper.ExecuteNonQuery("je_IB_UpdateImageBookOrder", objParams);
       }

        public int DeleteImageBookByID(int imageID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@imageID", imageID);
            return objSqlHelper.ExecuteNonQuery("je_IB_DeleteImageBookByID", objParams);
        }

        #endregion
    }
}
