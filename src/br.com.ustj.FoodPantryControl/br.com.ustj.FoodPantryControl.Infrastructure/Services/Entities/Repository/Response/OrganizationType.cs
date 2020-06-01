using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response
{
    public class OrganizationType
    {
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
    }
}
