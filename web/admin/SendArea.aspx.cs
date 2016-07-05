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
public partial class admin_SendArea : System.Web.UI.Page
{
    IList<SendAreaInfo> myAreas = SendArea.GetSendArea(0, 0);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            dataList();
        }
    }

    void dataList()
    {
        foreach (SendAreaInfo area in SendArea.GetSendArea(0, 0))
        {
            myAreas.Add(area);

            myAreas.RemoveAt(0);

            area.Area = SendArea.GetSendArea(1, area.AreaID);

            RecursiveAddCat(0, area.Area);
        }
        GridView1.DataSource = myAreas;
        GridView1.DataBind();
    }

    //递归读取数据
    private void RecursiveAddCat(int depth, IList<SendAreaInfo> areas)
    {
        foreach (SendAreaInfo area in areas)
        {
            area.Area = SendArea.GetSendArea(1, area.AreaID);
            switch (depth)
            {
                case 0:

                    area.Name = "─»" + area.Name;
                    //area.Area = SendArea.GetSendArea(1, area.AreaID);
                    myAreas.Add(area);
                    if (areas.Count > 0)
                        RecursiveAddCat((depth + 1), area.Area);
                    break;
                case 1:
                    area.Name = "└─»" + area.Name;
                    //area.Area = SendArea.GetSendArea(1, area.AreaID);
                    
                    myAreas.Add(area);
                    if (areas.Count > 0)
                        RecursiveAddCat((depth + 1), area.Area);
                    break;
                case 2:

                    area.Name = "└───»" + area.Name;
                    //area.Area = SendArea.GetSendArea(1, area.AreaID);
                    myAreas.Add(area);
                    if (areas.Count > 0)
                        RecursiveAddCat((depth + 1), area.Area);
                    break;
                default:
                    return;
            }
        }
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        Response.Redirect("SendArea.aspx#" + DropDownList1.SelectedValue);
    }

    private void deleteCatID(int delete)
    {
        if (SendArea.GetSendArea(1, delete).Count > 0)
        {
            JScript.Alert("此类别下还分类，不可删除");

        }
        else
        {
            SendArea.DeleteSendArea(delete);
        }
        dataList();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        deleteCatID(Convert.ToInt32(id));
        
    }
}
