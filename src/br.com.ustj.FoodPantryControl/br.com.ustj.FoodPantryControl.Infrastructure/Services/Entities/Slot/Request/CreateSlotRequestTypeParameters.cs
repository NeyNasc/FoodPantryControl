using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Slot.Request
{
    public class CreateSlotRequestTypeParameters
    {
        [JsonProperty("parameter")]
        public CreateSlotRequestTypeParameter Parameter { get; set; }

        public CreateSlotRequestTypeParameters(CreateSlotRequestTypeParameter parameter)
        {
            Parameter = parameter;
        }
    }
}
