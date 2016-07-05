using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MemberServerBLL;
using System.Text;
public partial class admin_UserRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 1)
            {
                lbl_UserName.Text = Request.QueryString[0].ToString();
                
                List<RoleData> userInRole = RoleDataObject.GetRoles(lbl_UserName.Text, true);
                lst_UserRole.DataSource = userInRole;
                lst_UserRole.DataTextField = "roleName";
                lst_UserRole.DataValueField = "roleName";
                lst_UserRole.DataBind();

                lst_RestRole.DataSource = RoleDataObject.GetRoles();
                lst_RestRole.DataTextField = "roleName";
                lst_RestRole.DataValueField = "roleName";
                lst_RestRole.DataBind();

                foreach (RoleData role in userInRole)
                {
                    lst_RestRole.Items.Remove(role.RoleName);
                }
            }

        }
    }
    protected void btn_Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("memberList.aspx", true);
    }


    #region 选择Roles
    protected void btn_UnSelectAll_Click(object sender, EventArgs e)
    {
        ListItem[] addList = new ListItem[lst_UserRole.Items.Count];
        lst_UserRole.Items.CopyTo(addList, 0);
        lst_RestRole.Items.AddRange(addList);
        lst_UserRole.Items.Clear();
    }
    protected void btn_SelectAll_Click(object sender, EventArgs e)
    {
        ListItem[] addList = new ListItem[lst_RestRole.Items.Count];
        lst_RestRole.Items.CopyTo(addList, 0);
        lst_UserRole.Items.AddRange(addList);
        lst_RestRole.Items.Clear();
    }
    protected void btn_UnSelect_Click(object sender, EventArgs e)
    {
        //从左边的ListBox到右边的ListBox
        ListItem[] unSelectList = new ListItem[lst_UserRole.Items.Count];
        lst_UserRole.Items.CopyTo(unSelectList, 0);
        foreach (ListItem item in unSelectList)
        {
            if (item.Selected)
            {
                lst_RestRole.Items.Add(item);
                lst_UserRole.Items.Remove(item);
            }
        }
    }
    protected void btn_Select_Click(object sender, EventArgs e)
    {
        ListItem[] unSelectList = new ListItem[lst_RestRole.Items.Count];
        lst_RestRole.Items.CopyTo(unSelectList, 0);
        foreach (ListItem item in unSelectList)
        {
            if (item.Selected)
            {
                lst_UserRole.Items.Add(item);
                lst_RestRole.Items.Remove(item);
            }

        }
    }
    #endregion

    protected void btn_ShowSuccess_ServerClick(object sender, EventArgs e)
    {
        //用户名
        string userName = lbl_UserName.Text;

        //获得原来已经有的角色
        string[] oldRoleNames = Roles.GetRolesForUser(userName);


        //获取ListBox中的要添加的角色
        ArrayList roleArray = new ArrayList();

        foreach (ListItem item in lst_UserRole.Items)
        {
            string newRoleName = item.Text;
            //判断是否是已经存在的
            bool isExists = false;
            foreach (string oldRoleName in oldRoleNames)
            {
                if (oldRoleName == newRoleName)
                {
                    isExists = true;
                    break;
                }
            }
            //如果不存在，就添加到roleArray中准备插入数据库
            if (!isExists)
                roleArray.Add(newRoleName);
        }

        //获取ListBox中的要删除的角色
        ArrayList deleteRoleArray = new ArrayList();
        foreach (ListItem item in lst_RestRole.Items)
        {
            string newRoleName = item.Text;
            //判断是否是已经存在的
            foreach (string oldRoleName in oldRoleNames)
            {
                //如果是已经存在的，那么就放入要删除的ArrayList中
                if (oldRoleName == newRoleName)
                {
                    deleteRoleArray.Add(newRoleName);
                    break;
                }
            }
        }

        //把ArrayList转换成String[]
        string[] addRoleNames = (string[])roleArray.ToArray(typeof(string));
        string[] deleteRoleNames = (string[])deleteRoleArray.ToArray(typeof(string));


        //保存用户所属角色
        if (addRoleNames.Length > 0)
            Roles.AddUserToRoles(userName, addRoleNames);

        //删除用户所属角色
        if (deleteRoleNames.Length > 0)
            Roles.RemoveUserFromRoles(userName, deleteRoleNames);
        Response.Redirect("memberList.aspx", true);
    }
}

