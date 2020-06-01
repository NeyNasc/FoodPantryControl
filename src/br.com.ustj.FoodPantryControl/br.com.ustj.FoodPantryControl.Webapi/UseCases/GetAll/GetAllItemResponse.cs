using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.GetAll
{
    public class GetAllItemResponse
    {
        public Guid Id{ get; }
        public string BarCode { get; }
        public int Quantity { get; }
        public string Name { get; }
        public DateTime? ExpirationDate { get; }
        public DateTime InsertDate { get; }

        public GetAllItemResponse(Guid id, string barcode, int qtd, string name, DateTime? expiration, DateTime insert)
        {
            this.Id = id;
            this.BarCode = barcode;
            this.Quantity = qtd;
            this.Name = name;
            this.ExpirationDate = expiration;
            this.InsertDate = insert;
        }

    }
}
