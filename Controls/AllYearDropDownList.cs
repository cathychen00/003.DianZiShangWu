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
    public class AllYearDropDownList:DropDownList
    {
        public AllYearDropDownList()
        {
            for (int i = 1998; i <= DateTime.Now.Year; i++)
            {
                this.Items.Add(new ListItem(i.ToString()+"Äê", i.ToString()));
            }
        }
    }
}
