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

public partial class SearchResult_SearchCollegeByCountry : System.Web.UI.Page
{
    CollegeHelper colgHelper = new CollegeHelper();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!object.Equals(Request.QueryString["CountryID"], null))
            {
                GetAllCollegeByCountry(int.Parse(Request.QueryString["CountryID"].ToString()));
            }
        }
    }

    public void GetAllCollegeByCountry(int CountryID)
    {
        dt = colgHelper.GetAllCollegeByCountry(CountryID);
        if (dt.Rows.Count > 0)
        {
            CollegeListByCountry.DataSource = dt;
            CollegeListByCountry.DataBind();
            CollegeListByCountry.Visible = true;
        }
        else
        {
            CollegeListByCountry.Visible = false;
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
