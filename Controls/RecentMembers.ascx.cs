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

public partial class Controls_RecentMembers : System.Web.UI.UserControl
{
    RegistrationHelper regHelper = new RegistrationHelper();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllRecentUsers();
        }
    }

    public void GetAllRecentUsers()
    {
        dt = regHelper.GetAllUsers();
        if (dt.Rows.Count > 0)
        {
            RecentUserList.DataSource = dt;
            RecentUserList.DataBind();
            RecentUserList.Visible = true;
        }
        else
        {
            RecentUserList.Visible = false;
        }
    }

    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        return ResolveUrl("~/Member/MemberProfile.aspx?UserLoginID=" + dRView["LoginId"].ToString());
    }
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/MemberImages/" + dRView["LoginId"].ToString() + "/" + "Thumbnail" + "/" + "S" + "/" + dRView["ImageName"].ToString());
    }

}
