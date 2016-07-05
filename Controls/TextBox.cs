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
   public class JTextBox:TextBox    {

       public override string Text
       {
           get
           {
               return base.Text;
           }
           set
           {
               
               if (Text != null)
               {
                   base.Text = value;
               }
               else
               {
                   base.Text = string.Empty;
               }
           }
       }
    }
}
