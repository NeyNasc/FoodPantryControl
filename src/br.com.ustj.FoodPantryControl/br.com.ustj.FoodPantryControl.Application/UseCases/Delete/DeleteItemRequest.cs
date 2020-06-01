using br.com.ustj.FoodPantryControl.Domain.Enum;
using br.com.ustj.FoodPantryControl.Domain.Item;
using br.com.ustj.FoodPantryControl.Domain.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Delete
{
    public class DeleteItemRequest
    {
        public string BarCode { get; set; }
        public List<Log> Logs { get; private set; }

        public DeleteItemRequest(string barcode)
        {
            BarCode = barcode;
            Logs = new List<Log>();
        }

        public void AddLog(string message, TypeLog typeLog)
            => Logs.Add(new Log(typeLog, DateTime.UtcNow, message));

        public void AddLog(string message, string stackTrace, TypeLog typeLog)
            => Logs.Add(new Log(typeLog, DateTime.UtcNow, message, stackTrace));
    }
}
