using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

/// <summary>
/// Summary description for CollegeHelper
/// </summary>
public class CollegeHelper
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

	public CollegeHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void AddCollege(CollegeInfo college_info)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];            
            param[0] = dataBase.MakeInParameter("@Name", SqlDbType.VarChar, 50, college_info.Name);
            param[1] = dataBase.MakeInParameter("@UniversityID", SqlDbType.Int, 4, college_info.UniversityID);
            param[2] = dataBase.MakeOutParameter("@ReturnValue", SqlDbType.Bit, 1);
            param[3] = dataBase.MakeInParameter("@Country", SqlDbType.VarChar, 50, college_info.Country);
            param[4] = dataBase.MakeInParameter("@City", SqlDbType.VarChar, 50, college_info.City);
            param[5] = dataBase.MakeInParameter("@State", SqlDbType.VarChar, 50, college_info.State);
            param[6] = dataBase.MakeInParameter("@Zip", SqlDbType.VarChar, 150, college_info.Zip);
            param[7] = dataBase.MakeOutParameter("@CollegeID", SqlDbType.Int, 1);
            param[8] = dataBase.MakeInParameter("@UniversityName", SqlDbType.VarChar, 100, college_info.UniversityName);
            param[9] = dataBase.MakeInParameter("@CountryName", SqlDbType.VarChar, 100, college_info.CountryName);
            dataBase.RunProcedure("[College_AddNewCollege]", param);
            college_info.Status = (bool)param[2].Value;
            college_info.CollegeID = param[7].Value.ToString();
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
    public DataSet GetUniversityList()
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        try
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            dataBase.RunProcedure("[UniversityList]", parms, out dataSet);
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

    public DataSet GetCourseList()
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataSet = new DataSet();
        try
        {
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            dataBase.RunProcedure("[CourseList]", parms, out dataSet);
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

    public DataTable GetAllCollege()
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
            dataBase.RunProcedure("GetAllRecentCollege", parms, out dt);
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

    public DataTable GetAllCollegeByCountry(int CountryID)
    {
        DataTable dt = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[1];
        try
        {
            parms[0] = dataBase.MakeInParameter("@CountryID", SqlDbType.Int, 4, CountryID);
            dataBase.RunProcedure("[GetAllCollegeByCountry]", parms, out dt);
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

    public DataTable GetAllCollegeByUniversity(int UniversityID)
    {
        DataTable dt = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[1];
        try
        {
            parms[0] = dataBase.MakeInParameter("@UniversityID", SqlDbType.Int, 4, UniversityID);
            dataBase.RunProcedure("[GetAllCollegeByUniversity]", parms, out dt);
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

    public void SaveCollegeImage(string CollegeID, string ImageName)
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[3];
        try
        {
            parms[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            parms[1] = dataBase.MakeInParameter("@CollegeID", SqlDbType.VarChar, 50, CollegeID);
            parms[2] = dataBase.MakeInParameter("@ImageName", SqlDbType.VarChar, 200, ImageName);
            dataBase.RunProcedure("[SaveCollegeImage]", parms);
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
    
    public DataTable CollegeAllImages(string CollegeID)
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
            parms[1] = dataBase.MakeInParameter("@CollegeID", SqlDbType.VarChar, 50, CollegeID);
            dataBase.RunProcedure("[GetAllImagesOfCollege]", parms, out dt);
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
    public DataSet GetCollegeDetail(int CollegeID)
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
            parms[1] = dataBase.MakeInParameter("@CollegeID", SqlDbType.Int, 4, CollegeID);
            dataBase.RunProcedure("[GetCollegeDetail]", parms, out ds);
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

    public void AddCourseToCollege(int CourseID, int CollegeID , string CourseName)
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[3];
        try
        {
            parms[0] = dataBase.MakeInParameter("@CourseID", SqlDbType.Int, 4, CourseID);
            parms[1] = dataBase.MakeInParameter("@CollegeID", SqlDbType.Int, 4, CollegeID);
            parms[2] = dataBase.MakeInParameter("@CourseName", SqlDbType.VarChar, 200, CourseName);
            dataBase.RunProcedure("[AddCourseToCollege]", parms);
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

    public DataTable GetCourseByCollege(int CollegeID)
    {
        DataTable dt = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[1];
        try
        {           
            parms[0] = dataBase.MakeInParameter("@CollegeID", SqlDbType.VarChar, 50, CollegeID);
            dataBase.RunProcedure("[GetCourseByCollege]", parms, out dt);
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

    public DataTable GetAllCollegeByCourse(int CourseID)
    {
        DataTable dt = new DataTable();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        SqlParameter[] parms = new SqlParameter[1];
        try
        {
            parms[0] = dataBase.MakeInParameter("@CourseID", SqlDbType.Int, 4, CourseID);
            dataBase.RunProcedure("[GetAllCollegeByCourse]", parms, out dt);
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
    //To make null all objects
    private void Reset()
    {
        param = null;
        //dataBase = null;
    }

}
