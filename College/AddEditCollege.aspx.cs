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

public partial class College_AddEditCollege : System.Web.UI.Page
{
    RegistrationHelper regHelper;
    CollegeHelper college_Helper = new CollegeHelper();
    CollegeInfo college_info = new CollegeInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdownCountry();
            FillDropDownUniversity();
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
    private void FillDropdownCountry()
    {
        regHelper = new RegistrationHelper();
        DataSet dsCon = regHelper.GetCountryList();
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
                if (dsCon.Tables[1].Rows.Count > 0)
                {
                    ddlState.DataValueField = "State";
                    ddlState.DataTextField = "State";
                    ddlState.DataSource = dsCon.Tables[1];
                    ddlState.DataBind();
                    ddlState.Items.Add(new ListItem("Other", "Other"));
                    //ddlState.Items.FindByValue(ConfigurationManager.AppSettings["DefaultCountry"].ToString()).Selected = true;
                }
            }
        }
    }     

    protected void Button1_Click(object sender, EventArgs e)
    {
        college_Helper = new CollegeHelper();
        college_info = new CollegeInfo();
        college_info.Name = TextBoxCollegeName.Text;
        college_info.Country = ddlCountry.SelectedValue.ToString();
        college_info.State = ddlState.SelectedValue.ToString();
        college_info.City = TextBoxCity.Text;
        college_info.Zip = TextBoxZip.Text;
        college_info.UniversityID = int.Parse(ddlUniversity.SelectedValue.ToString());
        college_info.UniversityName = ddlUniversity.SelectedItem.Text.ToString();
        college_info.CountryName = ddlCountry.SelectedItem.Text.ToString();
        college_Helper.AddCollege(college_info);
        if (college_info.Status == true)
        {
            lblError.Text = "There is some problem please try again...";
        }
        else
        {
            Response.Redirect("AddCollegeImage.aspx?CollegeID=" + college_info.CollegeID.ToString());
        }
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        regHelper = new RegistrationHelper();
        ddlCountry.Items.FindByValue(ddlCountry.SelectedValue);
        DataSet dsCona = regHelper.GetStateByCountry(int.Parse(ddlCountry.SelectedValue));
        if (dsCona.Tables.Count > 0)
        {
            if (dsCona.Tables[0].Rows.Count > 0)
            {
                ddlState.Visible = true;
                ddlState.DataValueField = "State";
                ddlState.DataTextField = "State";
                ddlState.DataSource = dsCona;
                ddlState.DataBind();
                ddlState.Items.Add(new ListItem("Other", "Other"));
                ddlState.Focus();
                txtState.Visible = false;
                txtState.Text = "";
            }
            else
            {
                ddlState.Visible = false;
                txtState.Visible = true;
            }
        }
        else
        {
            ddlState.Visible = false;
            txtState.Visible = true;
        }
    }
}
