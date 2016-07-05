using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;

namespace Jiaen.BLL
{
    [DataObjectAttribute]
   public class Category
    {
       private static readonly ICategory categorys = DataAccess.CreateCategory();

       /// <summary>
       /// 获取分类图书
       /// </summary>
       /// <returns></returns>
       public static IList<CategoryInfo> GetCategory(CategoryType categoryType, int categoryID)
       {
           return categorys.GetCategory(categoryType, categoryID);
       }

       /// <summary>
       /// 获取同类分类
       /// </summary>
       /// <returns></returns>
       public static IList<CategoryInfo> GetSameCategory(int parentID)
       {
           return categorys.GetSameCategory(parentID);
       }

       /// <summary>
       /// 新增分类
       /// </summary>
       /// <param name="category"></param>
       public static void InsertCategory(CategoryInfo category)
       {
           categorys.InsertCategory(category);
       }

       /// <summary>
       /// 更新分类
       /// </summary>
       /// <param name="category"></param>
       public static int UpdateCategory(CategoryInfo category)
       {
           return categorys.UpdateCategory(category);
       }


       public static int DeleteCategory(int categoryId)
       {
           return categorys.DeleteCategory(categoryId);
       }

       /// <summary>
       /// 获取特定分类
       /// </summary>
       /// <returns></returns>
       public static CategoryInfo GetCategoryByID(int categoryID)
       {
           return categorys.GetCategoryByID(categoryID);
       }
    }
}
