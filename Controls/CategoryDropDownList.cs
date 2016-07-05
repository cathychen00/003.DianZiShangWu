using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Jiaen.Components;
using Jiaen.BLL;

//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

namespace Jiaen.Controls
{
    public class CategoryDropDownList : DropDownList
    {
        public CategoryDropDownList()
        {
            this.Items.Add(new ListItem("所有", "0"));
            foreach (CategoryInfo cat in Category.GetCategory(CategoryType.Book,0))
            {
                this.Items.Add(new ListItem(cat.CategoryName, cat.CategoryName));
            }
        }
    }
}