using System;
using System.Data;
using System.Data.SqlClient;
using log4net;


    /// <summary>
	/// Summary description for Login Helper.
	/// </summary>
	public class LoginHelper
	{
        private Database dataBase;
        private Database GetDatabaseObject()
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
                //LoginHelper.dataBase = Database.GetSingleDatabaseInstance();
            }
            return dataBase;
        }

        private static readonly ILog logger = LogManager.GetLogger(typeof(LoginHelper));
		private SqlParameter[] param;       

        /// <summary>
        /// This function is used to Authenticate user.	
        /// </summary>
        public void AuthenticateUser(Login login,ref DataSet ds)
        {           
            param = new SqlParameter[4];
            dataBase = GetDatabaseObject();
            try
            {
                param[0] = dataBase.MakeInParameter("@UserId", System.Data.SqlDbType.VarChar, 50, login.UserID);
                param[1] = dataBase.MakeInParameter("@PWD", System.Data.SqlDbType.VarChar, 300, login.Password);
                param[2] = dataBase.MakeOutParameter("ReturnValue", SqlDbType.Int, 1);                               
                param[3] = dataBase.MakeInParameter("@IPAddress", SqlDbType.VarChar, 20, login.IPAddress);               
                dataBase.RunProcedure("ValidateUserLogin", param, out ds);
                 if(!object.Equals(ds,null))
                 {
                     if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                     {
                         login.Status = true;                         
                     }
                     else
                     {
                         login.Status = false;
                     }
                 }             
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

        /// <summary>
        /// This function is used to Change the password for a user	
        /// </summary>
        /// <returns>Return Status of Request</returns>		
        public int EditPassword(Login login)
        {
            int sOutput = 0;
            param = new SqlParameter[4];
            dataBase = GetDatabaseObject();
            try
            {
                param[0] = dataBase.MakeInParameter("@UserLoginID", System.Data.SqlDbType.VarChar, 50, login.UserID);
                param[1] = dataBase.MakeInParameter("@OldPWDE", System.Data.SqlDbType.VarChar, 100, login.OldPWD);
                param[2] = dataBase.MakeInParameter("@NewPWDE", System.Data.SqlDbType.VarChar, 100, login.Password);                
                param[3] = dataBase.MakeOutParameter("@Res", SqlDbType.Int, 4);
                dataBase.RunProcedure("ChangePassword", param);
                sOutput = (int)param[3].Value;
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return sOutput;
            }
            finally
            {

                Reset();
            }
            return sOutput;
        }


       

        private void Reset()
        {
            param = null;
            //dataBase = null;
        }
	}


