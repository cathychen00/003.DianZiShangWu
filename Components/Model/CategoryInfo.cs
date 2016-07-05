using System;
using System.Collections.Generic;
using System.Text;
using Jiaen.Components.IDAL;
namespace Jiaen.Components
{
   public class CategoryInfo
    {
       private int intCategoryID;
       private string strCategoryName;
       private int intParentID;
       private IList<CategoryInfo> cat;
       private bool isMain;

       /// <summary>
       /// 显示首页
       /// </summary>
       public bool IsMain
       {
           get { return isMain; }
           set { isMain = value; }
       }

       /// <summary>
       /// 分类编号
       /// </summary>
       public int CategoryID
       {
           get { return intCategoryID; }
           set { intCategoryID = value; }
       }

       /// <summary>
       /// 分类名称
       /// </summary>
       public string CategoryName
       {
           get { return strCategoryName; }
           set { strCategoryName = value; }
       }

       public IList<CategoryInfo> Cat
       {
           get { return cat; }
           set { cat = value; }
       }

       /// <summary>
       /// 父类编号
       /// </summary>
       public int ParentID
       {
           get { return intParentID; }
           set { intParentID = value; }
       }
    }
}
