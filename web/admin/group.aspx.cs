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

public partial class admin_group : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataList();
        }

    }

    void dataList()
    {
        string[] rolesArray;

        rolesArray = Roles.GetAllRoles();
        DropDownList1.DataSource = rolesArray;
        DropDownList1.DataBind();
        GridView1.DataSource = rolesArray;
        GridView1.DataBind();


    }
    protected void addBtn_Click(object sender, EventArgs e)
    {
        string createRole = roleName.Text;

        try
        {
            if (Roles.RoleExists(createRole))
            {
                Msg.Text = "角色 '" + Server.HtmlEncode(createRole) + "' 已存在.";
                return;
            }

            Roles.CreateRole(createRole);

            Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' 创建.";
            dataList();
        }
        catch (Exception ee)
        {
            Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' <u>not</u> created.";
            Response.Write(ee.ToString());
        }
    }

    protected void deleteBtn_Click(object sender, EventArgs e)
    {
       
        Roles.DeleteRole(DropDownList1.SelectedValue);
        dataList();
        msg2.Text = "删除成功";
    }
}
