using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response
{
    public class CustomerAccountType
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("organizationName")]
        public OrganizationType OrganizationName { get; set; }

        [JsonProperty("organizationIdentification")]
        public IdentificationType OrganizationIdentification { get; set; }
    }
}
