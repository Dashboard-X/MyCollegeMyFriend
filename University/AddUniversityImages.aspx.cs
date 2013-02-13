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
using System.Drawing;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;

public partial class University_AddUniversityImages : System.Web.UI.Page
{

    protected int UploadedImages;
    private string Finalimagename = "";
    string UniversityID;


    UniversityHelper univ_Help = new UniversityHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!object.Equals(Session["UserLoginId"], null))
        {
            if (!object.Equals(Request.QueryString["UniversityID"], null))
            {
                UniversityID = Request.QueryString["UniversityID"].ToString();
                BindImages(UniversityID);
            }
            else
            {
                Response.Redirect("~");
            }
        }
        else
        {
            Response.Redirect("~");
        }
    }

    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        ImageUpload();
        BindImages(UniversityID);

    }

    private void ImageUpload()
    {

        Directory.CreateDirectory(Server.MapPath("../UniversityImages\\" + UniversityID + "\\" + "Thumbnail"));
        Directory.CreateDirectory(Server.MapPath("../UniversityImages\\" + UniversityID + "\\" + "Real"));

        string pathInner = Server.MapPath("../UniversityImages\\" + UniversityID + "\\" + "Thumbnail");

        if (!Directory.Exists(pathInner + "\\" + "M"))
            Directory.CreateDirectory(pathInner + "\\" + "M");
        if (!Directory.Exists(pathInner + "\\" + "S"))
            Directory.CreateDirectory(pathInner + "\\" + "S");

        HtmlInputFile htmlFile = (HtmlInputFile)BrowseImage0;
        if (htmlFile.PostedFile.ContentLength > 0)
        {
            string sFormat = String.Format("{0:#.##}", (float)htmlFile.PostedFile.ContentLength / 2048);
            if (float.Parse(sFormat) < float.Parse(ConfigurationManager.AppSettings["MaxImageSize"]))
            {
                if (htmlFile.PostedFile != null)
                {
                    ViewState["ImageName"] = htmlFile.PostedFile.FileName.Substring(htmlFile.PostedFile.FileName.LastIndexOf("\\") + 1);//browseImagePath[0];

                }
                else
                {
                    ViewState["ImageName"] = "";
                }

            }
            else
            {
                lblError1.Visible = true;
                lblError1.Text = "Image Size is Large, please resize it !!";


            }
        }
        else
        {
            ViewState["ImageName"] = "";
            if (ViewState["ImageName"].ToString() == "")
            {
                lblError1.Visible = true;
                lblError1.Text = "Attach an image to upload";
            }
            return;
        }

        MakeThumbnail();
    }
    public bool ThumbnailCallback()
    {
        return true;
    }
    private void MakeThumbnail()
    {

        System.Drawing.Image myThumbnail150;
        System.Drawing.Image myThumbnail100;

        object obj = new object();
        obj = BrowseImage0;
        System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
        HtmlInputFile hFile = (HtmlInputFile)obj;
        if (hFile.PostedFile != null && hFile.PostedFile.ContentLength > 0)
        {
            string imgname1 = hFile.PostedFile.FileName.Replace('%', ' ').Substring(hFile.PostedFile.FileName.LastIndexOf("\\") + 1);
            string imgname2 = imgname1.Replace('#', ' ').Substring(imgname1.LastIndexOf("\\") + 1);
            string imgname3 = imgname2.Replace('@', ' ').Substring(imgname1.LastIndexOf("\\") + 1);
            string imgname4 = imgname3.Replace(',', ' ').Substring(imgname1.LastIndexOf("\\") + 1);
            string imgname5 = imgname4.Replace('&', ' ').Substring(imgname1.LastIndexOf("\\") + 1);
            Finalimagename = imgname5.ToString();

            string imgname = hFile.PostedFile.FileName.Substring(hFile.PostedFile.FileName.LastIndexOf("\\") + 1);
            string sExtension = imgname.Substring(imgname.LastIndexOf(".") + 1);
            if (sExtension.ToLower() == "jpg" || sExtension.ToLower() == "gif" || sExtension.ToLower() == "bmp" || sExtension.ToLower() == "jpeg")
            {
                if (!File.Exists(MapPath("../UniversityImages\\" + UniversityID + "\\" + "Real" + "\\" + Finalimagename)))
                {
                    hFile.PostedFile.SaveAs(ResolveUrl(Server.MapPath("../UniversityImages\\" + UniversityID + "\\" + "Real" + "\\" + Finalimagename)));
                    univ_Help.SaveUniversityImage(UniversityID, Finalimagename);

                    System.Drawing.Image imagesize = System.Drawing.Image.FromFile(ResolveUrl(Server.MapPath("../UniversityImages\\" + UniversityID + "\\" + "Real" + "\\" + Finalimagename)));
                    Bitmap bitmapNew = new Bitmap(imagesize);
                    if (imagesize.Width < imagesize.Height)
                    {

                        myThumbnail150 = bitmapNew.GetThumbnailImage(150 * imagesize.Width / imagesize.Height, 150, myCallback, IntPtr.Zero);
                        myThumbnail100 = bitmapNew.GetThumbnailImage(100 * imagesize.Width / imagesize.Height, 100, myCallback, IntPtr.Zero);

                    }
                    else
                    {
                        myThumbnail150 = bitmapNew.GetThumbnailImage(150, imagesize.Height * 150 / imagesize.Width, myCallback, IntPtr.Zero);
                        myThumbnail100 = bitmapNew.GetThumbnailImage(100, imagesize.Height * 100 / imagesize.Width, myCallback, IntPtr.Zero);

                    }
                    myThumbnail150.Save(ResolveUrl(Server.MapPath("../UniversityImages\\" + UniversityID)) + "\\" + "Thumbnail" + "\\" + "M" + "\\" + Finalimagename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    myThumbnail100.Save(ResolveUrl(Server.MapPath("../UniversityImages\\" + UniversityID)) + "\\" + "Thumbnail" + "\\" + "S" + "\\" + Finalimagename, System.Drawing.Imaging.ImageFormat.Jpeg);


                }
                else
                {
                }
            }
            else
            {
            }
        }
    }

    //To Display Images
    private void BindImages(string UniversityID)
    {
        try
        {
            DataTable dUniversityImages = new DataTable();
            univ_Help = new UniversityHelper();
            dUniversityImages = univ_Help.UniversityAllImages(UniversityID);
            if (dUniversityImages.Rows.Count > 0)
            {
                ResultList.DataSource = dUniversityImages;
                ResultList.DataBind();

            }
            else
            {
                ResultList.DataSource = null;
                ResultList.DataBind();
            }

        }
        catch (Exception ex)
        {
            LogFilesClass.CreateLog("UI", ex.Message + ", " + ex.StackTrace);
        }
    }

    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("../UniversityImages/" + dRView["UniversityID"].ToString() + "/" + "Thumbnail" + "/" + "S" + "/" + dRView["ImageName"].ToString());
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
}
