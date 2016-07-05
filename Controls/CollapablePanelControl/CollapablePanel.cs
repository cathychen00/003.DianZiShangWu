using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Jiaen.Components;
namespace Jiaen.Controls
{
	[
	DefaultProperty("TitleText"),
	ParseChildren(true,"ItemList")	
	]
	public class CollapablePanel : System.Web.UI.WebControls.WebControl
	{
		#region 定义私有变量

		private string _titleText;
		private Items _items=new Items();
		private Unit _width;
        private string _path ="/ClientScript";
				
		#endregion	

		#region 定义构造函数

		public CollapablePanel():base(HtmlTextWriterTag.Table)
		{				
		}		

		#endregion

		#region 定义属性

		#region //定义属性TitleText
		[
		Category("Appearance"),
		DefaultValue(""),
		Description("控件上部显示文字")
		]
		public string TitleText
		{
			get
			{
                
				return (_titleText == null) ? String.Empty:_titleText;
			}
			set
			{
				_titleText = value;
			}
		}
		#endregion

        #region //定义路径
        [
        Category("Appearance"),
        DefaultValue(""),
        Description("脚本路径")
        ]
        public string Path
        {
            get
            {
                return (_path == null) ? String.Empty : _path;
            }
            set
            {
                _path = value;
            }
        }
        #endregion

		#region //定义属性Width		
		[
		Description("定义控件宽度"),
		Category("Layout")
		]
		public override Unit Width
		{
			get
			{
				return (_width == Unit.Empty) ? Unit.Pixel(150):_width;
			}
			set
			{
				_width = value;
			}
		}
		#endregion



		#region //定义复杂属性ItemList
		[
		Category("Data"),
		Description("列表子属性"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		NotifyParentProperty(true),
		PersistenceMode(PersistenceMode.InnerDefaultProperty)
		]
		public Items ItemList
		{
			get
			{
				return _items;
			}			
		}
		#endregion

		#endregion

		#region 呈现控件

		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Width,Width.ToString());
            writer.AddStyleAttribute("behavior", "url(" + Path + "/CollapablePanel.htc)");
			writer.AddStyleAttribute("cellspacing","0");
			writer.AddStyleAttribute("cellpadding","0");
			writer.AddStyleAttribute("border","0");		
			//重写基类方法
			base.AddAttributesToRender (writer);
		}

		
		protected override void RenderContents(HtmlTextWriter output)
		{
            output.Write("<LINK REL='stylesheet' TYPE='text/css' HREF='" + Path + "/style.css'></LINK>");
			output.RenderBeginTag(HtmlTextWriterTag.Tr);
			output.RenderBeginTag(HtmlTextWriterTag.Td);
			
			output.Write("<table cellpadding='0' cellspacing='0' class='clsPart'>");
			output.Write("<tr>");
            output.Write("<td height='19' width='15'><img src='" + Path + "/images/gripblue.gif'></td>");
			output.Write("<td align='center' width='100%'><b class='clsPartHead'>"+TitleText+"</b></td>");
            output.Write("<td class='clsPartRight' height='19' width='25'><img class='clsMinimize' src='" + Path + "/images/downlevel.gif'></td>");
			output.Write("</tr>");
			output.Write("<tr>");
			output.Write("<td colspan='3'class='clsBorder'>");
			output.Write("<table bgcolor='#f1f1f1' width='100%' border='0px'>");
			output.Write("<tr>");
			output.Write("<td width='100%' align='center'>");
			output.Write("<table width='100%' cellpadding='1' cellspacing='1' border='0'>");
			output.Write("<tr><td height='6'colspan='2'></td></tr>");
			
			//以下为循环输出Item内容
			if(this.ItemList.Count != 0)
			{
				foreach(Item _item in this.ItemList)
				{
					output.Write("<tr>");
					output.Write("<td width='18' height='18' ><img style='margin-left:5px' src='"+_item.ImgPath.ToString()+"'></td>");
					output.Write("<td width='100%'><a class='itemStyle' href='"+_item.Url+"' "+"target='"+_item.Target+"'>"+_item.Text+"</a></td>");
					output.Write("</tr>");
				}			
			}
			
			output.Write("<tr><td height='4'></td></tr>");
			output.Write("</table>");
			output.Write("</td>");
			output.Write("</tr>");
			output.Write("</table></td></tr></table>");
			output.RenderEndTag();
			output.RenderEndTag();
		}

		#endregion
	}
}
