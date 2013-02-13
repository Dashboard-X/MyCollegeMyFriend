using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CollegeInfo
/// </summary>
public class CollegeInfo
{
	public CollegeInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string name;
    private string country;
    private string state;
    private string city;
    private string zip;
    private string imageName;
    private bool status;
    private string address;
    private int universityID;
    private string collegeID;
    private string universityName;
    private string countryName;


    //----------------------------------
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public string Country
    {
        get
        {
            return country;
        }
        set
        {
            country = value;
        }
    }

    public string State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    public string City
    {
        get
        {
            return city;
        }
        set
        {
            city = value;
        }
    }

    public string Zip
    {
        get
        {
            return zip;
        }
        set
        {
            zip = value;
        }
    }

    public string ImageName
    {
        get
        {
            return imageName;
        }
        set
        {
            imageName = value;
        }
    }
    public bool Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }

    public int UniversityID
    {
        get { return universityID; }
        set { universityID = value; }
    }

    public string CollegeID
    {
        get { return collegeID; }
        set { collegeID = value; }
    }

    public string UniversityName
    {
        get
        {
            return universityName;
        }
        set
        {
            universityName = value;
        }
    }
    public string CountryName
    {
        get
        {
            return countryName;
        }
        set
        {
            countryName = value;
        }
    }
}
