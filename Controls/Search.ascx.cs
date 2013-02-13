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

public partial class Controls_Search : System.Web.UI.UserControl
{
    RegistrationHelper regHelper;
    CollegeHelper college_Helper = new CollegeHelper();
    CollegeInfo college_info = new CollegeInfo();
    DataSet dsCon;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdownCountry();
            FillDropDownUniversity();
            FillDropdownCourse();
        }
    }

    private void FillDropdownCourse()
    {
        CollegeHelper college_Helper = new CollegeHelper();
        DataSet dsCon = college_Helper.GetCourseList();
        if (!object.Equals(dsCon, null))
        {
            if (dsCon.Tables.Count > 0)
            {
                if (dsCon.Tables[0].Rows.Count > 0)
                {
                    ddlCourse.DataValueField = "CourseId";
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataSource = dsCon.Tables[0];
                    ddlCourse.DataBind();
                }
            }
        }
    }

    private void FillDropdownCountry()
    {
        regHelper = new RegistrationHelper();
        dsCon = new DataSet();
        dsCon = regHelper.GetCountryList();
        if (!object.Equals(dsCon, null))
        {
            if (dsCon.Tables.Count > 0)
            {
                if (dsCon.Tables[0].Rows.Count > 0)
                {
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "Country";
                    ddlCountry.DataSource = dsCon.Tables[0];
                    ddlCountry.DataBind();
                    //ddlCountry.Items.FindByValue(ConfigurationManager.AppSettings["DefaultCountry"].ToString()).Selected = true;
                }                
            }
        }
    }

    private void FillDropDownUniversity()
    {
        college_Helper = new CollegeHelper();
        DataSet dsCon = college_Helper.GetUniversityList();
        if (!object.Equals(dsCon, null))
        {
            if (dsCon.Tables.Count > 0)
            {
                if (dsCon.Tables[0].Rows.Count > 0)
                {
                    ddlUniversity.DataValueField = "UniversityId";
                    ddlUniversity.DataTextField = "UniversityName";
                    ddlUniversity.DataSource = dsCon.Tables[0];
                    ddlUniversity.DataBind();
                }
            }
        }
    }


    protected void ButtonCountrySearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SearchResult/SearchCollegeByCountry.aspx?CountryID=" + ddlCountry.SelectedValue.ToString());
    }
    protected void ButtonUniversitySearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SearchResult/SearchCollegeByUniversity.aspx?UniversityID=" + ddlUniversity.SelectedValue.ToString());
    }
    protected void ButtonCourseSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SearchResult/SearchCollegeByCourse.aspx?CourseID=" + ddlCourse.SelectedValue.ToString());
    }
    protected void ButonHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~");
    }
}
