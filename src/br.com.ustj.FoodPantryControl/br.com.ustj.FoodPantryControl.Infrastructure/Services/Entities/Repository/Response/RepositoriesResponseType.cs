using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response
{
    public class RepositoriesResponseType
    {
        [JsonProperty("parameter")]
        public RepositoryType Parameter { get; set; }

        [JsonProperty("customerAccount")]
        public CustomerAccountType CustomerAccount { get; set; }

        [JsonProperty("agreement")]
        public AgreementType Agreement { get; set; }

        [JsonProperty("url")]
        public RepositoryURLType Url { get; set; }
    }
}
