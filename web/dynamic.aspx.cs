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
public partial class dynamic : System.Web.UI.Page
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
        CollectionPager1.DataSource = SiteDynamic.GetSiteDynamic(SiteDynamicType.All);
        CollectionPager1.BindToControl=Repeater2;
        Repeater2.DataSource = CollectionPager1.DataSourcePaged;
    }
}
