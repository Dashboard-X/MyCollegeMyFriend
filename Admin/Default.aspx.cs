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

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkAddUniversity_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/University/AddEditUniversity.aspx");
    }
    protected void lnkAddCollege_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/College/AddEditCollege.aspx");
    }
}
