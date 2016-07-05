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

public partial class admin_memberList : System.Web.UI.Page
{
   
    protected void GridViewMemberUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Visible = false;
            string userName = ((Label)e.Row.Cells[0].FindControl("userName")).Text;
            string[] roles = Roles.GetRolesForUser(userName);
            string roleName = Request.QueryString["roleName"];
            if (roleName != null)
            {
                e.Row.Visible = false;
            }
            else
            {
                e.Row.Visible = true;
            }
            foreach (string role in roles)
            {
                if (role == roleName)
                {
                    e.Row.Visible = true;
                }
            }
        }
    }

    

    void dataClass()
    {

        string state = Request.QueryString["roleName"];
        if (state != null)
        {
            switch (state)
            {
                case "SendMember":
                    navi1.Attributes["class"] = "Current_Item";
                    break;

                case "MessageMember":
                    navi2.Attributes["class"] = "Current_Item";
                    break;

                case "Member":
                    navi3.Attributes["class"] = "Current_Item";
                    break;
                case "Admin":
                    navi4.Attributes["class"] = "Current_Item";
                    break;
            }
        }
        else
        {
            navi0.Attributes["class"] = "Current_Item";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataClass();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (searchKey.Text != string.Empty)
        {
            ObjectDataSource1.SelectMethod = "FindUsersByName";
            ObjectDataSource1.SelectParameters.Add("usernameToMatch", searchKey.Text);
        }
        else
        {
            ObjectDataSource1.SelectMethod = "GetAllUsers";
        }
        GridViewMemberUser.DataBind();
    }
}
