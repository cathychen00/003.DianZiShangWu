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
   public class MonthDropDownList:DropDownList
    {
       public MonthDropDownList()
        {
            for (int i = 1; i <= 12; i++)
            {
                this.Items.Add(new ListItem(i.ToString()+"��", i.ToString()));
            }
        }
    }
}
