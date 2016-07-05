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
using System.Text;
public partial class Vote : System.Web.UI.Page
{
    protected string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化页面状态

        initPage();
        string action = Request.QueryString["action"];
        id = Request.QueryString["id"];
        switch (action)
        {
            case "all":// 所有投票的列表
                allPolls.Visible = true;
                
                break;
            case "vote":// 提示重新投票
                if (Request.Cookies["Vote" + id] != null)
                {
                    JScript.AlertClose("您已经投过票,谢谢您的参与");

                }
                else
                {
                    JScript.AlertClose("请重新投票");
                }
                break;
            case "view":// 查看某一个投票的结果

                if (!Poll.GetPollByID(int.Parse(id)).CanView)
                {

                    JScript.AlertClose("你无权查看此投票结果");
                }
                else
                {
                    viewPanel.Visible = true;
                    if (Request.Cookies["Vote" + id] != null)
                    {
                        Label1.Text = "感谢您参与本次投票";
                    }
                    else
                    {
                        Label1.Text = "返回首页参与本次投票";
                    }
                }
                
                break;
            case "result":// 显示对投票进行的操作结果
                
                if (Request.Cookies["Vote" + id] != null)
                {
                    Label3.Text = "您已经投过票,谢谢您的参与";
                    resultPanel.Visible = true;
                }
                else
                {
                   
                    this.pollResult();
                    Label3.Text = "投票成功,谢谢您的参与";
                    resultPanel.Visible = true;
                }
                break;
            default:
                break;
        }
    }

    void initPage()
    {
        allPolls.Visible = false;
        votePanel.Visible = false;
        viewPanel.Visible = false;
        resultPanel.Visible = false;
    }

    #region 显示对投票进行的操作结果

    void pollResult()
    {
        if (Object.Equals(Request.Form["voteItem_" + id], null) || Object.Equals(Request.Form["voteItem_" + id], ""))
        {
            Response.Redirect("Vote.aspx?action=vote&id=" + id);
            Response.End();
        }
        else
        {
            string[] pollArray = Request.Form["voteItem_" + id].ToString().Split(new Char[] { ',' });
            string vote = "";
            PollInfo pi = Poll.GetPollByID(int.Parse(id));
            DataTable poll = this.PollsDataTable(pi.Items.ToString(), pi.Num.ToString());
            for (int i = 0; i < poll.Rows.Count; i++)
            {
                bool count = false;

                for (int j = 0; j < pollArray.Length; j++)
                {
                    if (i == int.Parse(pollArray[j]))
                    {
                        count = true;
                        break;
                    }
                }
                vote += (count ? int.Parse(poll.Rows[i]["itemVote"].ToString()) + 1 : int.Parse(poll.Rows[i]["itemVote"].ToString())).ToString() + "|";
            }
            PollInfo p = new PollInfo();
            p.PollID = int.Parse(id);
            p.Num = vote.Substring(0,vote.Length-1);
            Poll.UpdatePollNum(p);

            Response.Cookies["Vote" + id].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["Vote" + id].Value = "True";
        }
    }

    #endregion

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
            strResult += "<table cellspacing=\"0\" cellpadding=\"0\"><tr><td><img src=\"Images/voteBar_l.gif\" ></td><td><img src=\"Images/voteBar_m.gif\" height=20 style=\"width:" + (Percent * 200) + "px; ></td><td class=\"r\"><img src=\"Images/voteBar_r.gif\" ></td><td>" + Percent * 100 + "%</td></tr></table>";
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
}
