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
           Items.Add(new ListItem("��ʾȫ������", "0"));
           Items.Add(new ListItem("��ͨ��������", "1"));
           Items.Add(new ListItem("�����е�����", "2"));
           Items.Add(new ListItem("��ҳ������", "3"));
           Items.Add(new ListItem("δ����ҳ������", "4"));
           Items.Add(new ListItem("��ʾ��������", "5"));
           Items.Add(new ListItem("��ʾͼƬ����", "6"));
       }
    }
}
