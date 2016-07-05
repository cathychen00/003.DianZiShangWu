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
public partial class admin_imageBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            int linkOrder = int.Parse(((TextBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("ImageOrder")).Text);

            int station = int.Parse(((DropDownList)this.GridView1.Rows[rowindex].Cells[0].FindControl("stationList")).SelectedItem.Value);
            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
            switch (e.CommandName)
            {
                case "Main":
                    if (ischeck == true)
                    {
                        ImageBook.UpdateImageBook(UpdateImageType.Station, station, intfavID);

                    }
                    break;
                case "linkOrder":
                    if (ischeck == true)
                    {
                        ImageBook.UpdateImageBook(UpdateImageType.Order, linkOrder,intfavID);
                    }
                    break;
                case "Delete":
                    if (ischeck == true)
                    {
                        ImageBook.DeleteImageBookByID(intfavID);
                    }
                    break;
            }
        }
        GridView1.DataBind();
    }
}
