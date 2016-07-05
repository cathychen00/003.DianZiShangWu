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
    public class DayDropDownList : DropDownList
    {
        public DayDropDownList()
        {
            for (int i = 0; i <= 60; i++)
            {
                this.Items.Add(new ListItem(i.ToString()+"Ìì", i.ToString()));
            }
        }
    }
}
