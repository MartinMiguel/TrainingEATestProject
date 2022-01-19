using System;
using System.IO;

namespace EAAutoFramework.Helpers
{
    public class LogHelpers
    {
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamWriter = null;

        public static void CreateLogFile()
        {
            string dir = Environment.CurrentDirectory.ToString() + "\\Logs\\" + 
                DateTime.Now.ToShortDateString().Replace("/","_") + "\\";
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            _streamWriter = File.AppendText(dir + _logFileName + ".log");
        }

        public static void Write(string logMessage)
        {
            _streamWriter.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToShortDateString());
            _streamWriter.WriteLine("   {0}", logMessage);
            _streamWriter.Flush();

        }
    }
}
