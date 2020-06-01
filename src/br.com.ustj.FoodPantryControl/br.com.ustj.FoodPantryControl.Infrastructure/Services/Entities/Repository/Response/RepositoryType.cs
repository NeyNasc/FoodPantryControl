using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response
{
    public class RepositoryType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parameterType")]
        public string ParameterType { get; set; }
    }
}
