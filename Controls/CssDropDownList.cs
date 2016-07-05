using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Jiaen.Components;
using Jiaen.BLL;
namespace Jiaen.Controls
{
   public class CssDropDownList:DropDownList
    {
       public CssDropDownList()
       {
           this.Items.Add(new ListItem("д╛хо", "color:Black;"));
           foreach (TitleCssInfo t in TitleCss.GetTitleCss())
           {
               this.Items.Add(new ListItem(t.TitleCssName, t.TitleCssDec));
           }
       }
    }
}
