using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Gedoc.Repository
{
    public class ItemRequest
    {
        [Required]
        [JsonProperty("barCode")]
        public string BarCode { get; private set; }
        
        [Required]
        [JsonProperty("quantity")]
        public int Quantity { get; private set; }
        
        [Required]
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; private set; }
        
    }
}
