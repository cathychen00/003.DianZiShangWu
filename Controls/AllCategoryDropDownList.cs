using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Jiaen.Components;
using Jiaen.BLL;
namespace Jiaen.Controls
{
   public class AllCategoryDropDownList:DropDownList
    {
       public AllCategoryDropDownList()
       {
           this.Items.Add(new ListItem("一级分类", "0"));
           foreach (CategoryInfo cat in Category.GetCategory(CategoryType.Book, 0))
           {
               this.Items.Add(new ListItem(cat.CategoryName, cat.CategoryID.ToString()));
               cat.Cat = Category.GetCategory(CategoryType.ParesentBook, cat.CategoryID);
               RecursiveAddCat(0, cat.Cat);
           }
       }

       private void RecursiveAddCat(int depth, IList<CategoryInfo> cats)
		{
            foreach (CategoryInfo cat in cats)
			{
				// We only go 3 deep
				//
                cat.Cat = Category.GetCategory(CategoryType.ParesentBook,cat.CategoryID);
				switch (depth)
				{
					case 0:

						Items.Add(new ListItem("─»" + cat.CategoryName,cat.CategoryID.ToString()));
                        if (cats.Count > 0)
                            RecursiveAddCat((depth + 1), cat.Cat);
						break;

					case 1:
                        Items.Add(new ListItem("└─»" + cat.CategoryName,cat.CategoryID.ToString()));
                        if (cats.Count > 0)
                            RecursiveAddCat((depth + 1), cat.Cat);
						break;

					case 2:
                        Items.Add(new ListItem("└───»" + cat.CategoryName, cat.CategoryID.ToString()));
                        if (cats.Count > 0)
                            RecursiveAddCat((depth + 1), cat.Cat);
						break;

					default:
						return;
				}
			}
		}
    }
}
