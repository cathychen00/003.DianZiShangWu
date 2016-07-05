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

public partial class advanceSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        publishYear.Items.Insert(0, new ListItem("请选择年份", "0"));
        publishMonth.Items.Insert(0, new ListItem("请选择月份", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string[] key = new string[9];
        //key[0] = bookName.Text;
        //key[1] = bookPublish.Text;
        //key[2] = bookAuthor.Text;
        //key[3] = bookCategory.SelectedValue;
        //key[4] = bookISBN.Text;
        //key[5] = bookPrice.Text;
        //key[6] = operatorList.SelectedValue;
        //key[7] = publishYear.SelectedValue;
        //key[8] = publishMonth.SelectedValue;
        //Jiaen.SQLServerDAL.Book a = new Jiaen.SQLServerDAL.Book();
        //GridView1.DataSource = a.GetAdvanceSearchBook(key);
        //GridView1.DataBind();
        string url = "SearchBook.aspx?type=2";
        url += "&bookName=" + bookName.Text + "&press="+ bookPublish.Text;
        url += "&author=" + bookAuthor.Text + "&cat="+ bookCategory.SelectedValue;
        url += "&ISBN=" + bookISBN.Text + "&price="+bookPrice.Text;
        url += "&operator=" + operatorList.SelectedValue + "&Year="+publishYear.SelectedValue;
        url += "&Month=" + publishMonth.SelectedValue;
        Response.Redirect(url);
    }
}
