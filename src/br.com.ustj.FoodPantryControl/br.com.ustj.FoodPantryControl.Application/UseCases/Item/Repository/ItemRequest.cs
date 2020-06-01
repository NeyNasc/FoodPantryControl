using br.com.ustj.FoodPantryControl.Domain.Enum;
using br.com.ustj.FoodPantryControl.Domain.Log;
using System;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Application.UseCases.Item.Repository
{
    public class ItemRequest
    {

        public Domain.Item.Item ItemRepository { get; set; }
        public List<Log> Logs { get; set; }
        public TypeRepository TypeRepository { get; set; }


        public ItemRequest(string barCode, int quantity, string name, DateTime? expirationDate)
        {
            this.ItemRepository = new Domain.Item.Item(
                Guid.NewGuid(),
                barCode,                
                quantity,
                name,
                expirationDate,
                DateTime.Now
                );
            this.Logs = new List<Log>();
        }

        public void AddLog(string message, TypeLog typeLog)
            => Logs.Add(new Log(typeLog, DateTime.UtcNow, message));

        public void AddLog(string message, string stackTrace, TypeLog typeLog)
            => Logs.Add(new Log(typeLog, DateTime.UtcNow, message, stackTrace));
    }
}

