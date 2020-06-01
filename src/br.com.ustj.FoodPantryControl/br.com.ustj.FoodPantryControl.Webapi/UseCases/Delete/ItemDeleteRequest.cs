using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Delete
{
    public class ItemDeleteRequest
    {
        [Required]
        [JsonProperty("barCode")]
        public string BarCode { get; private set; }
    }
}
