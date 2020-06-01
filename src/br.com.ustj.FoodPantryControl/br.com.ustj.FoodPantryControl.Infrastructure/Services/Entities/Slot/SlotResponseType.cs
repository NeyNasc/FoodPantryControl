using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Slot
{
    public class SlotResponseType
    {
        [JsonProperty("responseCode")]
        public decimal? ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }
    }
}
