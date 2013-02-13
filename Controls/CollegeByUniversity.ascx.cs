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

public partial class Controls_CollegeByUniversity : System.Web.UI.UserControl
{
    CollegeHelper colgHelper = new CollegeHelper();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!object.Equals(Request.QueryString["UniversityID"], null))
            {
                GetAllCollegeByUniversity(int.Parse(Request.QueryString["UniversityID"].ToString()));
            }
        }
    }

    public void GetAllCollegeByUniversity(int UniversityID)
    {
        dt = colgHelper.GetAllCollegeByUniversity(UniversityID);
        if (dt.Rows.Count > 0)
        {
            CollegeByUniversityList.DataSource = dt;
            CollegeByUniversityList.DataBind();
            CollegeByUniversityList.Visible = true;
        }
        else
        {
            CollegeByUniversityList.Visible = false;
        }
    }

    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        return ResolveUrl("~/College/CollegeDeatils.aspx?CollegeID=" + dRView["CollegeId"].ToString());
    }
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/CollegeImages/" + dRView["CollegeId"].ToString() + "/" + "Thumbnail" + "/" + "S" + "/" + dRView["Image"].ToString());
    }

}
