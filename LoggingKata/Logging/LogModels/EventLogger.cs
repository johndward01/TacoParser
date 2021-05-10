using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LoggingKata.Logging
{
    class EventLogger : LogBase
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                EventLog eventLog = new EventLog("");
                eventLog.Source = "IDGEventLog";
                eventLog.WriteEntry(message);
            }
        }
    }
}
