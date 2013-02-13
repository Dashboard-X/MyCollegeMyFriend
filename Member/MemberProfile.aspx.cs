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

public partial class Member_MemberProfile : System.Web.UI.Page
{
    RegistrationHelper reg_Help = new RegistrationHelper();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!object.Equals(Request.QueryString["UserLoginID"], null))
        {
            GetMemberDetail();
        }
        if(!object.Equals(Session["UserLoginId"],null))
        {
            ButtonFriend.Visible=true;
        }
        else
        {
            ButtonFriend.Visible=false;
        }
    }
    public void GetMemberDetail()
    {
        string UserLoginID =Request.QueryString["UserLoginID"].ToString();
        ds = reg_Help.GetMemberDetail(UserLoginID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            MemberImages.ImageUrl = "~/MemberImages/" + ds.Tables[0].Rows[0]["LoginID"].ToString() + "/" + "Thumbnail" + "/" + "M" + "/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
            LabelFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            LabelLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            LabelEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            LabelCountry.Text = ds.Tables[0].Rows[0]["CountryName"].ToString();
            LabelState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            LabelCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            LabelZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
            LabelJoinDate.Text = ds.Tables[0].Rows[0]["JoinDate"].ToString();  
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            DataListMemberImage.DataSource = ds.Tables[1];
            DataListMemberImage.DataBind();
            DataListMemberImage.Visible = true;
        }
        else
        {
            DataListMemberImage.Visible = false;
        }
    }


    //public string getHREF(object sURL)
    //{
    //    DataRowView dRView = (DataRowView)sURL;
    //    return ResolveUrl("~/Member/MemberProfile.aspx?UserLoginID=" + dRView["LoginId"].ToString());
    //}
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/MemberImages/" + dRView["MemberUserLoginID"].ToString() + "/" + "Thumbnail" + "/" + "M" + "/" + dRView["ImageName"].ToString());
    }
    protected void ButtonFriend_Click(object sender, EventArgs e)
    {
        if (!object.Equals(Session["UserLoginId"], null))
        {
            if (!object.Equals(Request.QueryString["UserLoginID"], null))
            {
                string MyUserID = Session["UserLoginId"].ToString();
                string FriendUserLoginID = Request.QueryString["UserLoginID"].ToString();
                reg_Help = new RegistrationHelper();
                reg_Help.AddToFriend(MyUserID, FriendUserLoginID);
            }
        }
        else
        {
            ButtonFriend.Visible = false;
        }
    }
}
