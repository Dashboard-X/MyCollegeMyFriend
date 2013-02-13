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

public partial class Controls_RecentUniversity : System.Web.UI.UserControl
{
    UniversityHelper UnivHelper = new UniversityHelper();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllRecentUniversity();
        }
    }

    public void GetAllRecentUniversity()
    {
        dt = UnivHelper.GetAllUniversity();
        if (dt.Rows.Count > 0)
        {
            RecentUniversityList.DataSource = dt;
            RecentUniversityList.DataBind();
            RecentUniversityList.Visible = true;
        }
        else
        {
            RecentUniversityList.Visible = false;
        }
    }

    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        return ResolveUrl("~/University/UniversityDetails.aspx?UniversityID=" + dRView["UniversityId"].ToString());
    }
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/UniversityImages/" + dRView["UniversityId"].ToString() + "/" + "Thumbnail" + "/" + "M" + "/" + dRView["ImageName"].ToString());
    }
}
