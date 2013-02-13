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
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;


public partial class Member_Join : System.Web.UI.Page
{
    RegistrationHelper regHelper;
    RegistrationInfo regInfo;
    Encrypt encrypt = new Encrypt();
    Encrypt decryptPwd = new Encrypt();
    string errormsg = "Please Fill ";

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
        if (funCheck())
        {
            regInfo = new RegistrationInfo();
            regHelper = new RegistrationHelper();
            regInfo.UserLoginID = TextBoxUserLoginID.Text;
            regInfo.Password = TextBoxPassword.Text;
            regInfo.FirstName = TextBoxFirstName.Text;
            regInfo.LastName = TextBoxLastName.Text;
            regInfo.Email = TextBoxEmail.Text;
            regInfo.Country = ddlCountry.SelectedValue.ToString();
            regInfo.State = ddlState.SelectedValue.ToString();
            regInfo.City = TextBoxCity.Text;
            regInfo.Zip = TextBoxZip.Text;
            regInfo.CountryName = ddlCountry.SelectedItem.ToString();
            regInfo.ImageName = "NEWIMAGE";
            regHelper.RegisterUser(regInfo);
            if (regInfo.Status == true)
            {
                lblError.Text = "Please Choose another UserLoginID";
                lblError.Visible = true;
            }
            else
            {
                Session["UserLoginId"] = TextBoxUserLoginID.Text;
                Session["FirstName"] = TextBoxFirstName.Text;
                Session["LastName"] = TextBoxLastName.Text;
                Session["Email"] = TextBoxEmail.Text;
                Response.Redirect("AddMemberImages.aspx");
            }
        }
        else
        {
            lblError.Text = errormsg;
            lblError.Visible = true;
        }
    }

    public bool funCheck()
    {
        bool result = true;
        if (TextBoxUserLoginID.Text == "")
        {
            errormsg = errormsg + "UserLoginID ";
            result = false;
        }

        if (TextBoxPassword.Text == "")
        {
            errormsg = errormsg + "Password ";
            result = false;
        }

        if (TextBoxFirstName.Text == "")
        {
            errormsg = errormsg + "FirstName ";
            result = false;
        }

        if (TextBoxLastName.Text == "")
        {
            errormsg = errormsg + "LastName ";
            result = false;
        }

        if (TextBoxCity.Text == "")
        {
            errormsg = errormsg + "City ";
            result = false;
        }

        if (TextBoxZip.Text == "")
        {
            errormsg = errormsg + "Zip ";
            result = false;
        }
        return result;
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
