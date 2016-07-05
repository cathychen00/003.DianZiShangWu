using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
public partial class user_addressInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
           
           dataBind();
        }
       
    }

    void dataBind()
    {
        ProvinceList.AppendDataBoundItems = true;
        AddressInfo address = Address.GetAddressByID();
        UserNameTextBox.Text = address.AddressName;
        if (address.Province == "-1")
        {
            ProvinceList.Items.Insert(0, new ListItem("请选择省份", "-1"));
            CityList.AppendDataBoundItems = true;
            CityList.Items.Insert(0, new ListItem("请选择城市", "-1"));
        }
        else
        {
            CityList.DataSource = SendArea.GetSendArea(1, int.Parse(address.Province));
            CityList.DataTextField = "Name";
            CityList.DataValueField = "AreaID";
            CityList.SelectedValue = address.City;
            CityList.DataBind();
        }
        ProvinceList.SelectedValue = address.Province;
        TelephoneTextBox.Text = address.Telephone;
        PostTextBox.Text = address.Post;
        AddressTextBox.Text = address.Address;
    }

    protected void changeBtn_ServerClick(object sender, EventArgs e)
    {
        AddressInfo address = new AddressInfo(); ;
        address.AddressName = UserNameTextBox.Text;
        address.Province = ProvinceList.SelectedValue;
        address.City = CityList.SelectedValue;
        address.Telephone = TelephoneTextBox.Text;
        address.Post = PostTextBox.Text;
        address.Address = AddressTextBox.Text;
        if (CityList.SelectedValue == "-1")
        {
            successTxt.Text = "请选择省/市";
        }
        else
        {
            if (Address.GetAddressByID().City == "-1")
            {
                Address.UpdateAddress(address);
            }
            else
            {
                bool sened1 = SendArea.GetSendAreaByID(int.Parse(Address.GetAddressByID().City)).IsSended;
                Address.UpdateAddress(address);
                bool sended2 = SendArea.GetSendAreaByID(int.Parse(Address.GetAddressByID().City)).IsSended;
                if ((sened1 == true) && sended2 == false)
                {
                    Address.UpdateAddressSend(1);
                    successTxt.Text = "修改成功";
                    dataBind();
                }
                else
                {
                    successTxt.Text = "修改成功";
                    dataBind();
                }
            }
        }
    }
    protected void ProvinceList_TextChanged(object sender, EventArgs e)
    {
        if (ProvinceList.SelectedValue == "-1")
        {
            CityList.AppendDataBoundItems = true;
            CityList.Items.Clear();
            CityList.Items.Insert(0, new ListItem("请选择城市", "-1"));
        }
        else
        {
            CityList.AppendDataBoundItems = false;
            AddressInfo address = Address.GetAddressByID();
            CityList.DataSource = SendArea.GetSendArea(1, int.Parse(ProvinceList.SelectedValue));
            CityList.DataTextField = "Name";
            CityList.DataValueField = "AreaID";
            CityList.DataBind();
        }
    }
}
