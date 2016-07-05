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
public partial class Control_ImageBook : System.Web.UI.UserControl
{
    private ImageBookType type;

    public ImageBookType Type
    {
        set { type = value; }
        get { return type; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataList();
        }
    }

    void dataList()
    {
        imageRepeater.DataSource = ImageBook.GetImageBook(type);
        imageRepeater.DataBind();
    }
}