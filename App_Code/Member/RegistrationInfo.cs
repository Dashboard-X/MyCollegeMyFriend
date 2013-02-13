using System;


/// <summary>
/// Summary description for RegistrationInfo
/// </summary>
public class RegistrationInfo
{
	public RegistrationInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string userLoginID;
    private string password;
    private string firstName;
    private string lastName;
    private string email;
    private string country;
    private string state;
    private string city;
    private string zip;
    private string imageName;
    private bool status;

    private string gender;     
    private string address;
    private string dob;
    private string countryName;

    //----------------------------------
    public string UserLoginID
    {
        get
        {
            return userLoginID;
        }
        set
        {
            userLoginID = value;
        }
    }
   
    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }

     
    public string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            firstName = value;
        }
    }
    
    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            lastName = value;
        }
    }
    
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    public string Gender
    {
        get
        {
            return gender;
        }
        set
        {
            gender = value;
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
