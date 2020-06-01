using br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Slot.Request;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Slot
{
    public class SlotRequestType
    {
        [JsonProperty("url")]
        public CreateSlotRequestTypeUrl Url { get; set; }

        [JsonProperty("parameters")]
        public List<CreateSlotRequestTypeParameters> Parameters { get; set; }

        public SlotRequestType(CreateSlotRequestTypeUrl url, List<CreateSlotRequestTypeParameters> parameters)
        {
            Url = url;
            Parameters = parameters;
        }
    }
}
