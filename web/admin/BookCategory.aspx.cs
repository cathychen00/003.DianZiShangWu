using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
using System.Data.SqlClient;
public partial class admin_BookCategory : System.Web.UI.Page
{
    IList<CategoryInfo> bookCats = Category.GetCategory(CategoryType.Book, 0);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataList();
        }
    }

    void dataList()
    {
        foreach (CategoryInfo cat in Category.GetCategory(CategoryType.Book, 0))
        {
            bookCats.Add(cat);

            bookCats.RemoveAt(0);
            
            cat.Cat = Category.GetCategory(CategoryType.ParesentBook, cat.CategoryID);

            RecursiveAddCat(0,cat.Cat);
        }
        GridView1.DataSource = bookCats;
        GridView1.DataBind();
    }

    //递归读取数据
    private void RecursiveAddCat(int depth,IList<CategoryInfo> cats)
    {
        foreach (CategoryInfo cat in cats)
        {
            switch (depth)
            {
                case 0:

                    cat.CategoryName = "─»" + cat.CategoryName;
                    cat.Cat = Category.GetCategory(CategoryType.ParesentBook, cat.CategoryID);
                    bookCats.Add(cat);
                    if (cats.Count > 0)
                        RecursiveAddCat((depth + 1), cat.Cat);
                    break;
                case 1:

                    cat.CategoryName = "└─»" + cat.CategoryName;
                    cat.Cat = Category.GetCategory(CategoryType.ParesentBook, cat.CategoryID);
                    bookCats.Add(cat);
                    if (cats.Count > 0)
                        RecursiveAddCat((depth + 1), cat.Cat);
                    break;
                case 2:

                    cat.CategoryName = "└───»" + cat.CategoryName;
                    cat.Cat = Category.GetCategory(CategoryType.ParesentBook, cat.CategoryID);
                    bookCats.Add(cat);
                    if (cats.Count > 0)
                        RecursiveAddCat((depth + 1), cat.Cat);
                    break;
                default:
                    return;
            }
        }
    }

    private void deleteCatID(int delete)
    {
        if (Category.GetCategory(CategoryType.ParesentBook, delete).Count > 0)
        {
            JScript.Alert("此类别下还分类，不可删除");
        }
        else
        {
            if(Book.GetBookByParentID(0, delete).Count>0)
            {
                JScript.Alert("此类别下有图书信息，不可删除");
            }
            else
            {
                Category.DeleteCategory(delete);
                Response.Redirect("SendArea.aspx");
            }
        }
        dataList();
    }

    //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
       
    //    if (e.CommandName == "catDelete")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
           
    //        deleteCatID(index);
    //    }

    //}

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        
        deleteCatID(Convert.ToInt32(id));
    }
}
