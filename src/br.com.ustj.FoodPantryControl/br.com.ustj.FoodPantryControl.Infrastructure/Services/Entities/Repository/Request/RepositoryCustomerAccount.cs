using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Request
{
    public class RepositoryCustomerAccount
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("legalId")]
        public RepositoryCustomerAccountLegalId LegalId { get; set; }

        public RepositoryCustomerAccount(string accountId, string companyName, RepositoryCustomerAccountLegalId legalId)
        {
            AccountId = accountId;
            CompanyName = companyName;
            LegalId = legalId;
        }
    }
}
