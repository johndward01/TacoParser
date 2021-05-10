using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggingKata.Logging
{
    class FileLogger : LogBase
    {
        public string filePath = "Log.txt";
        public override void Log(string message)
        {
            lock (lockObj)
            {
                using StreamWriter streamWriter = new StreamWriter(filePath);
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
