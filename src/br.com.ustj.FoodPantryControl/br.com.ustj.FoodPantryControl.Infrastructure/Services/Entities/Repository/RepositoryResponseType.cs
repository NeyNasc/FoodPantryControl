using br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository
{
    public class RepositoryResponseType
    {
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("repositories")]
        public List<RepositoriesResponseType> Repositories { get; set; }
    }
}
