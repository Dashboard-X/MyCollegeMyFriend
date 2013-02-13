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

public partial class Controls_Header : System.Web.UI.UserControl
{
    DataTable dataTable = new DataTable();
    RegistrationHelper reg_Helper = new RegistrationHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!object.Equals(Session["UserLoginId"], null))
            {
                LabelUserLoginID.Visible = false;
                TextBoxUserId.Visible = false;
                LabelPassword.Visible = false;
                TextBoxPassword.Visible = false;
                ButtonLogin.Visible = false;
                ButtonLogout.Visible = true;
                ButtonRegister.Visible = false;
                if (!object.Equals(Session["IsAdmin"], null))
                {
                    ButtonAdmin.Visible = true;
                }
                else
                {
                    ButtonAdmin.Visible = false;
                }
            }
            else
            {
                LabelUserLoginID.Visible = true;
                TextBoxUserId.Visible = true;
                LabelPassword.Visible = true;
                TextBoxPassword.Visible = true;
                ButtonLogin.Visible = true;
                ButtonLogout.Visible = false;
                ButtonRegister.Visible = true;
            }
        }
    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        dataTable = new DataTable();
        reg_Helper = new RegistrationHelper();
        if (TextBoxUserId.Text != "" && TextBoxPassword.Text != "")
        {
            dataTable = reg_Helper.IsUserLoginIDExist(TextBoxUserId.Text, TextBoxPassword.Text);
            if (dataTable.Rows.Count > 0)
            {
                Session["UserLoginId"] = dataTable.Rows[0]["LoginId"].ToString();
                Session["FirstName"] = dataTable.Rows[0]["FirstName"].ToString();
                Session["LastName"] = dataTable.Rows[0]["LastName"].ToString();
                Session["Email"] = dataTable.Rows[0]["Email"].ToString();
                if (dataTable.Rows[0]["LoginId"].ToString() == "rahul")
                {
                    Session["IsAdmin"] = "rahul";
                }
                Response.Redirect("~");
                LabelLoginError.Visible = false;
            }
            else
            {
                LabelLoginError.Text = "Wrong UserId/Password";
                LabelLoginError.Visible = true;
            }
        }
    }
    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session["UserLoginId"] = null;
        Session["FirstName"] = null;
        Session["LastName"] = null;
        Session["Email"] = null;
        Session["IsAdmin"] = null;
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~");

    }
    protected void ButtonAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Default.aspx");
    }
    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Member/Join.aspx");
    }
    protected void ImgLogo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~");
    }
}
