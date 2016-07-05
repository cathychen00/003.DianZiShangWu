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
using Jiaen.BLL;
public partial class downLoadInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string downID = Request.QueryString["downID"];
        if (downID != null)
        {
            Book.UpdateCount(Jiaen.Components.CountType.DownLoad, int.Parse(downID));
            Response.Redirect(DownLoad.GetDownLoadByID(int.Parse(downID)).DownURL);
        }

    }
}
