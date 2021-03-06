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
   public class SendAreaDropDownList:DropDownList
    {

       public SendAreaDropDownList()
       {
           this.Items.Add(new ListItem("一级分类", "0"));
           foreach (SendAreaInfo area in SendArea.GetSendArea(0, 0))
           {
               this.Items.Add(new ListItem(area.Name, area.AreaID.ToString()));
               area.Area = SendArea.GetSendArea(1, area.AreaID);
               RecursiveAddCat(0, area.Area);
           }
       }

        //递归读取数据
        private void RecursiveAddCat(int depth, IList<SendAreaInfo> areas)
        {
            foreach (SendAreaInfo area in areas)
            {
                area.Area = SendArea.GetSendArea(1, area.AreaID);
                switch (depth)
                {
                    case 0:

                        area.Name = "─»" + area.Name;

                        this.Items.Add(new ListItem(area.Name, area.AreaID.ToString()));
                        if (areas.Count > 0)
                            RecursiveAddCat((depth + 1), area.Area);
                        break;
                    case 1:
                        area.Name = "└─»" + area.Name;


                        this.Items.Add(new ListItem(area.Name, area.AreaID.ToString()));
                        if (areas.Count > 0)
                            RecursiveAddCat((depth + 1), area.Area);
                        break;
                    case 2:

                        area.Name = "└───»" + area.Name;

                        this.Items.Add(new ListItem(area.Name, area.AreaID.ToString()));
                        if (areas.Count > 0)
                            RecursiveAddCat((depth + 1), area.Area);
                        break;
                    default:
                        return;
                }
            }
        }
    }

}
