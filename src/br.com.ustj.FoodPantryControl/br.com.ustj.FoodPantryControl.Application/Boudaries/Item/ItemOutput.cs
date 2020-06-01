using System;

namespace br.com.ustj.FoodPantryControl.Application.Boudaries.Item
{
    public class ItemOutput
    {     
        public Guid IdItem { get; private set; }
        public string BarCode { get; private set; }
        public int Quantity { get; private set; }
        public string Name { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public DateTime InsertDate { get; private set; }

        public ItemOutput(Guid idItem, string barCode, int quantity, string name, DateTime? expirationDate, DateTime insertDate)
        {
            this.IdItem = idItem;
            this.BarCode = barCode;
            this.Quantity = quantity;
            this.Name = name;
            this.ExpirationDate = expirationDate;
            this.InsertDate = insertDate;
        }
    }
}
