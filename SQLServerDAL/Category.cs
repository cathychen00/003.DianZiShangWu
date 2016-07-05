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
   public class Category:ICategory
    {
        #region ICategory 成员

       public IList<CategoryInfo> GetCategory(CategoryType categoryType, int categoryID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           
           List<CategoryInfo> categorys = new List<CategoryInfo>();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@categoryType", SqlDbType.Int, 4);
           objParams[1] = new SqlParameter("@categoryID", SqlDbType.Int, 4);
           objParams[0].Value = (int)categoryType;
           objParams[1].Value = categoryID;

           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Cat_GetCategory", objParams); ;
           while (reader.Read())
           {
               
               CategoryInfo item = new CategoryInfo();
               item.CategoryID = reader.GetInt32(reader.GetOrdinal("categoryID"));
               item.CategoryName = reader.GetString(reader.GetOrdinal("categoryName"));
               item.ParentID = reader.GetInt32(reader.GetOrdinal("parentID"));
               item.IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"));
               categorys.Add(item);
           }
           reader.Close();
           objSqlHelper.close();
           
           return categorys;
       }

       public IList<CategoryInfo> GetSameCategory(int parentID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<CategoryInfo> categorys = new List<CategoryInfo>();
           SqlParameter[] objParams = new SqlParameter[1];
           objParams[0] = new SqlParameter("@parentID", SqlDbType.Int, 4);
           objParams[0].Value = parentID;
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Cat_GetSameCategory", objParams);
           while (reader.Read())
           {
               CategoryInfo item = new CategoryInfo();
               item.CategoryID = reader.GetInt32(reader.GetOrdinal("categoryID"));
               item.CategoryName = reader.GetString(reader.GetOrdinal("categoryName"));
               item.ParentID = reader.GetInt32(reader.GetOrdinal("parentID"));
               categorys.Add(item);
           }
           reader.Close();
           objSqlHelper.close();
           
           return categorys;
       }

        public void InsertCategory(CategoryInfo category)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@categoryName", category.CategoryName);
            objParams[1] = new SqlParameter("@parentID", category.ParentID);
            objParams[2] = new SqlParameter("@IsMain", category.IsMain);
            objSqlHelper.ExecuteNonQuery("je_Cat_InsertCategory", objParams);
        }

        public int UpdateCategory(CategoryInfo category)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@categoryName", category.CategoryName);
            objParams[1] = new SqlParameter("@parentID", category.ParentID);
            objParams[2] = new SqlParameter("@IsMain", category.IsMain);
            objParams[3] = new SqlParameter("@categoryID", category.CategoryID);
            return objSqlHelper.ExecuteNonQuery("je_Cat_UpdateCategory", objParams);
        }

       public int DeleteCategory(int categoryId)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@categoryId", categoryId);
            return objSqlHelper.ExecuteNonQuery("je_Cat_DeleteCategory", objParams);
        }

        #endregion

        #region ICategory 成员


        public CategoryInfo GetCategoryByID(int categoryID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@categoryID", SqlDbType.Int, 4);
            objParams[0].Value = categoryID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Cat_GetCategoryByID", objParams);
            CategoryInfo item = new CategoryInfo();
            while (reader.Read())
            {
                item.CategoryID = reader.GetInt32(reader.GetOrdinal("categoryID"));
                item.CategoryName = reader.GetString(reader.GetOrdinal("categoryName"));
                item.ParentID = reader.GetInt32(reader.GetOrdinal("parentID"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"));
            }
            reader.Close();
            
            return item;
        }

        #endregion
    }
}
