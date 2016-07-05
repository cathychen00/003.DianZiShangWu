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
using System.Text;
using Jiaen.Components;
using Jiaen.BLL;
using System.Text.RegularExpressions;
public partial class admin_addPoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string edit = Request.QueryString["edit"];
        if (edit != null)
        {
            DetailsView1.DefaultMode = DetailsViewMode.Edit;
            Repeater2.Visible = true;
        }
        else
        {
            DetailsView1.DefaultMode = DetailsViewMode.Insert;
            Repeater2.Visible =false;
        }
    }
    
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("polls.aspx");
    }


    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {

        PollInfo poll = (PollInfo)e.InputParameters[0];
        StringBuilder VoteNum = new StringBuilder();
        string[] sArray = poll.Items.Split('\n');
        for (int i = 0; i < sArray.Length; i++)
        {
            VoteNum.Append("0" + "|");
        }
        poll.Items = poll.Items.Replace("\n", "|");
        poll.Num = VoteNum.ToString().Trim().Substring(0, VoteNum.Length - 1);
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        if (DetailsView1.DefaultMode == DetailsViewMode.Edit)
        {
            TextBox VoteItemsTxt = (TextBox)DetailsView1.FindControl("VoteItemsTxt");
            VoteItemsTxt.Text = VoteItemsTxt.Text.Replace("|", "\n");
        }
    }

    #region 根据投票结果字符串处理出投票结果

    /// <summary>
    /// 根据投票结果字符串处理出投票结果
    /// </summary>
    protected string GetCount(string result)
    {
        string strResult = "";

        if (Object.Equals(result, null) || Object.Equals(result, ""))
            strResult = "0";
        else
        {
            string[] strArray = result.Split(new Char[] { '|' });

            int count = 0;

            for (int i = 0; i < strArray.Length; i++)
            {
                count += (strArray[i] == "" ? 0 : int.Parse(strArray[i]));
            }

            strResult = count.ToString();
        }
        return strResult;
    }

    #endregion

    #region 将传递的参数转化成 DataTable 数据集

    /// <summary>
    /// 将传递的参数转化成 DataTable 数据集
    /// </summary>
    protected DataTable PollsDataTable(string items, string vote)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("itemName");
        dt.Columns.Add("itemVote");

        string[] strNameArray = items.Split(new Char[] { '|' });
        string[] strVoteArray = vote.Split(new Char[] { '|' });

        for (int i = 0; i < strNameArray.Length; i++)
        {
            dr = dt.NewRow();

            dr["itemName"] = strNameArray[i];
            if (i > strVoteArray.Length - 1)
            {
                dr["itemVote"] = "0";
            }
            else
            {
                dr["itemVote"] = (strVoteArray[i] == "" ? "0" : strVoteArray[i]);
            }

            dt.Rows.Add(dr);
        }

        return dt;
    }

    #endregion

    #region 呈现效果

    /// <summary>
    /// 呈现效果
    /// </summary>
    /// <param name="items"></param>
    /// <param name="vote"></param>
    /// <returns></returns>
    protected string writeChart(string items, string vote)
    {
        
        string strResult = "";

        DataTable dt = this.PollsDataTable(items, vote);

        int totalCount = 0;

        foreach (DataRow row in dt.Rows)
        {
            totalCount += int.Parse(row["itemVote"].ToString());
        }

        strResult += "<table width=\"100%\" cellspacing=\"1\" cellpadding=\"1\" border=\"0\" id=\"votebar\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            double Percent = getPercent(double.Parse(dt.Rows[i]["itemVote"].ToString()), double.Parse(totalCount.ToString()));

            strResult += "<tr><td>" + dt.Rows[i]["itemName"] + "</td><td width=250>";
            strResult += "<table cellspacing=\"0\" cellpadding=\"0\"><tr><td><img src=\"../Images/voteBar_l.gif\" ></td><td><img src=\"../Images/voteBar_m.gif\" height=20 style=\"width:" + (Percent * 200) + "px; ></td><td class=\"r\"><img src=\"../Images/voteBar_r.gif\" ></td><td>" + Percent * 100 + "%</td></tr></table>";
            strResult += "</td><td>" + dt.Rows[i]["itemVote"] + "票</td></tr>";
        }
        strResult += "</table>";

        strResult += "<p align=\"center\"><b>投票总数：" + totalCount + " 票</b></p>";

        return strResult;
    }

    /// <summary>
    /// 获取百分比
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    protected double getPercent(double a, double b)
    {
        double strResult = 0;

        if (b != 0)
        {
            strResult = a / b;
        }

        return double.Parse(strResult.ToString("N"));
    }

    #endregion


    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        PollInfo poll = (PollInfo)e.InputParameters[0];
        StringBuilder VoteNum = new StringBuilder();
        string[] sArray = poll.Items.Split('\n');
        for (int i = 0; i < sArray.Length; i++)
        {
            VoteNum.Append("0" + "|");
        }
        poll.Items = poll.Items.Replace("\n", "|");
        poll.Num = VoteNum.ToString().Trim().Substring(0, VoteNum.Length - 1);
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Response.Redirect("polls.aspx");
    }
}
