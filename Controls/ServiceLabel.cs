using System;
using System.IO;
using System.Collections.Generic;
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
   public class ServiceLabel:Label
    {

       public override string Text
       {
           get
           {
               return SiteSetting.GetSiteSettings("jiaen").SiteBottomDec;
           }
           set
           {
               base.Text = value;
           }
       }
    }
}
