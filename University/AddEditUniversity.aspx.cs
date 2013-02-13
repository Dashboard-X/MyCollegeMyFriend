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

public partial class University_AddEditUniversity : System.Web.UI.Page
{
    RegistrationHelper regHelper;
    UniversityHelper univ_helper = new UniversityHelper();
    UniversityInfo univ_Info = new UniversityInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdownCountry();
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
        univ_Info = new UniversityInfo();
        univ_helper = new UniversityHelper();
        univ_Info.Name = TextBoxUniversityName.Text;
        univ_Info.Country = ddlCountry.SelectedValue.ToString();
        univ_Info.State = ddlState.SelectedValue.ToString();
        univ_Info.City = TextBoxCity.Text;
        univ_Info.Zip = TextBoxZip.Text;
        univ_helper.AddUniversity(univ_Info);
        if (univ_Info.Status == true)
        {
            lblError.Text = "There is Some Problem Please try again...";
            lblError.Visible = true;
        }
        else
        {
            Response.Redirect("AddUniversityImages.aspx?UniversityID=" + univ_Info.UniversityID);
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
