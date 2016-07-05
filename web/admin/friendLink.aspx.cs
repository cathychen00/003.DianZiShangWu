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
public partial class admin_friendLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Main":
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];

                Response.Write(row.Cells[6].Text);
                break;
        }
    }
    //protected void LinkChkBtn_Click(object sender, EventArgs e)
    //{
    //    for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
    //    {
    //        bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
    //        if (ischeck == true)
    //        {
    //            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);

    //            //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
    //            FriendLink.UpdateLink(UpdateLinkType.IsAllowed, intfavID);
    //        }
    //    }
    //    GridView1.DataBind();
    //}
    //protected void DeleteBtn_Click(object sender, EventArgs e)
    //{
    //    for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
    //    {
    //        bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
    //        if (ischeck == true)
    //        {
    //            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
    //            //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
    //           FriendLink.DeleteLink(intfavID);
    //        }
    //    }
    //    GridView1.DataBind();
    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.className='tdbg-dark'";
            e.Row.Attributes["onmouseout"] = "this.className='tdbg'";
        }

    }
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            int linkOrder = int.Parse(((TextBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("linkOrder")).Text);
            
                int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
                //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
                switch (e.CommandName)
                {
                    case "Main":
                        if (ischeck == true)
                        {
                            FriendLink.UpdateLink(UpdateLinkType.IsMained, intfavID);
                        }
                        break;
                    case "Arrow":
                        if (ischeck == true)
                        {
                            FriendLink.UpdateLink(UpdateLinkType.IsAllowed, intfavID);
                        }
                        break;
                    case "Delete":
                        if (ischeck == true)
                        {
                            FriendLink.DeleteLink(intfavID);
                        }
                        break;
                    case "linkOrder":
                        FriendLink.UpdateLink(UpdateLinkType.Order, linkOrder, intfavID);
                        break;
                
            }
        }
        GridView1.DataBind();
    }
}
