using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ�����ӿ�
    /// </summary>
   public interface ICategory
    {
        /// <summary>
        /// ��ȡͼ�����
        /// </summary>
        /// <returns></returns>
       IList<CategoryInfo> GetCategory(CategoryType categoryType, int categoryID);

       /// <summary>
       /// ��ȡͼ�����
       /// </summary>
       /// <returns></returns>
       IList<CategoryInfo> GetSameCategory(int parentID);

       /// <summary>
       /// ����ͼ�����
       /// </summary>
       /// <param name="category"></param>
       void InsertCategory(CategoryInfo category);

       /// <summary>
       /// ����ͼ�����
       /// </summary>
       /// <param name="category"></param>
       int UpdateCategory(CategoryInfo category);

       /// <summary>
       /// ɾ��ͼ�����
       /// </summary>
       /// <param name="categoryId"></param>
       /// <returns></returns>
       int DeleteCategory(int categoryId);

       /// <summary>
       /// ��ȡ�ض�ͼ�����
       /// </summary>
       /// <returns></returns>
       CategoryInfo GetCategoryByID(int categoryID);
    }
}
