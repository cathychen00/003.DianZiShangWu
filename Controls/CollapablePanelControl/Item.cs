using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;

namespace Jiaen.Controls
{
	public class Item
	{

		#region ����˽�б���

		private string _url;
		private string _target;
		private string _text;
		private string _imgPath;
		
		#endregion

		#region ��������
		
		[
		Description("�����б�����"),
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
		Description("�б����ֵĳ����ӵ�ַ"),
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
		Description("�����ӵ�Ŀ����"),
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
		Description("ͼƬ·��"),
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
	///������Items����ʾ�б����ּ���
	/// </summary>
	public class Items:System.Collections.CollectionBase
	{
		#region ����˽�б���
		private ArrayList _itemArrayList;
		
		#endregion

		#region ���幹�캯��
		public Items()
		{
			_itemArrayList = new ArrayList();
		}
		#endregion

		#region �����Է��ʴ���

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
