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
    public class PublishDropDownList : DropDownList
    {
        public PublishDropDownList()
        {
            this.Items.Add(new ListItem("Ыљга", "0"));
            foreach (PublishInfo publish in Publish.GetPublishs())
            {
                this.Items.Add(new ListItem(publish.PublishName,publish.PublishName));
            }
        }
    }
}
