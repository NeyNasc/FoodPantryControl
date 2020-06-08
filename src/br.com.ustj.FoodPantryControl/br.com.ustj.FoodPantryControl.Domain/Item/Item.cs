using System;

namespace br.com.ustj.FoodPantryControl.Domain.Item
{
    public class Item : Entity
    {
        public string BarCode { get; private set; }
        public int Quantity { get; set; }
        public string Name { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public DateTime InsertDate { get; private set; }

        public Item(Guid id, string barCode, int quantity, string name, DateTime? expirationDate, DateTime insertDate)
        {
            this.Id = id;
            this.BarCode = barCode;
            this.Quantity = quantity;
            this.Name = name;
            this.ExpirationDate = expirationDate;
            this.InsertDate = insertDate;
        }

        public void SetNewInsertDate(DateTime newnow)
        {
            this.InsertDate = newnow;
        }
    }
}
