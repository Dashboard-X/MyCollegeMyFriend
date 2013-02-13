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

public partial class University_UniversityDetails : System.Web.UI.Page
{
    UniversityHelper Univ_Help = new UniversityHelper();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!object.Equals(Request.QueryString["UniversityID"], null))
        {
            GetUniversityDetail();
        }
    }
    public void GetUniversityDetail()
    {
        int UniversityID = int.Parse(Request.QueryString["UniversityID"].ToString());
        ds = Univ_Help.GetUniversityDetail(UniversityID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            UniversityImages.ImageUrl = "~/UniversityImages/" + ds.Tables[0].Rows[0]["UniversityId"].ToString() + "/" + "Thumbnail" + "/" + "M" + "/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
            LabelName.Text = ds.Tables[0].Rows[0]["UniversityName"].ToString();
            LabelCountry.Text = ds.Tables[0].Rows[0]["UniversityCountry"].ToString();
            LabelState.Text = ds.Tables[0].Rows[0]["UniversityState"].ToString();
            LabelCity.Text = ds.Tables[0].Rows[0]["UniversityCity"].ToString();
            LabelZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            DataListUniversityImage.DataSource = ds.Tables[1];
            DataListUniversityImage.DataBind();
            DataListUniversityImage.Visible = true;
        }
        else
        {
            DataListUniversityImage.Visible = false;
        }
    }

    //public string getHREF(object sURL)
    //{
    //    DataRowView dRView = (DataRowView)sURL;
    //    return ResolveUrl("~/University/UniversityDetails.aspx?UniversityID=" + dRView["UniversityId"].ToString());
    //}
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/UniversityImages/" + dRView["UniversityId"].ToString() + "/" + "Thumbnail" + "/" + "M" + "/" + dRView["ImageName"].ToString());
    }
}
