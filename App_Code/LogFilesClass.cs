using System;
using System.IO;
using System.Configuration;
    /// <summary>
    /// Summary description for LogFilesClass.
    /// </summary>
    public class LogFilesClass
    {
        public LogFilesClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// This function create a log file and append error.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Message"></param>
        public static void CreateLog(string Title, string Message)
        {
            try
            {
                
                
                if (!Directory.Exists(@ConfigurationSettings.AppSettings["LogDirectoryPath"]))
                    Directory.CreateDirectory(@ConfigurationSettings.AppSettings["LogDirectoryPath"]);
                if (!File.Exists(@ConfigurationSettings.AppSettings["LogFilePath"]))
                    File.Create(@ConfigurationSettings.AppSettings["LogFilePath"]);
                StreamWriter stWriter = File.AppendText(@ConfigurationSettings.AppSettings["LogFilePath"]);
                stWriter.Write("\r\n" + Title + " : ");
                stWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                stWriter.WriteLine("  :");
                stWriter.WriteLine("  :{0}", Message);
                stWriter.WriteLine("-----------------------------------------------------------");

                stWriter.Flush();
                stWriter.Close();
            }
            catch
            {
            }
        }

    }

