using br.com.ustj.FoodPantryControl.Domain.Enum;
using System;

namespace br.com.ustj.FoodPantryControl.Domain.Log
{
    public class Log: Entity
    {
        public TypeLog TypeLog { get; private set; }
        public DateTime LogDate { get; private set; }
        public string Message { get; private set; }
        public string Stacktrace { get; private set; }

        public Log(TypeLog typeLog, DateTime logDate, string message)
        {
            TypeLog = typeLog;
            LogDate = logDate;
            Message = message;
        }

        public Log(TypeLog typeLog, DateTime logDate, string message, string stacktrace)
        {
            TypeLog = typeLog;
            LogDate = logDate;
            Message = message;
            Stacktrace = stacktrace;
        }
    }
}
