using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 图书类别接口
    /// </summary>
   public interface ICategory
    {
        /// <summary>
        /// 获取图书分类
        /// </summary>
        /// <returns></returns>
       IList<CategoryInfo> GetCategory(CategoryType categoryType, int categoryID);

       /// <summary>
       /// 获取图书分类
       /// </summary>
       /// <returns></returns>
       IList<CategoryInfo> GetSameCategory(int parentID);

       /// <summary>
       /// 新增图书分类
       /// </summary>
       /// <param name="category"></param>
       void InsertCategory(CategoryInfo category);

       /// <summary>
       /// 更新图书分类
       /// </summary>
       /// <param name="category"></param>
       int UpdateCategory(CategoryInfo category);

       /// <summary>
       /// 删除图书分类
       /// </summary>
       /// <param name="categoryId"></param>
       /// <returns></returns>
       int DeleteCategory(int categoryId);

       /// <summary>
       /// 获取特定图书分类
       /// </summary>
       /// <returns></returns>
       CategoryInfo GetCategoryByID(int categoryID);
    }
}
