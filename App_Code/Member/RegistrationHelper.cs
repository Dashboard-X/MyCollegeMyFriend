using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

/// <summary>
/// Summary description for RegistrationHelper
/// </summary>
public class RegistrationHelper
{
    private Database dataBase;
    private DataTable dataTable;
    private Database GetDatabaseObject()
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        return dataBase;
    }

    private static readonly ILog logger = LogManager.GetLogger(typeof(RegistrationHelper));
    private SqlParameter[] param;
    private DataSet dataSet;

    public RegistrationHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable IsUserLoginIDExist(string UserLoginId, string Password)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        try
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = dataBase.MakeInParameter("@UserLoginId", SqlDbType.VarChar, 100, UserLoginId);
            parms[1] = dataBase.MakeInParameter("@Password", SqlDbType.VarChar, 100, Password);
            dataBase.RunProcedure("Registration_IsLoginIDExist", parms, out dataTable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            return null;
        }
        finally
        {
            Reset();
        }
        return dataTable;
    }

    public void RegisterUser(RegistrationInfo reg_info)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = dataBase.MakeInParameter("@UserLoginId", SqlDbType.VarChar, 50, reg_info.UserLoginID);
            param[1] = dataBase.MakeInParameter("@Password", SqlDbType.VarChar, 50, reg_info.Password);
            param[2] = dataBase.MakeInParameter("@FirstName", SqlDbType.VarChar, 50, reg_info.FirstName);
            param[3] = dataBase.MakeInParameter("@LastName", SqlDbType.VarChar, 50, reg_info.LastName);
            param[4] = dataBase.MakeOutParameter("@ReturnValue", SqlDbType.Bit, 1);
            param[5] = dataBase.MakeInParameter("@Country", SqlDbType.VarChar, 50, reg_info.Country);
            param[6] = dataBase.MakeInParameter("@City", SqlDbType.VarChar, 50, reg_info.City);
            param[7] = dataBase.MakeInParameter("@State", SqlDbType.VarChar, 50, reg_info.State);
            param[8] = dataBase.MakeInParameter("@Zip", SqlDbType.VarChar, 150, reg_info.Zip);
            param[9] = dataBase.MakeInParameter("@Email", SqlDbType.VarChar, 150, reg_info.Email);
            param[10] = dataBase.MakeInParameter("@ImageName", SqlDbType.VarChar, 150, reg_info.ImageName);
            param[11] = dataBase.MakeInParameter("@CountryName", SqlDbType.VarChar, 150, reg_info.CountryName);
            dataBase.RunProcedure("MakeUserProfile", param);
            reg_info.Status = (bool)param[4].Value;
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            
        }
        finally
        {
            Reset();
        }
        
    }


    public DataSet GetCountryList()
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        try
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            dataBase.RunProcedure("CountryList", parms, out dataSet);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            return null;
        }
        finally
        {
            Reset();
        }
        return dataSet;
    }

    public DataSet GetStateByCountry(int countryid)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        bool result;
        SqlParameter[] parms = new SqlParameter[2];
        parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
        parms[1] = dataBase.MakeInParameter("@countryid", SqlDbType.Int, 4, countryid);
        dataBase.RunProcedure("GetStateByCountry", parms, out dataSet);
        result = (bool)parms[0].Value;
        return dataSet;
    }

    public DataTable MemberAllImages(string UserLoginID)
    {
        DataTable dt = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[2];
        try
        {
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            parms[1] = dataBase.MakeInParameter("@UserLoginID", SqlDbType.VarChar, 50, UserLoginID);
            dataBase.RunProcedure("[GetAllImagesOfMember]", parms, out dt);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            return null;
        }
        finally
        {
            Reset();
        }
        return dt;
    }

    public void SaveUserImage(string UserLoginID, string ImageName)
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[3];
        try
        {
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            parms[1] = dataBase.MakeInParameter("@UserLoginID", SqlDbType.VarChar, 50, UserLoginID);
            parms[2] = dataBase.MakeInParameter("@ImageName", SqlDbType.VarChar, 200, ImageName);
            dataBase.RunProcedure("[SaveMemberImage]", parms);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;

        }
        finally
        {
            Reset();
        }

    }

    public DataTable GetAllUsers()
    {
        DataTable dt = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[1];
        try
        {
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            dataBase.RunProcedure("GetAllRecentUsers", parms, out dt);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            return null;
        }
        finally
        {
            Reset();
        }
        return dt;
    }

    public DataSet GetMemberDetail(string UserLoginID)
    {
        DataSet ds = new DataSet();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[2];
        try
        {
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            parms[1] = dataBase.MakeInParameter("@UserLoginID", SqlDbType.VarChar, 50, UserLoginID);
            dataBase.RunProcedure("[GetMemberDetail]", parms, out ds);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            return null;
        }
        finally
        {
            Reset();
        }
        return ds;
    }

    public void AddToFriend(string MyUserLoginID, string FriendUserLoginID)
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[2];
        try
        {
            parms[1] = dataBase.MakeInParameter("@MyUserLoginID", SqlDbType.VarChar, 50, MyUserLoginID);
            parms[2] = dataBase.MakeInParameter("@FriendUserLoginID", SqlDbType.VarChar, 50, FriendUserLoginID);
            dataBase.RunProcedure("[AddToFriend]", parms);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;

        }
        finally
        {
            Reset();
        }

    }

    public DataTable GetMemberFriend(string UserLoginID)
    {
        DataTable dtable = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[1];
        try
        {            
            parms[0] = dataBase.MakeInParameter("@MyUserLoginID", SqlDbType.VarChar, 50, UserLoginID);
            dataBase.RunProcedure("[GetMemberFriend]", parms, out dtable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            return null;
        }
        finally
        {
            Reset();
        }
        return dtable;
    }

    //To make null all objects
    private void Reset()
    {
        param = null;
        //dataBase = null;
    }

}
