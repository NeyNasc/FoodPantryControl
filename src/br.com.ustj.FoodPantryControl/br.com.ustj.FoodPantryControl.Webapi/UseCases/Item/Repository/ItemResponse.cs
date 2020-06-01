using System;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Gedoc.Repository
{
    public class ItemResponse
    {
        public Guid ItemId { get; set; }
        public string BarCode { get; private set; }
        public int Quantity { get; private set; }
        public string Name { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public DateTime InsertDate { get; private set; }

        public ItemResponse(Guid itemId, string barCode, int quantity, string name, DateTime? expiration, DateTime inserteDate)
        {
            this.ItemId = itemId;
            this.BarCode = barCode;
            this.Quantity = quantity;
            this.Name = name;
            this.ExpirationDate = expiration;
            this.InsertDate = inserteDate;
        }
    }
}
