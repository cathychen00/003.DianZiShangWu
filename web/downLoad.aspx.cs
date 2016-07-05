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
public partial class downLoad : System.Web.UI.Page
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
        string catID = Request.QueryString["catID"];
        if (catID != null)
        {
            CollectionPager1.DataSource =DownLoad.GetDownLoadByCat(int.Parse(catID));
        }
        else
        {
            CollectionPager1.DataSource = DownLoad.GetDownLoad();
        }
        CollectionPager1.BindToControl = Repeater1;
        Repeater1.DataSource = CollectionPager1.DataSourcePaged;
    }
}
