using System;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Delete
{
    public class DeleteItemResponse
    {
        public Guid Id { get; }
        public string BarCode { get; }
        public string Name{ get; }

        public DeleteItemResponse(Guid id, string barcode, string name)
        {
            this.Id = id;
            this.BarCode = barcode;
            this.Name = name;
        }
    }
}
