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
using System.Text;
using System.Text.RegularExpressions;
using Jiaen.Components;
using Jiaen.BLL;
public partial class admin_Polls : System.Web.UI.Page
{
    protected string id;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

   

    /// <summary>
    /// 获取某个投票的项目列表
    /// </summary>
    protected string GetVoteItem(int id, string items, string isMultiple)
    {
        string strResult = "";
        Regex r = new Regex("(|)");
        string[] strArray = items.Split(new Char[] {'|'});
        Response.Write(isMultiple.ToString());
        string inputType = (isMultiple == "True" ? "checkbox" : "radio");

        for (int i = 0; i < strArray.Length; i++)
        {
            strResult += "<input type=\"" + inputType + "\" name=\"voteItem_" + id + "\" value=\"" + i + "\" id=\"voteItem_" + id + "_" + i + "\" /><label for=\"voteItem_" + id + "_" + i + "\">" + strArray[i] + "</label><br />";
        }
        return strResult;
    }
}
