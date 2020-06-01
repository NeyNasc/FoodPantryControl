using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response
{
    public class RepositoryURLType
    {
        [JsonProperty("host")]
        public string Host { get; set; }
    }
}
