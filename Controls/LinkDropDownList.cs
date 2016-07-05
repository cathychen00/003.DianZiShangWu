using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;

namespace Jiaen.Controls
{
   public class LinkDropDownList:DropDownList
    {
       public LinkDropDownList():base()
       {
           Items.Add(new ListItem("显示全部链接", "0"));
           Items.Add(new ListItem("已通过的链接", "1"));
           Items.Add(new ListItem("申请中的链接", "2"));
           Items.Add(new ListItem("主页的链接", "3"));
           Items.Add(new ListItem("未在主页的链接", "4"));
           Items.Add(new ListItem("显示文字链接", "5"));
           Items.Add(new ListItem("显示图片链接", "6"));
       }
    }
}
