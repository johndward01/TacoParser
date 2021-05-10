using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata.Logging
{
    class DBLogger : LogBase
    {
        string connectionString = "";
        public override void Log(string message)
        {
            lock (lockObj)
            {
                // code to log data to the database
                throw new NotImplementedException();
            }
        }
    }
}
