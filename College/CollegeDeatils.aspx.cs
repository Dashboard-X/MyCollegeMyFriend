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

public partial class College_CollegeDeatils : System.Web.UI.Page
{
    CollegeHelper college_Help = new CollegeHelper();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!object.Equals(Request.QueryString["CollegeID"], null))
        {
            GetCollegeDetail();
            GetCollegeCourse();
        }
    }
    public void GetCollegeDetail()
    {
        int CollegeID = int.Parse(Request.QueryString["CollegeID"].ToString());
        ds = college_Help.GetCollegeDetail(CollegeID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CollegeImages.ImageUrl = "~/CollegeImages/" + ds.Tables[0].Rows[0]["CollegeId"].ToString().Trim() + "/" + "Thumbnail" + "/" + "M" + "/" + ds.Tables[0].Rows[0]["Image"].ToString();
            LabelName.Text = ds.Tables[0].Rows[0]["CollegeName"].ToString();
            LabelCountry.Text = ds.Tables[0].Rows[0]["CountryName"].ToString();
            LabelState.Text = ds.Tables[0].Rows[0]["CollegeState"].ToString();
            LabelCity.Text = ds.Tables[0].Rows[0]["CollegeCity"].ToString();
            LabelZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
            LabelUniversity.Text = ds.Tables[0].Rows[0]["UniversityName"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            DataListCollegeImage.DataSource = ds.Tables[1];
            DataListCollegeImage.DataBind();
            DataListCollegeImage.Visible = true;
        }
        else
        {
            DataListCollegeImage.Visible = false;
        }
    }

    public void GetCollegeCourse()
    {
        DataTable dt = new DataTable();
        college_Help = new CollegeHelper();
        int CollegeIDToCourse = int.Parse(Request.QueryString["CollegeID"].ToString());
        dt = college_Help.GetCourseByCollege(CollegeIDToCourse);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                LabelCollegeCourse.Text = dt.Rows[0]["CourseName"].ToString() + ", ";
            }
        }
    }

    //public string getHREF(object sURL)
    //{
    //    DataRowView dRView = (DataRowView)sURL;
    //    return ResolveUrl("~/College/CollegeDeatils.aspx?CollegeID=" + dRView["CollegeId"].ToString());
    //}
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/CollegeImages/" + dRView["CollegeId"].ToString().Trim() + "/" + "Thumbnail" + "/" + "S" + "/" + dRView["ImageName"].ToString());
    }
}
