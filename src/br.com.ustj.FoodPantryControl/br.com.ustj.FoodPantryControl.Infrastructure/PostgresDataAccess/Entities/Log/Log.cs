using br.com.ustj.FoodPantryControl.Domain.Enum;
using System;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.Entities.Log
{
    public class Log
    {
        public Guid Id { get; set; }
        public TypeLog TypeLog { get;  set; }
        public DateTime LogDate { get;  set; }
        public string Message { get;  set; }
        public string Stacktrace { get;  set; }
    }
}
