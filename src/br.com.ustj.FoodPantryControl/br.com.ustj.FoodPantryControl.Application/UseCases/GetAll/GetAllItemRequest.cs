using br.com.ustj.FoodPantryControl.Domain.Enum;
using br.com.ustj.FoodPantryControl.Domain.Log;
using System;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.GetAll
{
    public class GetAllItemRequest
    {
        public List<Log> Logs { get; private set; }

        public GetAllItemRequest()
        {
            Logs = new List<Log>();
        }

        public void AddLog(string message, TypeLog typeLog)
            => Logs.Add(new Log(typeLog, DateTime.UtcNow, message));

        public void AddLog(string message, string stackTrace, TypeLog typeLog)
            => Logs.Add(new Log(typeLog, DateTime.UtcNow, message, stackTrace));
    }
}
