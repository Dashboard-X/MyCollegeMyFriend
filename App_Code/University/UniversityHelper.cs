using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

/// <summary>
/// Summary description for UniversityHelper
/// </summary>
public class UniversityHelper
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

	public UniversityHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void AddUniversity(UniversityInfo Univ_info)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = dataBase.MakeInParameter("@Name", SqlDbType.VarChar, 50, Univ_info.Name);             
            param[1] = dataBase.MakeOutParameter("@ReturnValue", SqlDbType.Bit, 1);
            param[2] = dataBase.MakeInParameter("@Country", SqlDbType.VarChar, 50, Univ_info.Country);
            param[3] = dataBase.MakeInParameter("@City", SqlDbType.VarChar, 50, Univ_info.City);
            param[4] = dataBase.MakeInParameter("@State", SqlDbType.VarChar, 50, Univ_info.State);
            param[5] = dataBase.MakeInParameter("@Zip", SqlDbType.VarChar, 150, Univ_info.Zip);
            param[6] = dataBase.MakeOutParameter("@UniversityID", SqlDbType.Int, 1);
            dataBase.RunProcedure("[University_AddNewUniversity]", param);
            Univ_info.Status = (bool)param[1].Value;
            Univ_info.UniversityID = param[6].Value.ToString();
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

    public DataTable GetAllUniversity()
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
            dataBase.RunProcedure("GetAllRecentUniversity", parms, out dt);
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
    public void SaveUniversityImage(string UniversityID, string ImageName)
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[3];
        try
        {
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            parms[1] = dataBase.MakeInParameter("@UniversityID", SqlDbType.VarChar, 50, UniversityID);
            parms[2] = dataBase.MakeInParameter("@ImageName", SqlDbType.VarChar, 200, ImageName);
            dataBase.RunProcedure("[SaveUniversityImage]", parms);
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

    public DataTable UniversityAllImages(string UniversityID)
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
            parms[1] = dataBase.MakeInParameter("@UniversityId", SqlDbType.VarChar, 50, UniversityID);
            dataBase.RunProcedure("[GetAllImagesOfUniversity]", parms, out dt);
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

    public DataSet GetUniversityDetail(int UniversityID)
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
            parms[1] = dataBase.MakeInParameter("@UniversityID", SqlDbType.Int, 4, UniversityID);
            dataBase.RunProcedure("[GetUniversityDetail]", parms, out ds);
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

    //To make null all objects
    private void Reset()
    {
        param = null;
        //dataBase = null;
    }

}
