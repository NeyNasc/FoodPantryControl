using System;

namespace br.com.ustj.FoodPantryControl.Webapi.Model
{
    public class ItemModel
    {
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
