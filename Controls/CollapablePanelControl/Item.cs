using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;

namespace Jiaen.Controls
{
	public class Item
	{

		#region 定义私有变量

		private string _url;
		private string _target;
		private string _text;
		private string _imgPath;
		
		#endregion

		#region 定义属性
		
		[
		Description("文字列表内容"),
		Bindable(true),
		Category("ItemStyle")
		]
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
			}
		}

		[
		Description("列表文字的超链接地址"),
		Bindable(true),
		DefaultValue(""),
		Category("ItemStyle")
		]
		public string Url
		{
			get
			{
				return _url;
			}
			set
			{
				_url = value;
			}
		}

		[
		Description("超链接的目标框架"),
		Category("ItemStyle")	
		]
		public string Target
		{
			get
			{
				return _target;
			}
			set
			{
				_target = value;
			}
		}

		[
		Description("图片路径"),
		Bindable(true),
		Category("ItemStyle")
		]
		public string ImgPath
		{
			get
			{
				return _imgPath;
			}
			set
			{
				_imgPath = value;
			}
		}

		#endregion

	}

	/// <summary>
	///定义类Items，表示列表文字集合
	/// </summary>
	public class Items:System.Collections.CollectionBase
	{
		#region 定义私有变量
		private ArrayList _itemArrayList;
		
		#endregion

		#region 定义构造函数
		public Items()
		{
			_itemArrayList = new ArrayList();
		}
		#endregion

		#region 子属性访问代码

		public int Add(Item _item)
		{
			return List.Add(_item);
		}

		public void Remove(Item _item)
		{
			List.Remove(_item);
		}

		public new int Count
		{
			get
			{
				return List.Count;
			}			
		}

		public Item this[int index]
		{
			get
			{
                return (Jiaen.Controls.Item)_itemArrayList[index];
			}
			set
			{
				_itemArrayList[index] = value;
			}
		}		

		#endregion	
	
	}
}
