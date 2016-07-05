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
   public class SendRadioButtonList:RadioButtonList
    {
       public SendRadioButtonList()
       {
//           string a = @"<TD width=80%>
//                              <P>����ʱ�䣺4���ͻ�����&nbsp;&nbsp;&nbsp;<FONT 
//                              color=#ff6600>���Ƽ���</FONT><BR>�շѱ�׼��<BR>���ۺϼ�С�ڵ���40Ԫ�� 
//                              10 Ԫ��ȡ<BR>���ۺϼƴ���40Ԫÿ����40Ԫ���� 4 Ԫ</P>";
           //string b="<td><br>&nbsp;�����ͼ۸�" + string.Format("{0:c}", send.Price) + "��<br>&nbsp;&nbsp;&nbsp;" + send.Dec;
           foreach (SendInfo send in Send.GetSend())
           {
               this.Items.Add(new ListItem(send.Name + "��</td><TD width=80%>�۸�" +string.Format("{0:c}",send.Price)+"&nbsp;&nbsp;"+send.Dec, send.SendID.ToString()));
              
           }
       }
    }
}
