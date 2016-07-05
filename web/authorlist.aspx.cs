using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
public partial class authorlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataList();
        }
    }

    void dataList()
    {
        CollectionPager1.DataSource = Teacher.GetTeacher(0);
        CollectionPager1.BindToControl = Repeater1;
        Repeater1.DataSource = CollectionPager1.DataSourcePaged;
    }

    public IList<BookInfo> getTop(int ID)
    {
        return Book.GetTeacherBook(0,ID);
    }
}
