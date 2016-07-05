using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
public partial class admin_addBookCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string edit = Request.QueryString["edit"];
            if (edit != null)
            {
                DetailsView1.DefaultMode = DetailsViewMode.Edit;
            }
            else
            {
                DetailsView1.DefaultMode = DetailsViewMode.Insert;
            }
           
        }
    }

    //void dataBind()
    //{
    //    string edit = Request.QueryString["edit"];
    //    if (edit != null)
    //    {
    //        CategoryInfo cat = new CategoryInfo();
    //        cat = Category.GetCategoryByID(int.Parse(edit));
    //        catNameTxt.Text = cat.CategoryName;
    //        AllCategoryDropDownList1.SelectedValue =cat.ParentID.ToString();
    //        catAddBtn.Text = "编辑";
    //    }
    //    else
    //    {
    //        catAddBtn.Text = "新增";
    //    }
    //}

    //protected void catAddBtn_Click(object sender, EventArgs e)
    //{
    //    string edit = Request.QueryString["edit"];
    //    CategoryInfo cat = new CategoryInfo();
    //    cat.CategoryName = catNameTxt.Text;
    //    cat.ParentID =int.Parse(AllCategoryDropDownList1.SelectedValue);
    //    if (edit != null)
    //    {
    //        cat.CategoryID = int.Parse(edit);
    //        Category.UpdateCategory(cat);
    //        Response.Redirect("BookCategory.aspx");
    //    }
    //    else
    //    {
    //        Category.InsertCategory(cat);
    //        Response.Redirect("BookCategory.aspx");
    //    }
    //}

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("BookCategory.aspx");
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Response.Redirect("BookCategory.aspx");
    }
}
