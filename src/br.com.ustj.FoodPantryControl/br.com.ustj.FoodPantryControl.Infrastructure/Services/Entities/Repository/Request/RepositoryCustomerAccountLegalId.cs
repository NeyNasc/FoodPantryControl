using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Request
{
    public class RepositoryCustomerAccountLegalId
    {
        [JsonProperty("nationalID")]
        public string NationalID { get; set; }

        [JsonProperty("nationalIDType")]
        public string NationalIDType { get; set; }

        public RepositoryCustomerAccountLegalId(string nationalID, string nationalIDType)
        {
            NationalID = nationalID;
            NationalIDType = nationalIDType;
        }
    }
}
