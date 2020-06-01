using System;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.Entities.Item
{
    public class Item
    {
        public Guid Id { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
