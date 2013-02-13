using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using log4net;
using System.Collections;

/// <summary>
/// Summary description for MailBoxFunction
/// </summary>
public class MailBoxFunction
{
    public MailBoxFunction()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private Database dataBase;

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
    private DataTable dataTable;

    public void SendMail(MailBoxInfo mailInfo)
    {
        bool result;
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        param = new SqlParameter[5];
        try
        {
            param[0] = dataBase.MakeOutParameter("@Status", SqlDbType.Bit, 1);
            param[1] = dataBase.MakeInParameter("@SenderUserLoginID", SqlDbType.NVarChar, 50, mailInfo.SenderUserLoginID);
            param[2] = dataBase.MakeInParameter("@ReceiverUserLoginID", SqlDbType.NVarChar, 50, mailInfo.ReceiverUserLoginID);
            param[3] = dataBase.MakeInParameter("@MailSubject", SqlDbType.VarChar, 100, mailInfo.MailBoxSubject);
            param[4] = dataBase.MakeInParameter("@MailText", SqlDbType.Text, 16, mailInfo.MailBoxText);
            dataBase.RunProcedure("MailBoxSendMail", param, out dataSet);
            result = (bool)param[0].Value;
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

    public DataTable GetUserMailToInbox(string UserId)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        param = new SqlParameter[1];
        try
        {
            param[0] = dataBase.MakeInParameter("@UserLoginID", SqlDbType.VarChar, 50, UserId);
            dataBase.RunProcedure("MailBoxGetUserMailForInbox", param, out dataTable);
        }
        catch (Exception exp)
        {

        }
        finally
        {

        }
        return dataTable;
    }

    public DataTable GetUserMailToSendBox(string UserId)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        param = new SqlParameter[1];
        try
        {
            param[0] = dataBase.MakeInParameter("@UserLoginID", SqlDbType.VarChar, 50, UserId);
            dataBase.RunProcedure("MailBoxGetUserMailForSendbox", param, out dataTable);
        }
        catch (Exception exp)
        {

        }
        finally
        {

        }
        return dataTable;
    }

    public DataTable GetUserMailToTrashBox(string UserId)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        param = new SqlParameter[1];
        try
        {
            param[0] = dataBase.MakeInParameter("@UserLoginID", SqlDbType.VarChar, 50, UserId);
            dataBase.RunProcedure("MailBoxGetUserMailForTrashbox", param, out dataTable);
        }
        catch (Exception exp)
        {

        }
        finally
        {

        }
        return dataTable;
    }


    public DataTable ReadOneMail(int MessageID)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        param = new SqlParameter[1];
        try
        {
            param[0] = dataBase.MakeInParameter("@MailID", SqlDbType.VarChar, 50, MessageID);
            dataBase.RunProcedure("MailBoxReadOneMail", param, out dataTable);
        }
        catch (Exception exp)
        {
        }
        finally
        {

        }
        return dataTable;
    }

    public DataTable ReadOneMailFromSendBox(int MessageID)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        param = new SqlParameter[1];
        try
        {
            param[0] = dataBase.MakeInParameter("@MailID", SqlDbType.VarChar, 50, MessageID);
            dataBase.RunProcedure("MailBoxReadOneMailFromSendBox", param, out dataTable);
        }
        catch (Exception exp)
        {
        }
        finally
        {

        }
        return dataTable;
    }

    public DataTable ReadOneMailFromTrashBox(int MessageID)
    {
        dataBase = GetDatabaseObject();
        if (object.Equals(dataSet, null))
            dataTable = new DataTable();
        param = new SqlParameter[1];
        try
        {
            param[0] = dataBase.MakeInParameter("@MailID", SqlDbType.VarChar, 50, MessageID);
            dataBase.RunProcedure("MailBoxReadOneMailFromTrashBox", param, out dataTable);
        }
        catch (Exception exp)
        {
        }
        finally
        {

        }
        return dataTable;
    }

    public void DeleteMailToTrashMail(Hashtable activeDeactiveHash, string FROM)
    {
        try
        {
            IDictionaryEnumerator MyHashEnumerator = activeDeactiveHash.GetEnumerator();
            int Result;
            dataBase = GetDatabaseObject();
            SqlParameter[] parms = new SqlParameter[3];
            while (MyHashEnumerator.MoveNext())
            {
                int boolenValue = 0;
                if (string.Compare(MyHashEnumerator.Value.ToString(), "true", true) == 0)
                    boolenValue = 1;
                else
                    boolenValue = 0;
                parms[0] = dataBase.MakeInParameter("@IsActive", SqlDbType.Int, 10, boolenValue);
                parms[1] = dataBase.MakeInParameter("@Message_Id", SqlDbType.VarChar, 200, MyHashEnumerator.Key);
                parms[2] = dataBase.MakeInParameter("@From", SqlDbType.VarChar, 50, FROM);
                dataBase.RunProcedure("MailBoxDeleteMailToTrashMail", parms);
            }
        }
        catch (Exception ex)
        {
            LogFilesClass.CreateLog("Database", ex.Message + "," + ex.StackTrace);
        }
    }

    public void DeleteAccountMail(string sMessageID, string sIdTo, string from)
    {
        dataBase = GetDatabaseObject();
        SqlParameter[] objParameter = new SqlParameter[4];
        try
        {
            objParameter[0] = dataBase.MakeInParameter("@MessageID", System.Data.SqlDbType.VarChar, 200, sMessageID);
            objParameter[1] = dataBase.MakeOutParameter("@NextMsgID", System.Data.SqlDbType.Int, 4);
            objParameter[2] = dataBase.MakeInParameter("@IdTo", System.Data.SqlDbType.VarChar, 50, sIdTo);
            objParameter[3] = dataBase.MakeInParameter("@From", System.Data.SqlDbType.VarChar, 50, from);
            dataBase.RunProcedure("MailBoxDeleteMailFromMailAccountbox", objParameter);
        }
        catch (Exception ex)
        {
            LogFilesClass.CreateLog("Database", ex.Message + "," + ex.StackTrace);
        }
        finally
        {
        }

    }

    //This function will delete single mail from INBOX and Send mail and insert single mail to Trash Table
    public void DeleteOneMailToTrashMail(int MailID, string FROM)
    {
        dataBase = GetDatabaseObject();
        SqlParameter[] objParameter = new SqlParameter[2];
        try
        {
            objParameter[0] = dataBase.MakeInParameter("@MailID", SqlDbType.Int, 4, MailID);
            objParameter[1] = dataBase.MakeInParameter("@From", SqlDbType.VarChar, 50, FROM);
            dataBase.RunProcedure("MailBoxDeleteOneMailToTrashMail", objParameter);
        }
        catch (Exception ex)
        {
            LogFilesClass.CreateLog("Database", ex.Message + "," + ex.StackTrace);
        }
    }

    public void DeleteOneMail(int MailID, string FROM)
    {
        dataBase = GetDatabaseObject();
        SqlParameter[] objParameter = new SqlParameter[2];
        try
        {
            objParameter[0] = dataBase.MakeInParameter("@MailID", SqlDbType.Int, 4, MailID);
            objParameter[1] = dataBase.MakeInParameter("@From", SqlDbType.VarChar, 50, FROM);
            dataBase.RunProcedure("MailBoxDeleteOneMail", objParameter);
        }
        catch (Exception ex)
        {
            LogFilesClass.CreateLog("Database", ex.Message + "," + ex.StackTrace);
        }
    }



    //To make null all objects
    private void Reset()
    {
        param = null;
        //dataBase = null;
    }
}
