using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Slot.Request
{
    public class CreateSlotRequestTypeUrl
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        public CreateSlotRequestTypeUrl(string host)
        {
            Host = host;
        }
    }
}
