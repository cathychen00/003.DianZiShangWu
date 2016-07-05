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
public partial class admin_publish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            if (ischeck)
            {
                Publish.DeletePublish(intfavID);
                //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
            }
        }
        GridView1.DataBind();
    }
}
