using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Slot.Request
{
    public class CreateSlotRequestTypeParameter
    {
        [JsonProperty("parameterType")]
        public string ParameterType { get; set; }

        public CreateSlotRequestTypeParameter(string parameterType)
        {
            ParameterType = parameterType;
        }
    }
}
