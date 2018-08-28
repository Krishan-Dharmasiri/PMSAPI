using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.Helpers
{
    public class FlatFileLogger
    {
        private static readonly string _destination = @"C:\Krishantha\Projects\PMSAPI\";
       

        public static void Log(string message)
        {
            DateTime curDate = DateTime.Now;
            string fileName = "Log_" + curDate.Year + curDate.Month + curDate.Day+".txt";
            string fullPath = _destination + "\\" + fileName;
            File.AppendAllText(fullPath, message + Environment.NewLine); //This commans add a line to the file, it will create the file if it does not exist so no need to check
                                                                         //whether the file exists or not
        }
    }
}
