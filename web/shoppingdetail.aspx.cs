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
public partial class shoppingdetail : System.Web.UI.Page
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
        ViewState["url"] = Request.UrlReferrer.AbsolutePath;
        ProvinceList.AppendDataBoundItems = true;
        AddressInfo address = Address.GetAddressByID();
        userNameTxt.Text = address.AddressName;
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
        telephoneTxt.Text = address.Telephone;
        postTxt.Text = address.Post;
        addressTxt.Text = address.Address;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        AddressInfo address = new AddressInfo(); ;
        address.AddressName = userNameTxt.Text;
        address.Province = ProvinceList.SelectedValue;
        address.Telephone = telephoneTxt.Text;
        address.Post = postTxt.Text;
        address.Address = addressTxt.Text;
        address.City = CityList.SelectedValue;

        if (CityList.SelectedValue == "-1")
        {
            Label1.Text = "请选择省/市";
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
                    Address.UpdateAddressPay(2);
                    Response.Redirect(ViewState["url"].ToString());
                }
                else
                {
                    Response.Redirect(ViewState["url"].ToString());
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
